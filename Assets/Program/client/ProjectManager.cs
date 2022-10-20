namespace Program.client
{
    public class ProjectManager : Employee, IRole
    {
        private int _seniorityMinSalary = 2400;
        private float _juniorModifier = 0f;
        private float _midModifier = 1f;
        private float _seniorModifier = 1.67f;
        
        public ProjectManager(string name, Seniority seniority) : base(name, seniority)
        {
            UpdateRole(this);
        }

        public float BaseSalary()
        {
            throw new System.NotImplementedException();
        }

        public float CurrentSalary()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateSalary(Salary salary)
        {
            throw new System.NotImplementedException();
        }
    }
}