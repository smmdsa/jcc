namespace Program.client
{
    public abstract class Seniority
    {
        private float _seniorMultiplier;
        public float SeniorityMultiplier
        {
            get => _seniorMultiplier;
            set => _seniorMultiplier = value;
        }

    }
}