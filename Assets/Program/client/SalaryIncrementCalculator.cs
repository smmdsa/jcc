using Codice.CM.SEIDInfo;

namespace Program.client
{
    public static class EmployeeIncrementExtension 
    {
        public static void CalculateEmployeeIncrement( this CEO employee) 
        {
            var ns = new Salary( employee.Salary.BaseSalary,employee.Salary.CurrentSalary * 2 );
            employee.UpdateSalary(ns);
        }

        private static IPercentSalaryIncrementerRepository _salaryIncrementerRepository;
        public static void CalculateEmployeeIncrementV2<T>(this T employee) where T : Employee
        {
            var seniority = employee.Seniority.GetType().GetHashCode();
            _salaryIncrementerRepository = new SalaryIncrementer<T>() ;
            var incrementer = _salaryIncrementerRepository.SelectSalaryIncrementer();
            var percent = 1 + (incrementer.PercentModifier[seniority] / 100);
            var newsSalary = new Salary( employee.Salary.BaseSalary,employee.Salary.CurrentSalary * percent );
            employee.UpdateSalary(newsSalary);
        }
    }
}
// 2. After separating all employees in different groups,
// it has been decided that in order to speed up the salary increment process,
// the percentage will vary depending on position and seniority.
//
//          Expected:
//
// The salary increment percentage is:
// Engineering →    (10% Seniors, 7% Semi Seniors and 5% Juniors)
// PMs →            (10% Seniors and 5% Semi Seniors)
// Design →         (7% Seniors and 4% Juniors)
// HR →             (5% Seniors, 2% Semi Seniors and 0.5% Juniors)
// Artist →         (5% Seniors and 2.5% Semi Seniors)
// One Ceo →        (100%)