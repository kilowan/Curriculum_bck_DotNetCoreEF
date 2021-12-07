﻿using Incidences.Models.Employee;
using System.Collections.Generic;

namespace Incidences.Data
{
    public interface IEmployeeData
    {
        public Employee SelectEmployeeByDni(string dni);
        public Employee SelectEmployeeById(int id);
        public IList<Employee> SelectActiveEmployee();
        public bool UpdateEmployee(EmployeeDto employee, int? id);
        public bool InsertEmployee(EmployeeDto employee);
        public bool UpdateEmployee(int id);
    }
}
