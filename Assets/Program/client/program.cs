

namespace Program.client
{
    class program
    {
        private IEmployeeRepository employees; 
        private void Foo()
        {
            employees = new EmployeeFromFakeDatabase();

            var all = employees.GetAll();
            var allEng = employees.GetAll<Engineer>(null);
            var allSeniorArts = employees.GetAllEmployeeBySeniority<Artist,Senior>(null, null);

        }
    }
}