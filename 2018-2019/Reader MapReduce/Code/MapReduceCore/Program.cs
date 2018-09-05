using System;
using System.Collections.Generic;

namespace MapReduceCore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeTable =
            new List<Employee>(new Employee[]
            {
              new Employee(3952, "Frank", "Moses", 'M', 2500.50),
              new Employee(1403, "John", "Ford", 'M', 1200.50),
              new Employee(3433, "Michelle", "Brown", 'F', 3250.25),
              new Employee(3540, "Daniel", "Smith", 'M', 2500.50)
            });
            List<CompanyCar> carTable =
            new List<CompanyCar>(new CompanyCar[]
            {
              new CompanyCar("092592", "Mercedes SLK", 3952),
              new CompanyCar("168368", "Ford Focus", 3540)
            });
            IEnumerable<dynamic> result = 
              employeeTable.Map(e => new { Name = e.Name, Surname = e.Surname });
        }
    }
}
