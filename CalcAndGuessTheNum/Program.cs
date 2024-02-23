using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculatorAndGuessTheNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        RunCalculator();
                        break;
                    case 2:
                        RunGuessTheNumberGame();
                        break;
                    case 3:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n======= Console Application Menu =======");
            Console.WriteLine("1. Calculator");
            Console.WriteLine("2. Guess the Number Game");
            Console.WriteLine("3. Exit");
            Console.WriteLine("========================================");
        }

        static int GetUserChoice()
        {
            Console.Write("Enter your choice (1-3): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
                {
                    return choice;
                }
                else
                {
                    Console.Write("Invalid input. Enter a number between 1 and 3: ");
                }
            }
        }

        static void RunCalculator()
        {
            Console.WriteLine("\n======= Calculator =======");
            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Select operation (+, -, *, /): ");
            char operation = Convert.ToChar(Console.ReadLine());

            double result = 0;

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        Console.WriteLine("Error: Division by zero.");
                    break;
                default:
                    Console.WriteLine("Invalid operation.");
                    return;
            }

            Console.WriteLine($"Result: {result}");
        }

        static void RunGuessTheNumberGame()
        {
            Console.WriteLine("\n======= Guess the Number Game =======");

            // Generate a random number between 1 and 100
            Random random = new Random();
            int secretNumber = random.Next(1, 101);

            int attempts = 0;
            int guess;

            do
            {
                Console.Write("Enter your guess (1-100): ");

                while (!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 100)
                {
                    Console.Write("Invalid input. Enter a number between 1 and 100: ");
                }

                attempts++;

                if (guess < secretNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You guessed the correct number {secretNumber} in {attempts} attempts.");
                }

            } while (guess != secretNumber);
        }
    }
}
