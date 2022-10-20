namespace Program.client
{
    public interface IRole
    {
        float BaseSalary();
        float CurrentSalary();
        void UpdateSalary(Salary salary);
    }
}