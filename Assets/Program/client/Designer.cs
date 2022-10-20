namespace Program.client
{
    public class Designer : Employee, IRole
    {
        private int _seniorityMinSalary = 800;

        private float _juniorModifier = 1f;
        private float _midModifier = 0f;
        private float _seniorModifier = 2.5f;
        public Designer(string name, Seniority seniority) : base(name, seniority)
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