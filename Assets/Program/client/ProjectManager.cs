
namespace Program.client
{
    public class ProjectManager : Employee, IRole
    {
        public ProjectManager(string name, Seniority seniority) : base(name)
        {
            UpdateSalary( new Salary(BaseSalaryRepository.PM_BASE_SALARY));
            UpdateRole(this);
            UpdateSeniority(SeniorityFactory.CreateSeniorityFor(this, seniority));
            CalcInitialSalary();
        }
        
        public float BaseSalary() => Salary.BaseSalary;
        public float CurrentSalary() => Salary.CurrentSalary;
    }
}