using System;
using System.Collections.Generic;
using UnityEngine;

namespace Program.client.v2.components
{
    public class EmployeeRepositoryComponent : MonoBehaviour
    {
        private IEmployeeRepository _employeeRepository;

        private void Awake()
        {
            _employeeRepository = new EmployeeFromFakeDatabase();
        }

        public List<Employee> GetAll() => _employeeRepository.GetAll();
    }
}