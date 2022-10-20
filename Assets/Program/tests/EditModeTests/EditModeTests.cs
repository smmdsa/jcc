using System.Collections;
using NUnit.Compatibility;
using NUnit.Framework;
using Program.client;
using UnityEngine.TestTools;

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

    [TestCase("Senior")]
    public void CreateANewSeniority_GetTheSeniorityExpectedS(string expectedSeniority)
    {
        var seniority =  Seniority.CreateNewSenior();
        Assert.AreEqual( expectedSeniority.ToUpper(), seniority.SeniorityLabel.ToUpper(),
            $"Current {seniority.SeniorityLabel} not match with expected seniority {expectedSeniority}");
    }
    [TestCase("Junior")]
    public void CreateANewSeniority_GetTheSeniorityExpectedJr(string expectedSeniority)
    {
        var seniority =  Seniority.CreateNewJunior();
        Assert.AreEqual( expectedSeniority.ToUpper(), seniority.SeniorityLabel.ToUpper(),
            $"Current {seniority.SeniorityLabel} not match with expected seniority {expectedSeniority}");
    }
    [TestCase("SemiSenior")]
    public void CreateANewSeniority_GetTheSeniorityExpectedSS(string expectedSeniority)
    {
        var seniority =  Seniority.CreateNewSemiSenior();
        Assert.AreEqual( expectedSeniority.ToUpper(), seniority.SeniorityLabel.ToUpper(),
            $"Current {seniority.SeniorityLabel} not match with expected seniority {expectedSeniority}");
    }
    [TestCase("SemiSenior")]
    public void CreateNewFullSeniorityWithRol_GetCorrectArtistSemiSenior(string expectedSeniority)
    {
        var seniority =  Seniority.CreateNewSemiSenior();
        var artist = new Artist("s", seniority);
        
        var finalSeniority =  SeniorityFactory.CreateSeniorityFor(artist, seniority);
        
        Assert.AreEqual( expectedSeniority.ToUpper(), finalSeniority.SeniorityLabel.ToUpper(),
            $"Current {seniority.SeniorityLabel} not match with expected seniority {expectedSeniority}");
    }
    
    [TestCase(1500)]
    public void CreateANewEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new HumanResource("name", Seniority.CreateNewSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    [TestCase(20000)]
    public void CreateANewCEOEmployee_GetTheInitialSalaryByRolAndSeniority(float expectedSalary)
    {
        var employee = new ChiefExecutiveOfficer("name", Seniority.CreateNewSenior());
        Assert.AreEqual( expectedSalary, (int)employee.Salary.CurrentSalary,
            $"Current {employee.Seniority.SeniorityLabel} had a Current Salary of {employee.Salary.CurrentSalary}");
    }
    //3. In addition, this company uses a standardized salary system, in which employees have the same salary depending on their seniority and position.
    //
    //          Expected:
    //
    // For the given base salary:
    // HR →             $1500 Seniors,
    //                  $1000 Semi Seniors
    //                  500$ Juniors
    
    // Engineering →    $5000 Seniors
    //                  $3000 Semi Seniors
    //                  $1500 Juniors
    
    // Artist →         $2000 Seniors
    //                  $1200 Semi Seniors
    
    // Design →         $2000 Seniors
    //                  $800 Juniors
    
    // PMs →            $4000 Seniors
    //                  $2400 Semi Seniors
    
    // One Ceo →        $20000
    
    // The resulting salary after increment should be: 
    //                  Do the math for each one.

}
