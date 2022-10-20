namespace Program.client
{
    public class Senior : Seniority
    {
        internal Senior(float seniorityMultiplier)
        {
            seniorityLabel = GetType().Name;
            SeniorityMultiplier = seniorityMultiplier;
        }

    }
}