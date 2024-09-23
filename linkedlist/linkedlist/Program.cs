using ClassLibrary1;

namespace program
{
    class menu
    {
        static void Main(string[] args)
        {
            string[] menu = { "New", "Display", "Search", "Sort", "Exit" };
            int width = Console.WindowWidth / 2;
            int height = Console.WindowHeight / (menu.Length + 1);
            int Highlight = 0;
            bool flag = true;
            List<Class1.Employee> employees = new List<Class1.Employee>();  // Use List<Employee> 

            do
            {
                Console.Clear();
                for (int i = 0; i < menu.Length; i++)
                {
                    if (Highlight == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.SetCursorPosition(width, (i + 1) * height);
                    Console.Write(menu[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        Highlight--;
                        if (Highlight < 0) Highlight = menu.Length - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Highlight++;
                        if (Highlight >= menu.Length) Highlight = 0;
                        break;
                    case ConsoleKey.Home:
                        Highlight = 0;
                        break;
                    case ConsoleKey.End:
                        Highlight = menu.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        switch (Highlight)
                        { case 0: // New 
                                Console.Clear();
                                employees.Add(Class1.Employee.ReadInfo());
                                Console.WriteLine("Employee added successfully.");
                                Console.WriteLine("Enter any key to return to the main menu.");
                                Console.ReadLine();
                                break;

                            case 1: // Display 
                                Console.Clear();
                                if (employees.Count > 0)
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
                                break;

                            case 2: // Search by ID or Name
                                Console.Clear();
                                Console.WriteLine("Enter 1 to search by ID or 2 to search by Name:");
                                int searchOption = int.Parse(Console.ReadLine());
                                if (searchOption == 1)
                                {
                                    Console.Write("Enter Employee ID: ");
                                    int id = int.Parse(Console.ReadLine());
                                    var emp = employees.Find(e => e.ID == id);
                                    if (emp != null)
                                    {
                                        emp.DisplayData();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee not found.");
                                    }
                                }
                                else if (searchOption == 2)
                                {
                                    Console.Write("Enter Employee Name: ");
                                    string name = Console.ReadLine();
                                    var emp = employees.Find(e => e.Name == name);
                                    if (emp != null)
                                    {
                                        emp.DisplayData();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee not found.");
                                    }
                                }
                                Console.WriteLine("Enter any key to return to the main menu.");
                                Console.ReadLine();
                                break;

                            case 3: // Sort using IComparer<T>
                                Console.Clear();
                                Console.WriteLine("Sort by: 1. Name 2. ID 3. Salary");
                                int sortOption = int.Parse(Console.ReadLine());

                                if (sortOption == 1)
                                    employees.Sort(new EmployeeComparerByName());
                                else if (sortOption == 2)
                                    employees.Sort(new EmployeeComparerByID());
                                else if (sortOption == 3)
                                    employees.Sort(new EmployeeComparerBySalary());

                                Console.WriteLine("Employees sorted successfully.");
                                Console.WriteLine("Enter any key to return to the main menu.");
                                Console.ReadLine();
                                break;

                            case 4: // Exit
                                flag = false;
                                break;
                        }
                        break;
                }
            } while (flag);
        }
    }class EmployeeComparerByName : IComparer<Class1.Employee>
    {
        public int Compare(Class1.Employee x, Class1.Employee y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class EmployeeComparerByID : IComparer<Class1.Employee>
    {
        public int Compare(Class1.Employee x, Class1.Employee y)
        {
            return x.ID.CompareTo(y.ID);
        }
    }

    class EmployeeComparerBySalary : IComparer<Class1.Employee>
    {
        public int Compare(Class1.Employee x, Class1.Employee y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }
}