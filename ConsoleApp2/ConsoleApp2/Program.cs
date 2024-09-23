using System;
using System.Linq;
using ClassLibrary1;

namespace day3
{
    class Task2
    {
        static void Main(string[] args)
        {
            string[] menu = { "New", "Display", "Search", "Sort", "Exit" };
            int width = Console.WindowWidth / 2;
            int height = Console.WindowHeight / (menu.Length + 1);
            int highlight = 0;
            bool isRunning = true;
            Class1.Employee[] employees = null;

            while (isRunning)
            {
                DisplayMenu(menu, width, height, highlight);

                var keyPressed = Console.ReadKey().Key;
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        highlight = (highlight > 0) ? highlight - 1 : menu.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        highlight = (highlight < menu.Length - 1) ? highlight + 1 : 0;
                        break;
                    case ConsoleKey.Home:
                        highlight = 0;
                        break;
                    case ConsoleKey.End:
                        highlight = menu.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        HandleMenuSelection(menu[highlight], ref employees, ref isRunning);
                        break;
                }
            }
        }

        static void DisplayMenu(string[] menu, int width, int height, int highlight)
        {
            Console.Clear();
            for (int i = 0; i < menu.Length; i++)
            {
                Console.BackgroundColor = (i == highlight) ? ConsoleColor.Green : ConsoleColor.Black;
                Console.SetCursorPosition(width, (i + 1) * height);
                Console.Write(menu[i]);
                Console.ResetColor();
            }
        }

        static void HandleMenuSelection(string selectedOption, ref Class1.Employee[] employees, ref bool isRunning)
        {
            switch (selectedOption)
            {
                case "New":
                    RegisterEmployees(ref employees);
                    break;
                case "Display":
                    DisplayEmployees(employees);
                    break;
                case "Search":
                    SearchEmployee(employees);
                    break;
                case "Sort":
                    SortEmployees(ref employees);
                    break;
                case "Exit":
                    isRunning = false;
                    break;
            }
        }

        static void RegisterEmployees(ref Class1.Employee[] employees)
        {
            Console.Clear();
            Console.WriteLine("Enter the number of Employees you want to register:");
            int size = int.Parse(Console.ReadLine());
            employees = new Class1.Employee[size];

            for (int i = 0; i < employees.Length; i++)
            {
                Console.Clear();
                Console.WriteLine($"Enter the details for Employee {i + 1}:");
                employees[i] = Class1.Employee.ReadInfo();
                Console.WriteLine($"The info of Employee {i + 1} was registered successfully.");
            }

            Console.WriteLine("Enter any key to return to the main menu.");
            Console.ReadLine();
        }

        static void DisplayEmployees(Class1.Employee[] employees)
        {
            Console.Clear();
            if (employees != null && employees.Length > 0)
            {
                foreach (var employee in employees)
                {
                    employee.DisplayData();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No employee data available.");
            }

            Console.WriteLine("Enter any key to return to the main menu.");
            Console.ReadLine();
        }

        static void SearchEmployee(Class1.Employee[] employees)
        {
            if (employees == null || employees.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No employees available to search.");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("Search by (1) ID or (2) Name:");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the search value:");
            string search = Console.ReadLine();
            bool found = false;

            foreach (var employee in employees)
            {
                if ((choice == 1 && employee.ID == int.Parse(search)) || (choice == 2 && employee.Name == search))
                {
                    Console.WriteLine("Employee found:");
                    employee.DisplayData();
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("No employee found with the given criteria.");
            }

            Console.WriteLine("Enter any key to return to the main menu.");
            Console.ReadLine();
        }

        static void SortEmployees(ref Class1.Employee[] employees)
        {
            if (employees == null || employees.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("No employees available to sort.");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("Sort by: (1) Name, (2) Salary, (3) Age:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    employees = employees.OrderBy(e => e.Name).ToArray();
                    break;
                case 2:
                    employees = employees.OrderBy(e => e.Salary).ToArray();
                    break;
                case 3:
                    employees = employees.OrderBy(e => e.Age).ToArray();
                    break;
            }

            Console.WriteLine("Employees sorted successfully.");
            Console.WriteLine("Enter any key to return to the main menu.");
            Console.ReadLine();
        }
    }
}
