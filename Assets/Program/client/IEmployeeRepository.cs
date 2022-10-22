using System.Collections.Generic;

namespace Program.client
{
    public interface IEmployeeRepository
    {
        // this interface need to be implemented by the class going to
        // get the employee registry 
        List<Employee> GetAll();
        //TE : Artist, PM, Engineer, etc
        List<Employee> GetAll<T>(T _);
        
        //TE : Artist, PM, Engineer, etc
        List<Employee> GetAllEmployeeBySeniority<TE, TS>(TE em, TS seniority);
        
        
        
    }
    
    // public class EmployeesFromTEMPLATE : IEmployeeRepository
    // {
    //     public List<Employee> GetAll()
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public List<T> GetAll<T>()
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public List<TE> GetAllEmployeeBySeniority<TE>(Seniority seniority)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    // }
}