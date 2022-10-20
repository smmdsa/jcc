using System.Collections.Generic;
using System;
namespace Program.client
{
    public class Engineer : Employee, IRole
    {
        private float _juniorModifier = 1f;
        private float _midModifier = 2f;
        private float _seniorModifier = 1.67f;
        private Dictionary<Type, float> SeniorityModifiers => _seniorityModifiers ??= new Dictionary<Type, float>();
        private Dictionary<Type, float> _seniorityModifiers;
        public Engineer(string name, Seniority seniority) : base(name, seniority)
        {
            DefineRole();
            DefineSeniorityFor(seniority);
            CalcSalary();
        }

        private void DefineRole()
        {
            Init();
            UpdateRole(this);
        }

        private void Init()
        {
            InitializeBaseSalary();
            InitializeSeniority();
        }

        private void InitializeBaseSalary()
        {
            var salaryRepository = new BaseSalaryRepository();
            Salary.BaseSalary = salaryRepository.ENGINEER_BASE_SALARY;
        }

        private void InitializeSeniority()
        {
            _juniorModifier = 1f;
            _midModifier = _juniorModifier*2f;
            _seniorModifier = _midModifier*1.666667f;
            
            SeniorityModifiers.Add(typeof(Junior), _juniorModifier);
            SeniorityModifiers.Add(typeof(SemiSenior), _midModifier);
            SeniorityModifiers.Add(typeof(Senior), _seniorModifier);
        }
        private void DefineSeniorityFor(Seniority seniority)
        {
            var seniorityAvailableForThisRol = SeniorityModifiers.TryGetValue(  seniority.GetType(), out var seniorityModifier );
            if (!seniorityAvailableForThisRol) throw new Exception("No Seniority for this role available. Try it latter");
            
            seniority.SeniorityMultiplier = seniorityModifier;
            UpdateSeniority(seniority);
        }

        public float BaseSalary() => Salary.BaseSalary;

        public float CurrentSalary() => Salary.CurrentSalary;
        public void UpdateSalary(Salary salary) => _salary = salary;
    }
}