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
        
        public List<Employee> GetAll()=>Employees;
        
        public List<Employee> GetAll<T>( T  em)
        {
            var rOutput = Employees.FindAll(e => 
                    e.GetType() == typeof( T )
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

        private List<Employee> _getEmployees()
        {
            var output = _CreateFakeEmployees();
            return output;
        }

        private static List<Employee> _CreateFakeEmployees()
        {
            var employees = new List<Employee>();
            _generateFakeEmployee(employees, 251);
            // 1 Ceo 
            var ceo = employees.First();
            ceo.UpdateRole(new ChiefExecutiveOfficer("CEO", Seniority.CreateNewSemiSenior()));
            // 150 Engineering → 

            var engineer = employees.Take(150).ToList();
            Debug.Log(employees.Count);
            Debug.Log(engineer.Count);
            _makeEngineers(engineer);

            // 25 Artist →       
            var art = employees.Take(25).ToList();
            _makeArtist(art);

            // 30 PMs →          
            var pms = employees.Take(30).ToList();
            _makePMs(pms);

            // 25 Design →       
            var design = employees.Take(25).ToList();
            _makeDesigners(design);

            // 20 HR →           
            var hrs = employees.Take(20).ToList();
            _makeHRs(hrs);

            var output = new List<Employee>(engineer);
            output.AddRange(art);
            output.AddRange(pms);
            output.AddRange(design);
            output.AddRange(hrs);
            output.Add(ceo);
            return output;
        }

        private static void _makeEngineers(List<Employee> employees)
        {
            // 150 Engineering →    (50 Seniors,    68 Semi Seniors and 32 Juniors)
            Debug.Log($"1.makeEng{employees.Count}");
            employees.GetRange(0, 49)
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName {e.GetHashCode()}", Seniority.CreateNewSenior()))
                );
            Debug.Log($"2.makeEng{employees.Count}");

            employees.GetRange(49, (68))
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName_{e.GetHashCode()}", Seniority.CreateNewSemiSenior()))
                );
            Debug.Log($"3.makeEng{employees.Count}");

            employees.GetRange((49 + 68), 32)
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName_{e.GetHashCode()}", Seniority.CreateNewJunior()))
                );
            Debug.Log($"4.makeEng{employees.Count}");

        }   
        
        private static void _makeArtist(List<Employee> employees)
        {
            // 25 Artist →          (5 Seniors and  20 Semi Seniors)

            employees.GetRange(0, 5)
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName {e.GetHashCode()}", Seniority.CreateNewSenior()))
                );
            employees.GetRange(4, 20)
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName_{e.GetHashCode()}", Seniority.CreateNewSemiSenior()))
                );
        }

        private static void _makePMs(List<Employee> employees)
        {
            // 30 PMs →             (10 Seniors and 20 Semi Seniors)

            employees.GetRange(0, 10)
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName {e.GetHashCode()}", Seniority.CreateNewSenior()))
                );
            employees.GetRange(9, 20)
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName_{e.GetHashCode()}", Seniority.CreateNewSemiSenior()))
                );
        }

        private static void _makeDesigners(List<Employee> employees)
        {
            // 25 Design →          (10 Seniors and                     15 Juniors)

            employees.GetRange(0, 10)
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName {e.GetHashCode()}", Seniority.CreateNewSenior()))
                );

            employees.GetRange((9), 15)
                .ForEach(e =>
                    e.UpdateRole(new Engineer($"Cool EngName_{e.GetHashCode()}", Seniority.CreateNewJunior()))
                );
        }

        private static void _makeHRs(List<Employee> employees)
        {
        // 20 HR →              (5 Seniors,     2  Semi Seniors   13 Juniors)
            employees.GetRange(0, 5)
                .ForEach(e =>
                    e.UpdateRole(new HumanResource($"Cool HRName_ {e.GetHashCode()}", Seniority.CreateNewSenior()))
                );
            employees.GetRange(4, ( 2 ))
                .ForEach(e =>
                    e.UpdateRole(new HumanResource($"Cool HRName_{e.GetHashCode()}", Seniority.CreateNewSemiSenior()))
                );
            employees.GetRange((4 + 2), 13)
                .ForEach(e =>
                    e.UpdateRole(new HumanResource($"Cool HRName_{e.GetHashCode()}", Seniority.CreateNewJunior()))
                );
        }

        private static void _generateFakeEmployee(List<Employee> output, int max)
        {
            for (var i = 0; i < max; i++)
                output.Add(new NoRolAssigned($"Wiki CodeName-#{i}", Seniority.CreateNewJunior()));
        }
        
    }
}

