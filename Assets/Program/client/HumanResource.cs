
namespace Program.client
{
    public class HumanResource : Employee, IRole
    {
        public HumanResource(string name, Seniority seniority) : base(name)
        {
            UpdateSalary( new Salary(BaseSalaryRepository.HR_BASE_SALARY));
            UpdateRole(this);
            UpdateSeniority(SeniorityFactory.CreateSeniorityFor(this, seniority));
            CalcInitialSalary();
        }
        
        public float BaseSalary() => Salary.BaseSalary;
        public float CurrentSalary() => Salary.CurrentSalary;
        public void CalculateIncrement() => this.CalculateEmployeeIncrementV2();
    }
}