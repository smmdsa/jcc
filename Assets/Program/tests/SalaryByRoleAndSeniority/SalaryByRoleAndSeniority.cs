using NUnit.Framework;
using Program.client;

public class SalaryByRoleAndSeniority
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
    //3. In addition, this company uses a standardized salary system, in which employees have the same salary depending on their seniority and position.
    //
    //Expected:
    //
    // For the given base salary:
    // HR →             $1500 Seniors,
    //                  $1000 Semi Seniors
    //                  500$ Juniors
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
    // Engineering →    $5000 Seniors
    //                  $3000 Semi Seniors
    //                  $1500 Juniors
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
    // Artist →         $2000 Seniors
    //                  $1200 Semi Seniors
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

    // Design →         $2000 Seniors
    //                  $800 Juniors
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
    // PMs →            $4000 Seniors
    //                  $2400 Semi Seniors
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

    
    // One Ceo →        $20000
    [TestCase(20000)]
    public void CreateANewCEOEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new CEO("name");
        
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }

    
    // The resulting salary after increment should be: 
    //                  Do the math for each one.

}
