using System;
using NUnit.Framework;
using Program.client;

public class EditModeTests
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
    // You are working for a multinational company that has 251 employees around the globe.
    // In order to speed up the process of salary increments,
    // your boss wants you to develop a program that
    // groups each employee in different sections depending on their position (HR, Engineering, Artist, Design and PM). 
    //
    // In addition, employees should be ordered depending on current seniority (Junior, Semi Senior and Senior).
    //
    // Expected:
    //
    // In the company there are:
    //  20 HR → (5 Seniors, 2 Semi Seniors and 13 Juniors)
    // 150 Engineering → (50 Seniors, 68 Semi Seniors and 32 Juniors)
    //  25 Artist → (5 Seniors and 20 Semi Seniors)
    //  25 Design → (10 Seniors and 15 Juniors)
    //  30 PMs → (10 Seniors and 20 Semi Seniors)
    //   1 Ceo 
    
    // Base Requirement
    // Objects: Employee, Role, SalaryCalculator, EmployeeRepository, SalaryRepository
    
    
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
        designer.CalculateEmployeeIncrement();
        Assert.AreEqual( expectedSalary, (int)designer.Salary.CurrentSalary,
            $"Current {designer.Seniority.SeniorityLabel} had a Current Salary of {designer.Salary.CurrentSalary} and base salary of {designer.Salary.BaseSalary}");
    }
    

    //3. In addition, this company uses a standardized salary system, in which employees have the same salary depending on their seniority and position.
    //
    //Expected:
    //
    [TestCase(1500)]
    public void CreateANewSeniorHREmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new HumanResource("name", Seniority.CreateNewSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(1000)]
    public void CreateANewSSeniorHREmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new HumanResource("name", Seniority.CreateNewSemiSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(500)]
    public void CreateANewJuniorHREmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new HumanResource("name", Seniority.CreateNewJunior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    // For the given base salary:
    // HR →             $1500 Seniors,
    //                  $1000 Semi Seniors
    //                  500$ Juniors
    [TestCase(5000)]
    public void CreateANewSeniorEngineerEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new Engineer("name", Seniority.CreateNewSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(3000)]
    public void CreateANewSSeniorEngineerEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new Engineer("name", Seniority.CreateNewSemiSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(1500)]
    public void CreateANewJuniorEngineerEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new Engineer("name", Seniority.CreateNewJunior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    // Engineering →    $5000 Seniors
    //                  $3000 Semi Seniors
    //                  $1500 Juniors
    [TestCase(2000)]
    public void CreateANewSeniorArtistEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new Artist("name", Seniority.CreateNewSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(1200)]
    public void CreateANewSSeniorArtistEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new Artist("name", Seniority.CreateNewSemiSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }

    // Artist →         $2000 Seniors
    //                  $1200 Semi Seniors
    [TestCase(2000)]
    public void CreateANewSeniorDesignerEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new Designer("name", Seniority.CreateNewSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(800)]
    public void CreateANewJuniorDesignerEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new Designer("name", Seniority.CreateNewJunior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    // Design →         $2000 Seniors
    //                  $800 Juniors
    [TestCase(4000)]
    public void CreateANewSeniorProjectManagerEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new ProjectManager("name", Seniority.CreateNewSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(2400)]
    public void CreateANewSSeniorProjectManagerEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new ProjectManager("name", Seniority.CreateNewSemiSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    // PMs →            $4000 Seniors
    //                  $2400 Semi Seniors
    
    // One Ceo →        $20000
    [TestCase(20000)]
    public void CreateANewCEOEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new ChiefExecutiveOfficer("name", Seniority.CreateNewSenior());
        
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(80000)]
    public void CallTheExtensionMethodToCalculateTheSalaryIncrementBasedOnRoleAndSeniority_GetTheNewSalaryForCeo(float expectedSalary)
    {
        var employee = new ChiefExecutiveOfficer("name", Seniority.CreateNewSenior());
        employee.CalculateEmployeeIncrement();
        employee.CalculateEmployeeIncrement();
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(80000)]
    public void CallTheExtensionMethodToCalculateTheSalaryIncrementBasedOnRoleAndSeniorityTwoIncrementsTimes_GetTheNewSalaryForCeo(float expectedSalary)
    {
        var employee = new ChiefExecutiveOfficer("name", Seniority.CreateNewSenior());
        employee.CalculateEmployeeIncrement();
        employee.CalculateEmployeeIncrement();
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    
    // The resulting salary after increment should be: 
    //                  Do the math for each one.

}
