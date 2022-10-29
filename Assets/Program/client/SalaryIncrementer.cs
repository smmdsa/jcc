using System.Collections.Generic;

namespace Program.client
{
    public class SalaryIncrementer<T> : IPercentSalaryIncrementerRepository where T : Employee
    {
        private Dictionary<int, IPercentSalaryIncrementer> SalaryIncrementers => _salaryIncrementers ??= InitializeSalaryIncrementer();
        private Dictionary<int, IPercentSalaryIncrementer> _salaryIncrementers;

        private static Dictionary<int,IPercentSalaryIncrementer> InitializeSalaryIncrementer()
        {
            var output = new Dictionary<int, IPercentSalaryIncrementer>
            {
                { typeof(Engineer).GetHashCode(), new PercentEngineerSalaryIncrementer() },
                { typeof(Artist).GetHashCode(), new PercentArtistSalaryIncrementer() },
                { typeof(Designer).GetHashCode(), new PercentDesignSalaryIncrementer() },
                { typeof(ProjectManager).GetHashCode(), new PercentProjectManagerSalaryIncrementer() },
                { typeof(HumanResource).GetHashCode(), new PercentHumanResourceSalaryIncrementer() }
            };
            return output;
        }

        public IPercentSalaryIncrementer SelectSalaryIncrementer() => SalaryIncrementers[ typeof(T).GetHashCode() ];
            
        
    }
}