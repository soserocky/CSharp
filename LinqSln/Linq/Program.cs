using System;

namespace MyLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "sabya";
            Console.WriteLine(s.FirstCaseUpper());

            //Writing a custom filter class as an extension method
            //Deferred Execution
            var ints1 = new List<int>() { 45, 67, 89, 90, 54 };
            var output1 = ints1.MyFilter<int>(x => x > 70).ToList();

            //Join
            var countries = new string[] { "India", "US", "UK", "Germany", "France", "Japan", "China", "Italy" };
            var output2 = string.Join("", countries);

            //Select
            var ints2 = new List<int>() { 1, 2, 3, 4, 5 };
            var output3 = ints2.Select(x => new { number = x, square = x * x, cube = x * x * x});

            //TakeWhile - Returns sequence of elements till the given condition is satisfied
            //Below example, output4 has only 1 element, i.e. 1, because the next number, 2, does not 
            //satisfy the given condition and the "TakeWhile" execution terminates there
            var ints3 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var output4 = ints3.TakeWhile(x => x % 2 > 0).ToList();

            //SkipWhile - Skips sequence of elements till the given condition is satisfied
            //Below example, output4 has 9 elements, i.e. {2, 3, 4, 5, 6, 7, 8, 9, 10},
            //because "2" does not satisfy the given condition and the "SkipWhile" execution terminates there
            var ints4 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var output5 = ints3.SkipWhile(x => x % 2 > 0).ToList();

            var employees = new List<Employee>();
            employees.Add(new Employee() { Id = 1, Company = "KPMG", Name = "Sabyasachi", Description = "P", City = "Bengaluru", Gender = "M"});
            employees.Add(new Employee() { Id = 2, Company = "KPMG", Name = "Amit", Description = "P", City = "Pune", Gender = "M" });
            employees.Add(new Employee() { Id = 3, Company = "KPMG", Name = "Mukesh", Description = "P", City = "Baroda", Gender = "M" });
            employees.Add(new Employee() { Id = 4, Company = "KPMG", Name = "Sanjay", Description = "P", City = "Mysore", Gender = "M" });
            employees.Add(new Employee() { Id = 5, Company = "KPMG", Name = "Shiva", Description = "T", City = "Bengaluru", Gender = "M" });
            employees.Add(new Employee() { Id = 6, Company = "CTS", Name = "Shiven", Description = "P", City = "Kolkata", Gender = "M" });
            employees.Add(new Employee() { Id = 7, Company = "EPAM", Name = "Dhruv", Description = "T", City = "Kolkata", Gender = "M" });
            employees.Add(new Employee() { Id = 8, Company = "BT", Name = "Shashank", Description = "T", City = "Bengaluru", Gender = "M" });
            employees.Add(new Employee() { Id = 9, Company = "Accion", Name = "Ravish", Description = "P", City = "Ranchi", Gender = "M" });
            employees.Add(new Employee() { Id = 10, Company = "PB", Name = "Rashi", Description = "P", City = "Ludhiana", Gender = "F" });

            var empByCity = employees.GroupBy(x => new { x.City, x.Gender})
                                     .OrderBy(x => x.Key.Gender)
                                     .ThenBy(x => x.Key.City);

            foreach (var item in empByCity)
            {
                Console.WriteLine($"City - {item.Key.City}, Gender - {item.Key.Gender}");
                foreach (var emp in item)
                {
                    Console.Write($"{emp.Name}, ");
                }
                Console.WriteLine();
            }


            var ints5 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var output6 = ints5.FirstOrDefault(x => x  > 10);



            Console.Read();
        }

    }
}
