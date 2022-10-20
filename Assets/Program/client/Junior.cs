namespace Program.client
{
    public class Junior : Seniority
    {
        public Junior(int seniorityMultiplier)
        {
            SeniorityMultiplier = seniorityMultiplier;
        }
        public Junior()
        {
            SeniorityMultiplier = 1;
        }
    }
}