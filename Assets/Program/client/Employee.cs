
namespace Program.client
{
    public abstract class Employee : IEmployee
    {
        public string Name { get; private set; }
        public IRole Role => _role;
        private IRole _role;
        public Seniority Seniority => _seniority ??= new Junior();
        private Seniority _seniority { get;  set; }

        public Salary Salary => _salary ??= new Salary(-1);
        public  Salary _salary { get; internal set; }

        protected Employee(string name, Seniority seniority)
        {
            Name = name;
            _seniority = seniority;
        }

        
        internal void UpdateName( string value ) =>
            Name = value;
        
        internal void UpdateRole(IRole value)
        { 
            _role = value;
        }

        internal void UpdateSeniority(Seniority value)
        {
            _seniority = value;
        }
        internal void CalcSalary()
        {
            var calcBaseSalary = new SalaryCalculator();
            _salary = calcBaseSalary.Calculate(this);
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
