namespace Program.client
{
    public class SemiSenior : Seniority
    {
        internal SemiSenior(float seniorityMultiplier)
        {
            seniorityLabel = GetType().Name;
            shortSeniorityLabel = "Ssr.";

            SeniorityMultiplier = seniorityMultiplier;
        }

        

    }
}