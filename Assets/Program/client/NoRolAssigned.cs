namespace Program.client
{
    public class NoRolAssigned : Employee, IRole
    {

        public NoRolAssigned(string name, Seniority seniority) : base(name)
        {
            UpdateSalary( new Salary(BaseSalaryRepository.NO_ROL));
            UpdateRole(this);
        }
        
        public float BaseSalary() => Salary.BaseSalary;
        public float CurrentSalary() => Salary.CurrentSalary;
        public void CalculateIncrement() {}
    }
}