

namespace Program.client
{
    class program
    {
        private void Foo()
        {
            var engineer = new  Engineer("Cool Name", Seniority.CreateNewJunior(1));

            //todo make a new service to allow us update more easy the role and seniority
            engineer.UpdateRole( new Artist(engineer.Name, Seniority.CreateNewSenior(3) ) );
            engineer.UpdateSeniority( Seniority.CreateNewSenior(3) );

        }
    }
}