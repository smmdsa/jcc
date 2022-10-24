using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Program.client
{
    public class EmployeeFromFakeDatabase : IEmployeeRepository
    {
        private List<Employee> Employees => _employees ??= _getEmployees();
        private List<Employee> _employees ;

        public EmployeeFromFakeDatabase()
        {
            _getEmployees();
        }
        public List<Employee> GetAll()=>Employees;
        
        public List<Employee> GetAll<T>( T em ) 
        {
            var rOutput = Employees.FindAll(e => 
                    e.GetType() == typeof(T)
                );
            return rOutput;
        }

        public List<Employee> GetAllEmployeeBySeniority<TE, TS>(TE em, TS seniority)
        {
            var rOutput = Employees.FindAll(e => 
                    e.GetType() == typeof( TE ) && e.Seniority.GetType() == typeof( TS )
                );
            return rOutput;
        }

        private List<Employee> _getEmployees() =>
            _CreateFakeEmployees();

        private List<Employee> _CreateFakeEmployees()
        {
            var employees = new List<Employee>();
            // 1 Ceo 
            var ceo = new CEO("CEO", Seniority.CreateNewSemiSenior());
            // 150 Engineering → 
            var engineer = _makeEngineers();
            // 25 Artist →       
            var art =_makeArtist();
            // 30 PMs →          
            var pms = _makePMs();
            // 25 Design →       
            var design = _makeDesigners();
            // 20 HR →           
            var hrs = _makeHRs();
            employees.AddRange(engineer);
            employees.AddRange(art);
            employees.AddRange(pms);
            employees.AddRange(design);
            employees.AddRange(hrs);
            employees.Add(ceo);
            return employees;
        }

        private List<Employee> _makeEngineers()
        {   // 150 Engineering →    (50 Seniors,    68 Semi Seniors and 32 Juniors)
            var employees = new List<Employee>();
            for (var i = 0; i < 50; i++)
                employees.Add(new Engineer($"Cool EngNameS #{i}", Seniority.CreateNewSenior()));
            for (var i = 0; i < 68; i++)
                employees.Add(new Engineer($"Cool EngNameSS #{i}", Seniority.CreateNewSemiSenior()));
            for (var i = 0; i < 32; i++)
                employees.Add(new Engineer($"Cool EngNameJ #{i}", Seniority.CreateNewJunior()));
            return employees;
        }   
        
        private  List<Employee> _makeArtist()
        {   // 25 Artist →          (5 Seniors and  20 Semi Seniors)
            var employees = new List<Employee>();
            for (var i = 0; i < 5; i++)
                employees.Add(new Artist($"Cool ArtisTNameS #{i}", Seniority.CreateNewSenior()));
            for (var i = 0; i < 20; i++)
                employees.Add(new Artist($"Cool ArtisTNameSS #{i}", Seniority.CreateNewSemiSenior()));
            return employees;
        }

        private List<Employee> _makePMs()
        {
            // 30 PMs →             (10 Seniors and 20 Semi Seniors)
            var employees = new List<Employee>();
            for (var i = 0; i < 10; i++)
                employees.Add(new ProjectManager($"Cool PMNameS #{i}", Seniority.CreateNewSenior()));
            for (var i = 0; i < 20; i++)
                employees.Add(new ProjectManager($"Cool PMNameSS #{i}", Seniority.CreateNewSemiSenior()));
            return employees;
            
        }

        private List<Employee> _makeDesigners()
        {   // 25 Design →          (10 Seniors and                     15 Juniors)
            var employees = new List<Employee>();
            for (var i = 0; i < 10; i++)
                employees.Add(new Designer($"Cool DesignerNameS #{i}", Seniority.CreateNewSenior()));
            for (var i = 0; i < 15; i++)
                employees.Add(new Designer($"Cool DesignerNameJ #{i}", Seniority.CreateNewJunior()));
            return employees;
        }

        private List<Employee> _makeHRs()
        {   // 20 HR →              (5 Seniors,     2  Semi Seniors   13 Juniors)
            var employees = new List<Employee>();
            for (var i = 0; i < 5; i++)
                employees.Add(new HumanResource($"Cool HRS #{i}", Seniority.CreateNewSenior()));
            for (var i = 0; i < 2; i++)
                employees.Add(new HumanResource($"Cool HRSS #{i}", Seniority.CreateNewJunior()));
            for (var i = 0; i < 13; i++)
                employees.Add(new HumanResource($"Cool HRJ #{i}", Seniority.CreateNewJunior()));
            return employees;
        }
    }
}

