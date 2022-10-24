namespace Program.client
{
    public class Junior : Seniority
    {
        internal Junior(float seniorityMultiplier)
        {
            seniorityLabel = GetType().Name;
            shortSeniorityLabel = "Jr.";

            SeniorityMultiplier = seniorityMultiplier;
        }

    }
}