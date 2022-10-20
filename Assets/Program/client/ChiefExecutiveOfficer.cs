namespace Program.client
{
    public class ChiefExecutiveOfficer : Employee, IRole
    {
        public ChiefExecutiveOfficer(string name, Seniority seniority) : base(name)

        {
            UpdateSalary(new Salary(BaseSalaryRepository.CEO_BASE_SALARY));
            UpdateRole(this);
            UpdateSeniority(SeniorityFactory.CreateSeniorityFor(this, seniority));
            CalcInitialSalary();
        }

        public float BaseSalary() => Salary.BaseSalary;
        public float CurrentSalary() => Salary.CurrentSalary;
    }
}