using System;
using ClassLibrary1;

namespace day3
{
    class task2
    {
        static void Main(string[] args)
        {
            string[] menu = { "New", "Display", "Exit" };
            int width = Console.WindowWidth / 2;
            int height = Console.WindowHeight / (menu.Length + 1);
            int Highlight = 0;
            bool flag = true;
            Class1.Employee[] array = null;

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
                        {
                            case 0: // New 
                                Console.Clear();
                                Console.WriteLine("Enter the number of Employees you want to register:");
                                int size = int.Parse(Console.ReadLine());
                                array = new Class1.Employee[size];

                                for (int i = 0; i < array.Length; i++)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Enter the details for Employee {i + 1}:");
                                    array[i] = Class1.Employee.ReadInfo();
                                    Console.WriteLine($"The info of Employee {i + 1} was registered successfully.");
                                }

                                Console.WriteLine("Enter any key to return to the main menu.");
                                Console.ReadLine();
                                break;

                            case 1: // Display 
                                Console.Clear();
                                if (array != null)
                                {
                                    // Sort employees by name in descending order
                                    // array = array.OrderByDescending(e => e.Name).ToArray();
                                    
                                    // Sort employees by name in ascending order
                                    array = array.OrderBy(e => e.Name).ToArray();
                                    
                                    // Sort employees by salary in descending order
                                    // array = array.OrderByDescending(e => e.Salary).ToArray();
                                    
                                    //sort employees by salary in ascending order 
                                    // array = array.OrderBy(e => e.Salary).ToArray();
                                    
                                    //Sort employees by ege in descending order
                                    //array = array.OrderByDescending(e => e.Age).ToArray();
                                    
                                    //Sort employees by ege in ascending order
                                    //array = array.OrderBy(e => e.Age).ToArray(); 
                                    foreach (var employee in array)
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

                            case 2: // Exit
                                flag = false;
                                break;
                        }

                        break;
                }
            } while (flag);
        }
    }
}