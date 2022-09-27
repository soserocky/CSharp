using System;

namespace MyLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string s = "sabya";
            //Console.WriteLine(s.FirstCaseUpper());

            ////Writing a custom filter class as an extension method
            ////Deferred Execution
            //var ints1 = new List<int>() { 45, 67, 89, 90, 54 };
            //var output1 = ints1.MyFilter<int>(x => x > 70).ToList();

            ////Join
            //var countries = new string[] { "India", "US", "UK", "Germany", "France", "Japan", "China", "Italy" };
            //var output2 = string.Join("", countries);

            ////Select
            //var ints2 = new List<int>() { 1, 2, 3, 4, 5 };
            //var output3 = ints2.Select(x => new { number = x, square = x * x, cube = x * x * x});

            ////TakeWhile - Returns sequence of elements till the given condition is satisfied
            ////Below example, output4 has only 1 element, i.e. 1, because the next number, 2, does not 
            ////satisfy the given condition and the "TakeWhile" execution terminates there
            //var ints3 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var output4 = ints3.TakeWhile(x => x % 2 > 0).ToList();

            ////SkipWhile - Skips sequence of elements till the given condition is satisfied
            ////Below example, output4 has 9 elements, i.e. {2, 3, 4, 5, 6, 7, 8, 9, 10},
            ////because "2" does not satisfy the given condition and the "SkipWhile" execution terminates there
            //var ints4 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var output5 = ints3.SkipWhile(x => x % 2 > 0).ToList();

            //var employees = new List<Employee>();
            //employees.Add(new Employee() { Id = 1, Department = "1", Name = "Sabyasachi", City = "Bengaluru", Gender = "M" });
            //employees.Add(new Employee() { Id = 2, Department = "2", Name = "Amit", City = "Pune", Gender = "M" });
            //employees.Add(new Employee() { Id = 3, Department = "3", Name = "Mukesh", City = "Baroda", Gender = "M" });
            //employees.Add(new Employee() { Id = 4, Department = "1", Name = "Sanjay", City = "Mysore", Gender = "M" });
            //employees.Add(new Employee() { Id = 5, Department = "2", Name = "Shiva", City = "Bengaluru", Gender = "M" });
            //employees.Add(new Employee() { Id = 6, Department = "3", Name = "Shiven", City = "Kolkata", Gender = "M" });
            //employees.Add(new Employee() { Id = 7, Department = "1", Name = "Dhruv", City = "Kolkata", Gender = "M" });
            //employees.Add(new Employee() { Id = 8, Department = "2", Name = "Shashank", City = "Bengaluru", Gender = "M" });
            //employees.Add(new Employee() { Id = 9, Department = "3", Name = "Ravish", City = "Ranchi", Gender = "M" });
            //employees.Add(new Employee() { Id = 10, Department = "1", Name = "Rashi", City = "Ludhiana", Gender = "F" });

            //var empByCity = employees.GroupBy(x => new { x.City, x.Gender})
            //                         .OrderBy(x => x.Key.Gender)
            //                         .ThenBy(x => x.Key.City);

            //foreach (var item in empByCity)
            //{
            //    Console.WriteLine($"City - {item.Key.City}, Gender - {item.Key.Gender}");
            //    foreach (var emp in item)
            //    {
            //        Console.Write($"{emp.Name}, ");
            //    }
            //    Console.WriteLine();
            //}


            //var ints5 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var output6 = ints5.FirstOrDefault(x => x  > 10);

            var employees2 = new List<Employee>();
            employees2.Add(new Employee() { Id = 1, Department = "1", Name = "Sabyasachi", City = "Bengaluru", Gender = "M" });
            employees2.Add(new Employee() { Id = 2, Department = "2", Name = "Amit", City = "Pune", Gender = "M" });
            employees2.Add(new Employee() { Id = 3, Department = "3", Name = "Mukesh", City = "Baroda", Gender = "M" });
            employees2.Add(new Employee() { Id = 4, Department = "1", Name = "Sanjay", City = "Mysore", Gender = "M" });
            employees2.Add(new Employee() { Id = 5, Department = "2", Name = "Shiva", City = "Bengaluru", Gender = "M" });
            employees2.Add(new Employee() { Id = 6, Department = "3", Name = "Shiven", City = "Kolkata", Gender = "M" });
            employees2.Add(new Employee() { Id = 7, Department = "1", Name = "Dhruv", City = "Kolkata", Gender = "M" });
            employees2.Add(new Employee() { Id = 8, Department = "2", Name = "Shashank", City = "Bengaluru", Gender = "M" });
            employees2.Add(new Employee() { Id = 9, Department = "3", Name = "Ravish", City = "Ranchi", Gender = "M" });
            employees2.Add(new Employee() { Id = 10,Department  = "1", Name = "Rashi", City = "Ludhiana", Gender = "F" });

            var departments = new List<Department>();
            departments.Add(new Department() { Id = 1, Name = "HR"});
            departments.Add(new Department() { Id = 2, Name = "IT" });
            departments.Add(new Department() { Id = 3, Name = "Payroll" });
            departments.Add(new Department() { Id = 4, Name = "Transport" });

            var empByDept = departments.GroupJoin(employees2,
                            d => d.Id.ToString(),
                            e => e.Department,
                            (d, e) => new { 
                               Employees = e,
                               Department = d
                            }
                ).ToList();

            foreach (var item in empByDept)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(item.Department.Name);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine(emp.Name);
                }
            }

            Console.Read();
        }

    }
}
