namespace Program.client
{
    public class SemiSenior : Seniority
    {
        public SemiSenior(int seniorityMultiplier)
        {
            SeniorityMultiplier = seniorityMultiplier;
        }
        public SemiSenior()
        {
            SeniorityMultiplier = 2;
        }
        

    }
}