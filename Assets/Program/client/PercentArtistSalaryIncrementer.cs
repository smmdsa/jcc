using System.Collections.Generic;

namespace Program.client
{
    public class PercentArtistSalaryIncrementer : IPercentSalaryIncrementer
    {
        // Artist →         (5% Seniors and 2.5% Semi Seniors)
        public float JuniorModifier { get; } = 0f;
        private float SemiSeniorModifier { get; }= 2.5f;
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