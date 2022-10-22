using NUnit.Framework;
using Program.client;
using UnityEngine;

public class EmployeeRepository
{
    private IEmployeeRepository _employeeRepository; 

    [ SetUp ]
    public void Setup()
    {
        _employeeRepository = new EmployeeFromFakeDatabase();
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
    [TestCase(251)]
    public void RequestForAllTheEmployee_GetATotalOf251Employees(int expectedSalary)
    {
        var all = _employeeRepository.GetAll();
        
        Assert.AreEqual( expectedSalary, all.Count);
    }

    [TestCase(1)]
    public void RequestForAllTheCEOEmployee_GetATotalOf150Employees(int expectedSalary)
    {
        var all = _employeeRepository.GetAll<ChiefExecutiveOfficer>(null);
        Assert.AreEqual( expectedSalary, all.Count);
    }
    [TestCase(150)]
    public void RequestForAllTheEngineerEmployee_GetATotalOf150Employees(int expectedSalary)
    {
        var all = _employeeRepository.GetAll<Engineer>(null);
        Assert.AreEqual( expectedSalary, all.Count);
    }
    [TestCase(25)]
    public void RequestForAllTheArtisEmployee_GetATotalOf150Employees(int expectedSalary)
    {
        var all = _employeeRepository.GetAll<Artist>(null);
        Assert.AreEqual( expectedSalary, all.Count);
    }
    [TestCase(20)]
    public void RequestForAllTheHREmployee_GetATotalOf150Employees(int expectedSalary)
    {
        var all = _employeeRepository.GetAll<HumanResource>(null);
        Assert.AreEqual( expectedSalary, all.Count);
    }
    [TestCase(20)]
    public void RequestForAllTheSemiSeniorsArtistEmployee_GetATotalOf150Employees(int expectedSalary)
    {
        var all = _employeeRepository.GetAllEmployeeBySeniority<Artist, SemiSenior>(null, null);
        Assert.AreEqual( expectedSalary, all.Count);
    }
    // The resulting salary after increment should be: 
    //                  Do the math for each one.

}
