using System.Collections.Generic;

namespace Program.client
{
    public class PercentDesignSalaryIncrementer : IPercentSalaryIncrementer
    {
        // Design →         (7% Seniors and 4% Juniors)
        public float JuniorModifier { get; } = 4f;
        private float SemiSeniorModifier { get; }= 0f;
        private float SeniorModifier { get; }= 7f;
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