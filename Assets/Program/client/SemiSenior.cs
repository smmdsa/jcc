namespace Program.client
{
    public class SemiSenior : Seniority
    {
        internal SemiSenior(float seniorityMultiplier)
        {
            seniorityLabel = GetType().Name;

            SeniorityMultiplier = seniorityMultiplier;
        }

        

    }
}