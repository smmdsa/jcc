using System.Runtime.CompilerServices;

namespace Program.client
{
    public abstract class Role 
    {
        private Salary _salary;
        private Seniority _seniority;
        private int _percentToIncrement;


        public float BaseSalary() => _salary.BaseSalary;
        public float CurrentSalary() => _salary.CurrentSalary;
        public void UpdateSalary(Salary salary)
        {
            _salary = salary;
        }
    }
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
//                  $1500 Juniors)
    
// Artist →         $2000 Seniors
//                  $1200 Semi Seniors
    
// Design →         $2000 Seniors
//                  $800 Juniors
    
// PMs →            $4000 Seniors
//                  $2400 Semi Seniors
    
// One Ceo →        $20000
    
// The resulting salary after increment should be: 
//                  Do the math for each one.