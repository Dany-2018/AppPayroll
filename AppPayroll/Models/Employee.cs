using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppPayroll.Models
{
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("employee_name")]
        public string EmployeeName { get; set; }

        [JsonProperty("employee_salary")]
        public decimal EmployeeSalary { get; set; }

        [JsonProperty("employee_age")]
        public int EmployeeAge { get; set; }
        // Otros campos del empleado, si los hay

        // Propiedad calculada para el salario anual
        public decimal SalarioAnual => EmployeeSalary * 12;
    }

    public class ApiResponse
    {
        public List<Employee> Data { get; set; }
    }

    public class ApiResponseSearch
    {
        public string Status { get; set; }
        public Employee Data { get; set; }
    }
}