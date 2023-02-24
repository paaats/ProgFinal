using System;
using System.Collections.Generic;

namespace Sison
{
    class Program
    {
        static List<string> currencies = new List<string>() { "USD", "EUR", "KRW", "JPY", "AUD", "GBP", "MXN", "MNT", "NGN", "RUB" };
        static List<double> currencyValues = new List<double>() { 0.020, 0.017, 22.98, 2.25, 0.026, 0.014, 0.40, 56.43, 8.11, 1.37 };

        static void guestMenu()
        {
            Console.WriteLine("Welcome to Login Page");
            Console.WriteLine("***********************");

            Console.WriteLine("*********MENU**********");
            Console.WriteLine("Enter 1 to Admin Login");
            Console.WriteLine("Enter 2 to Convert Currency");
            Console.WriteLine("Enter 3 to exit application");
            Console.WriteLine("_________________________");

            Console.Write(">> Enter your choice: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    adminLogin();
                    break;
                case "2":
                    convertPeso();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;

            }
        }

        static void adminLogin()
        {
            Console.WriteLine("\n_______LOGIN FORM_________");
            Console.Write("Enter username to Login:");
            string name;
            name = Console.ReadLine();
            Console.Write("Enter your password to continue:");
            string password;
            password = Console.ReadLine();

            if (name == "admin" && password == "1234")
            {
                Console.WriteLine("Login successfully");
                adminOptions();
            }
            else
            {
                Console.WriteLine("Username or Password is incorrect");
            }

        }

        static void convertPeso()
        {
            double php;
            string cur;
            //input peso
            Console.Write("Enter amount in PHP: ");
            php = Convert.ToDouble(Console.ReadLine());

            //options
            Console.Write("Chosse from");
            foreach (var curr in currencies)
            {
                Console.Write(" " + curr);
            }
            Console.Write("\nConvert PHP to: ");
            cur = Console.ReadLine().ToUpper();

            if (checker(cur))
            {
                Console.WriteLine($"PHP {php} = {php * currencyValues[currencies.IndexOf(cur)]} {cur}");

            }
            else
            {
                Console.WriteLine("Your input is not on the choices");

            }

        }

        static bool checker(string choice)
        {
            int found = currencies.IndexOf(choice);
            if (found == -1)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        static void adminOptions()
        {
            Console.WriteLine("Admin Page");
            Console.WriteLine("***********************");

            Console.WriteLine("*********MENU**********");
            Console.WriteLine("Enter 1 to Update Currency Value");
            Console.WriteLine("Enter 2 to Add Currency");
            Console.WriteLine("Enter 3 to go back to main menu");
            Console.WriteLine("_________________________");

            Console.Write(">> Enter your choice: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Write("Enter Currency to Change: ");
                    string toChange = Console.ReadLine().ToUpper();
                    if (checker(toChange))
                    {
                        Console.Write("Enter value(1 peso equivalent): ");
                        double newValue = Convert.ToDouble(Console.ReadLine());

                        currencyValues[currencies.IndexOf(toChange)] = newValue;

                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }

                    break;
                case "2":
                    Console.Write("Enter new Currency: ");
                    currencies.Add(Console.ReadLine().ToUpper());
                    Console.Write("Enter value(1 peso equivalent): ");
                    currencyValues.Add(Convert.ToDouble(Console.ReadLine()));
                    break;
                case "3":
                    guestMenu();
                    break;

            }
        }

        static void Main(string[] args)
        {
            do
            {
                guestMenu();
                Console.WriteLine("Do you want to continue using this application?");
                Console.WriteLine("Enter any key to continue or type no to exit");
                string answer;
                answer = Console.ReadLine();

                if (answer == "no")
                {
                    break;

                }
                else
                {
                    continue;
                }

            }
            while (true);
        }
    }
}
