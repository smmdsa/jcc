using System.Collections.Generic;

namespace Program.client
{
    public class PercentProjectManagerSalaryIncrementer : IPercentSalaryIncrementer
    {
        // PMs →            (10% Seniors and 5% Semi Seniors)
        public float JuniorModifier { get; } = 0f;
        private float SemiSeniorModifier { get; }= 5f;
        private float SeniorModifier { get; }= 10f;
        
        public Dictionary<int, float> PercentModifier => _percentModifier ??= Initialize();
        private Dictionary<int, float> _percentModifier { get; set; }
        private Dictionary<int, float> Initialize()
        {
            var output = new Dictionary<int, float>()
            {
                { typeof(SemiSenior).GetHashCode(), SemiSeniorModifier },
                { typeof(Senior).GetHashCode(), SeniorModifier }
            };
            return output;
        }
    }
}