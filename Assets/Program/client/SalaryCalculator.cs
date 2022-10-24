

namespace Program.client
{
    public class SalaryCalculator : ISalaryCalculator
    {
        public Salary Calculate(Employee employee)
        {
            var salary = employee.Seniority.SeniorityMultiplier * employee.Role.BaseSalary();
            
            return new Salary(employee.Salary.BaseSalary, salary );;
        }
    }
}