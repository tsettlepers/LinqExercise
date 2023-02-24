using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"The sum is {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"The average is {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            ListPrinter("The unsorted list", numbers);
            ListPrinter("Sorted ascending", numbers.OrderBy(x => x));

            //TODO: Order numbers in decsending order and print to the console
            ListPrinter("Sorted descending", numbers.OrderByDescending(x => x));

            //TODO: Print to the console only the numbers greater than 6
            ListPrinter("Subset > 6",numbers.Where(x => x > 6));

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            ListPrinter("Ascending, first 4 via LINQ", numbers.OrderBy(x => x).Take(4));
            Console.Write("Same group but using foreach loop as requested: {");
            int ctr = 0;
            foreach (int i in numbers.OrderBy(x => x))
                if (++ctr <= 4) Console.Write(i + ",");
            Console.WriteLine("}");

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 58;
            ListPrinter("Sorted descending including the old man", numbers.OrderByDescending(x => x));

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            ListPrinter("Raw list of employees", employees);
            ListPrinter("Sorted list of C's and S's", employees.Where(e => e.FirstName.StartsWith("C") || e.FirstName.StartsWith("S")).OrderBy(e => e.FirstName));

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            ListPrinter("Over 26 Club", employees.Where(e => e.Age>26).OrderBy(e => e.Age).ThenBy(e => e.FirstName), true);

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine();
            Console.WriteLine($"Total YOE: " + employees.Where(e => e.YearsOfExperience<=10).Where(e => e.Age>35).Sum(e => e.YearsOfExperience));
            Console.WriteLine($"Total YOE: " + employees.Where(e => e.YearsOfExperience <= 10).Where(e => e.Age > 35).Average(e => e.YearsOfExperience));

            //TODO: Add an employee to the end of the list without using employees.Add()
            var straggler = new Employee { FirstName = "Tom", LastName = "Settle", Age = 29, YearsOfExperience = 2 };
            employees.AddRange(new List<Employee> { straggler });
            ListPrinter("Expanded list", employees);

            Console.WriteLine();
            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion

        public static void ListPrinter(string heading, IEnumerable<int> coll)
        {
            string output = "{";
            foreach (var item in coll)
                output += item + ",";
            output += "}";
            Console.WriteLine();
            Console.WriteLine(heading + ": " + output.Replace(",}", "}"));
        }

        public static void ListPrinter(string heading, IEnumerable<Employee> emps, bool includeAge = false)
        {
            string output = "{";
            foreach (var item in emps)
                output += item.FullName + (includeAge ? $"({item.Age})" : "") + ", ";
            output += "}";
            Console.WriteLine();
            Console.WriteLine(heading + ": " + output.Replace(", }","}"));
        }

    }
}
