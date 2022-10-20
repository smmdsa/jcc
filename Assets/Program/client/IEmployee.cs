namespace Program.client
{
    public interface IEmployee
    {
        string Name { get; }
        IRole Role { get;  }
        Seniority Seniority { get; }
    }
}