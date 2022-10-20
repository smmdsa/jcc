namespace Program.client
{
    public class Salary
    {
        internal float BaseSalary;
        public float CurrentSalary => _currentSalary;
        private float _currentSalary;

        public Salary(float currentSalary)
        {
            _currentSalary = currentSalary;
        }
    }
}