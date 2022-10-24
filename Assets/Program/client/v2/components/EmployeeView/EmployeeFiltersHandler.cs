using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Program.client.v2.components
{
    public class EmployeeFiltersHandler : MonoBehaviour
    {
        [SerializeField] private EmployeeScrollViewHandler _employeeScrollView;
        [SerializeField] private TMP_Dropdown roleDropdown;
        [SerializeField] private TMP_Dropdown seniorityDropdown;
        private IRoleRepository _roleRepository;
        private ISeniorityRepository _seniorityRepository;
        private EmployeeRepositoryComponent _employeeRepositoryComponent;

        private int CurrentRoleSelected
        {
            get => _currentRoleSelected;
            set
            {
                _currentRoleSelected = value;
                UpdateScrollView();
            }
        }

        private int _currentRoleSelected;

        private int CurrentSenioritySelected
        {
            get => _currentSenioritySelected;
            set
            {
                _currentSenioritySelected = value;
                UpdateScrollView();
            }
        }

        private int _currentSenioritySelected = 0;

        private void Awake()
        {
            SetRepositoryForAvailableRoleAndSeniority();

            var roles = _roleRepository.GetCurrentAvailable();
            var seniority = _seniorityRepository.GetCurrentAvailable();
            roleDropdown.options.Clear();
            roleDropdown.options.Add(new TMP_Dropdown.OptionData($"-"));
            foreach (var t in roles)
                roleDropdown.options.Add(new TMP_Dropdown.OptionData($"{t}"));

            seniorityDropdown.options.Clear();
            seniorityDropdown.options.Add(new TMP_Dropdown.OptionData($"-"));
            foreach (var t in seniority)
                seniorityDropdown.options.Add(new TMP_Dropdown.OptionData($"{t}"));


            roleDropdown.onValueChanged.AddListener(OnRoleSelectionChange);
            seniorityDropdown.onValueChanged.AddListener(OnSenioritySelectionChange);
        }

        private void Start()=>
            UpdateScrollView(_employeeRepositoryComponent.GetAll());
        
        private void SetRepositoryForAvailableRoleAndSeniority()
        {
            //@todo will be injected by some kind ServiceManager some like ServiceManager.Get<EmployeeRepositoryComponent>();
            _employeeRepositoryComponent = GetComponents<EmployeeRepositoryComponent>()[0];

            _roleRepository = _roleRepository ??= new FakeRoleRepository();
            _seniorityRepository = _seniorityRepository ??= new FakeSeniorityRepository();
        }

        private void OnRoleSelectionChange(int index)=>
            CurrentRoleSelected = index;
        

        private void OnSenioritySelectionChange(int index)=>
            CurrentSenioritySelected = index;
        

        private void UpdateScrollView(List<Employee> employees)=>
            _employeeScrollView.EmployeeToShow(employees);
        

        private void UpdateScrollView() =>
            UpdateScrollView(GetEmployeesBy(_currentRoleSelected, _currentSenioritySelected));


        private List<Employee> GetEmployeesBy(int currentRoleSelected, int currentSenioritySelected)
        {
            var output = new List<Employee>();
            if (currentRoleSelected != 0 && currentSenioritySelected != 0)
            {
                var roleLabel = roleDropdown.options[CurrentRoleSelected].text.ToUpper();
                var seniorityLabel = seniorityDropdown.options[CurrentSenioritySelected].text.ToUpper();
                output.AddRange(_employeeRepositoryComponent.GetAll()
                    .Where(e => e.GetType().Name.ToUpper() == roleLabel)
                    .Where(e => e.Seniority.GetType().Name.ToUpper() == seniorityLabel).ToList());
            }
            else if (currentRoleSelected != 0)
            {
                var roleLabel = roleDropdown.options[CurrentRoleSelected].text.ToUpper();
                output.AddRange(_employeeRepositoryComponent.GetAll()
                    .Where(e => e.GetType().Name.ToUpper() == roleLabel).ToList());
            }
            else if (currentSenioritySelected != 0)
            {
                var seniorityLabel = seniorityDropdown.options[CurrentSenioritySelected].text.ToUpper();
                output.AddRange(_employeeRepositoryComponent.GetAll()
                    .Where(e => e.Seniority.GetType().Name.ToUpper() == seniorityLabel).ToList());
            }
            else
                output = _employeeRepositoryComponent.GetAll();

            return output;
        }
    }

    public class FakeSeniorityRepository : ISeniorityRepository
    {
        public string[] GetCurrentAvailable() => new string[]
        {
            nameof(Junior), nameof(SemiSenior), nameof(Senior)
        };
    }

    public class FakeRoleRepository : IRoleRepository
    {
        public string[] GetCurrentAvailable() => new string[]
        {
            nameof(CEO), nameof(Artist), nameof(Engineer), nameof(Designer), nameof(ProjectManager),
            nameof(HumanResource)
        };
    }

    public interface IRoleRepository
    {
        string[] GetCurrentAvailable();
    }

    public interface ISeniorityRepository
    {
        string[] GetCurrentAvailable();
    }
}