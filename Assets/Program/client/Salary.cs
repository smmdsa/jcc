namespace Program.client
{
    public class Salary
    {
        public float BaseSalary => _baseSalary;
        private float _baseSalary;
        public float CurrentSalary => _currentSalary;
        private float _currentSalary;
        public Salary(float baseSalary, float newSalary)
        {
            _currentSalary = newSalary;
            _baseSalary = baseSalary;
        }
        public Salary(float newSalary)
        {
            _currentSalary = newSalary;
            _baseSalary = newSalary;

        }
        public Salary()
        {
            _currentSalary = 0;
            _baseSalary = 0;

        }
    }
}