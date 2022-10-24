using System.Collections.Generic;

namespace Program.client
{
    public class PercentHumanResourceSalaryIncrementer : IPercentSalaryIncrementer
    {
        // HR →             (5% Seniors, 2% Semi Seniors and 0.5% Juniors)
        public float JuniorModifier { get; } = 0f;
        private float SemiSeniorModifier { get; }= 0.5f;
        private float SeniorModifier { get; }= 5f;
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