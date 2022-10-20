namespace Program.client
{
    public class ChiefExecutiveOfficer : Employee, IRole
    {
        private int _seniorityMinSalary = 20000;

        public ChiefExecutiveOfficer(string name, Seniority seniority) : base(name, seniority)
        {
            UpdateRole(this);
        }

        public float BaseSalary() => Salary.BaseSalary;

        public float CurrentSalary() => Salary.CurrentSalary;
        public void UpdateSalary(Salary salary) => _salary = salary;
    }
}