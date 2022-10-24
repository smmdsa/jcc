namespace Program.client.v2.database
{
    public class Employee
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public Role role { get; private set; }
        public Seniority seniority { get; private set; }
        public int salary;
    }
}