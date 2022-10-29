using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

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

    public interface IPercentSalaryIncrementerRepository
    {
        IPercentSalaryIncrementer SelectSalaryIncrementer();
    }

    public class PercentEngineerSalaryIncrementer : IPercentSalaryIncrementer
    {
        // Engineering →    (10% Seniors, 7% Semi Seniors and 5% Juniors)
        private float JuniorModifier { get; } = 5f;
        private float SemiSeniorModifier { get; }= 7f;
        private float SeniorModifier { get; }= 10f;

        public Dictionary<int, float> PercentModifier => _percentModifier ??= Initialize();
        private Dictionary<int, float> _percentModifier { get; set; }
        private Dictionary<int, float> Initialize()
        {
            var output = new Dictionary<int, float>()
            {
                { typeof(Junior).GetHashCode(), JuniorModifier },
                { typeof(SemiSenior).GetHashCode(), SemiSeniorModifier },
                { typeof(Senior).GetHashCode(), SeniorModifier }
            };
            return output;
        }
    }
}