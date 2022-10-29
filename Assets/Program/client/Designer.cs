
namespace Program.client
{
    public class Designer : Employee, IRole
    {
        public Designer(string name, Seniority seniority) : base(name)
        {
            UpdateSalary( new Salary(BaseSalaryRepository.DESIGN_BASE_SALARY));
            UpdateRole(this);
            UpdateSeniority(SeniorityFactory.CreateSeniorityFor(this, seniority));
            CalcInitialSalary();
        }
        
        public float BaseSalary() => Salary.BaseSalary;
        public float CurrentSalary() => Salary.CurrentSalary;
        public void CalculateIncrement() => this.CalculateEmployeeIncrementV2();
    }
}