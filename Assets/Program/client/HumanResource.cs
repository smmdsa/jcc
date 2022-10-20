using System;
using System.Collections.Generic;

namespace Program.client
{
    public class HumanResource : Employee, IRole
    {
        private float _juniorModifier;
        private float _midModifier ;
        private float _seniorModifier ;
        private Dictionary<Type, float> SeniorityModifiers => _seniorityModifiers ??= new Dictionary<Type, float>();
        private Dictionary<Type, float> _seniorityModifiers;
        public HumanResource(string name, Seniority seniority) : base(name, seniority)
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
            Salary.BaseSalary = salaryRepository.HR_BASE_SALARY;
        }

        private void InitializeSeniority()
        {
            _juniorModifier = 1;
            _midModifier = _juniorModifier+_juniorModifier;
            _seniorModifier = _juniorModifier+_midModifier;
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