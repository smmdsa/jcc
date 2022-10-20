namespace Program.client
{
    public class ChiefExecutiveOfficer : Employee, IRole
    {

        public ChiefExecutiveOfficer(string name, Seniority seniority) : base(name)
        {
            DefineRole();
            DefineSeniorityFor(seniority);
            CalcInitialSalary();
        }

        private void DefineRole()
        {
            InitializeBaseSalary();
            UpdateRole(this);
        }
        private void InitializeBaseSalary()=>
            _salary = new Salary(BaseSalaryRepository.CEO_BASE_SALARY);
        private void DefineSeniorityFor(Seniority seniority) => 
            UpdateSeniority(SeniorityFactory.CreateSeniorityFor(this,seniority));
        
        public float BaseSalary() => Salary.BaseSalary;
        public float CurrentSalary() => Salary.CurrentSalary;
        public void UpdateSalary(Salary salary) => _salary = salary;
    }
}