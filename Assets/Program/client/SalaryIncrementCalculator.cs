namespace Program.client
{
    public static class EmployeeIncrementExtension 
    {
        public static void CalculateEmployeeIncrement( this CEO employee) 
        {
            var ns = new Salary( employee.Salary.BaseSalary,employee.Salary.CurrentSalary * 2 );
            employee.UpdateSalary(ns);
        }
        public static void CalculateEmployeeIncrement( this Engineer employee)
        {
            var seniority = employee.Seniority.GetType().GetHashCode();
            var pesi = new PercentEngineerSalaryIncrementer();
            var percent = 1 + (pesi.PercentModifier[seniority] / 100);
            var ns = new Salary( employee.Salary.BaseSalary,employee.Salary.CurrentSalary * percent );
            employee.UpdateSalary(ns);
        }
        public static void CalculateEmployeeIncrement( this ProjectManager employee)
        {
            var seniority = employee.Seniority.GetType().GetHashCode();
            var ppmsi = new PercentProjectManagerSalaryIncrementer();
            var percent = 1 + (ppmsi.PercentModifier[seniority] / 100);
            var ns = new Salary( employee.Salary.BaseSalary,employee.Salary.CurrentSalary * percent );
            employee.UpdateSalary(ns);
        }
        public static void CalculateEmployeeIncrement( this HumanResource employee)
        {
            var seniority = employee.Seniority.GetType().GetHashCode();
            var phrsi = new PercentHumanResourceSalaryIncrementer();
            var percent = 1 + (phrsi.PercentModifier[seniority] / 100);
            var ns = new Salary( employee.Salary.BaseSalary,employee.Salary.CurrentSalary * percent );
            employee.UpdateSalary(ns);
        }
        public static void CalculateEmployeeIncrement( this Artist employee)
        {
            var seniority = employee.Seniority.GetType().GetHashCode();
            var pasi = new PercentArtistSalaryIncrementer();
            var percent = 1 + (pasi.PercentModifier[seniority] / 100);
            var ns = new Salary( employee.Salary.BaseSalary,employee.Salary.CurrentSalary * percent );
            employee.UpdateSalary(ns);
        }
        public static void CalculateEmployeeIncrement( this Designer employee)
        {
            var seniority = employee.Seniority.GetType().GetHashCode();
            var pdsi = new PercentDesignSalaryIncrementer();
            var percent = 1 + (pdsi.PercentModifier[seniority] / 100);
            var ns = new Salary( employee.Salary.BaseSalary,employee.Salary.CurrentSalary * percent );
            employee.UpdateSalary(ns);
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