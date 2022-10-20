

namespace Program.client
{
    class program
    {
        private void Foo()
        {
            var engineer = new  Engineer("Cool Name", new SemiSenior());

            //todo make a new service to allow us update more easy the role and seniority
            engineer.UpdateRole( new Artist(engineer.Name, new Junior()) );
            engineer.UpdateSeniority(new Senior());

        }
    }
}