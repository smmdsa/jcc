using System;
using System.Collections.Generic;

namespace Program.client
{
    public class Artist : Employee, IRole
    {
        private float _midModifier = 1f;
        private float _seniorModifier = 1.67f;
        private Dictionary<Type, float> SeniorityModifiers => _seniorityModifiers ??= new Dictionary<Type, float>();
        private Dictionary<Type, float> _seniorityModifiers;
        public Artist(string name, Seniority seniority) : base(name, seniority)
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
            Salary.BaseSalary = salaryRepository.ARTIST_BASE_SALARY;
        }

        private void InitializeSeniority()
        {
            _midModifier = 1;
            _seniorModifier = 1.666667f;
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