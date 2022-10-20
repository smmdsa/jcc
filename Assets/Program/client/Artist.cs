
namespace Program.client
{
    public class Artist : Employee, IRole
    {

        public Artist(string name, Seniority seniority) : base(name)
        {
            UpdateSalary( new Salary(BaseSalaryRepository.ARTIST_BASE_SALARY));
            UpdateRole(this);
            UpdateSeniority(SeniorityFactory.CreateSeniorityFor(this, seniority));
            CalcInitialSalary();
        }
        
        public float BaseSalary() => Salary.BaseSalary;
        public float CurrentSalary() => Salary.CurrentSalary;
    }
}