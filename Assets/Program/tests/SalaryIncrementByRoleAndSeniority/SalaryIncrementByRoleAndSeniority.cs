using NUnit.Framework;
using Program.client;

public class SalaryIncrementByRoleAndSeniority
{
[ SetUp ]
    public void Setup()
    {
        //_employeeRepository = Substitute.For<IEmployeeRepository>();
        //_salaryCalculator = Substitute.For<ISalaryCalculator>();
        //_baseSalaryRepository = Substitute.For<IBaseSalaryRepository>();
    }

    //clear memory after text exec
    [TearDown]
    public void TearDown()
    {
    }

    
    // 2. After separating all employees in different groups,
    // it has been decided that in order to speed up the salary increment process,
    // the percentage will vary depending on position and seniority.
    //
    //          Expected:
    //
    // The salary increment percentage is:
    // HR →             (5% Seniors, 2% Semi Seniors and 0.5% Juniors)
    // Engineering →    (10% Seniors, 7% Semi Seniors and 5% Juniors)
    // Artist →         (5% Seniors and 2.5% Semi Seniors)
    // Design →         (7% Seniors and 4% Juniors)
    // PMs →            (10% Seniors and 5% Semi Seniors)
    // One Ceo →        (100%)

    //because that role/seniority dont exist
    [TestCase(0)]
    public void CallTheExtensionMethodToCalculateTheSalaryIncrementBasedOnRoleAndSeniority_GetTheNewSalary(float expectedSalary)
    {
        var designer = new Designer("name", Seniority.CreateNewSemiSenior());
        designer.CalculateEmployeeIncrementV2();
        Assert.AreEqual( expectedSalary, (int)designer.Salary.CurrentSalary,
            $"Current {designer.Seniority.SeniorityLabel} had a Current Salary of {designer.Salary.CurrentSalary} and base salary of {designer.Salary.BaseSalary}");
    }
    [TestCase(0)]
    public void CallTheExtensionMethodToCalculateTheSalaryIncrementBasedOnRoleAndSeniority_GetTheNewSalaryForDesignerSenior(float expectedSalary)
    {
        var designer = new Designer("name", Seniority.CreateNewSenior());
        designer.CalculateEmployeeIncrementV2();
        Assert.AreNotEqual( expectedSalary, (int)designer.Salary.CurrentSalary,
            $"Current {designer.Seniority.SeniorityLabel} had a Current Salary of {designer.Salary.CurrentSalary} and base salary of {designer.Salary.BaseSalary}");
        var art = new Artist("name", Seniority.CreateNewSenior());
        designer.CalculateEmployeeIncrementV2();
        Assert.AreNotEqual( expectedSalary, (int)art.Salary.CurrentSalary,
            $"Current {art.Seniority.SeniorityLabel} had a Current Salary of {art.Salary.CurrentSalary} and base salary of {art.Salary.BaseSalary}");

        var en = new Designer("name", Seniority.CreateNewSenior());
        designer.CalculateEmployeeIncrementV2();
        Assert.AreNotEqual( expectedSalary, (int)en.Salary.CurrentSalary,
            $"Current {en.Seniority.SeniorityLabel} had a Current Salary of {en.Salary.CurrentSalary} and base salary of {en.Salary.BaseSalary}");

    }
    [TestCase(40000)]
    public void CallTheExtensionMethodToCalculateTheSalaryIncrementBasedOnRoleAndSeniority_GetTheNewSalaryForCeo(float expectedSalary)
    {
        var employee = new CEO("name");
        employee.CalculateEmployeeIncrement();
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(80000)]
    public void CallTheExtensionMethodToCalculateTheSalaryIncrementBasedOnRoleAndSeniorityTwoIncrementsTimes_GetTheNewSalaryForCeo(float expectedSalary)
    {
        var employee = new CEO("name");
        employee.CalculateEmployeeIncrement();
        employee.CalculateEmployeeIncrement();
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    
    // The resulting salary after increment should be: 
    //                  Do the math for each one.

}
