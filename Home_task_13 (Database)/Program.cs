using System;

namespace CompanyDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CompanyContext())
            {
                context.Database.EnsureCreated();
                var departments = context.Departments.IncludeEmployees().ToList();
                Console.WriteLine("Список відділів:");
                foreach (var dept in departments)
                {
                    Console.WriteLine($"ID: {dept.Id}, Назва: {dept.Name}");
                    Console.WriteLine("Список співробітників:");
                    foreach (var emp in dept.Employees)
                    {
                        Console.WriteLine($"  ID: {emp.Id}, Ім'я: {emp.Name}");
                    }
                }

                var projects = context.Projects.IncludeEmployees().ToList();
                Console.WriteLine("Список проектів:");
                foreach (var proj in projects)
                {
                    Console.WriteLine($"ID: {proj.Id}, Назва: {proj.Name}");
                    Console.WriteLine("Список співробітників:");
                    foreach (var emp in proj.Employees)
                    {
                        Console.WriteLine($"  ID: {emp.Id}, Ім'я: {emp.Name}");
                    }
                }
            }
        }
    }
}