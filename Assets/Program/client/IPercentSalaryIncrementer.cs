using System.Collections.Generic;

namespace Program.client
{
    public interface IPercentSalaryIncrementer
    {
        public Dictionary<int, float> PercentModifier { get; }
    }
}