
using System;

namespace Program.client
{
    public abstract class Employee : IEmployee
    {
        public string Name { get; private set; }
        public IRole Role { get; private set; }

        public Seniority Seniority => _seniority ??=  Seniority.CreateNewJunior(1);
        private Seniority _seniority { get;  set; }

        public Salary Salary  { get; private set; }

        protected Employee(string name) =>
            Name = name;
        protected Employee(string name, Seniority s) =>
            Name = name;

        public void UpdateName( string value ) =>
            Name = value;
        
        public void UpdateRole(IRole value) =>
            Role = value;
        public void UpdateSalary(Salary value) =>
            Salary = value;

        public void UpdateSeniority(Seniority value) => 
            _seniority = value;
        
        internal void CalcInitialSalary()
        {
            var calcBaseSalary = new SalaryCalculator();
            Salary = calcBaseSalary.Calculate(this);
        }
    }

}
// You are working for a multinational company that has 251 employees around the globe.
// In order to speed up the process of salary increments,
// your boss wants you to develop a program that
// groups each employee in different sections depending on their position (HR, Engineering, Artist, Design and PM). 
//
// In addition, employees should be ordered depending on current seniority (Junior, Semi Senior and Senior).
//
// Expected:
//
// In the company there are:
//  20 HR → (5 Seniors, 2 Semi Seniors and 13 Juniors)
// 150 Engineering → (50 Seniors, 68 Semi Seniors and 32 Juniors)
//  25 Artist → (5 Seniors and 20 Semi Seniors)
//  25 Design → (10 Seniors and 15 Juniors)
//  30 PMs → (10 Seniors and 20 Semi Seniors)
//   1 Ceo 
    
// Base Requirement
// Objects: Employee, Role, SalaryCalculator, EmployeeRepository, SalaryRepository
