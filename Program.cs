using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int studentNumber = 0;
            List<string> studentNames = new List<string>() { "Melodie", "Kathy", "Chris", "Frank", "Ethan", "Anthony", "John", "Tiffany", "Nick", "Julio" };
            List<string> favoriteFood = new List<string>() { "sushi", "cereal", "pizza", "noodles", "tacos", "chips", "chipotle", "rice", "broccoli", "yogurt" };
            List<string> hometown = new List<string>() { "New York", "Chicago", "San Francisco", "Washington, DC", "Boston", "Detroit", "Los Angeles", "Seattle", "Rochester", "Miami" };
            List<string> favoriteColor = new List<string>() { "Red", "Blue", "Green", "Yellow", "Purple", "Orange", "Brown", "Black", "White", "Teal", };

            bool repeat = true;//run program again
            while (repeat)
            {
                    //input
                    Console.WriteLine($"Welcome to our C# class. Would you like to learn(learn) about a student or add one(add)?");
                    userInput = Console.ReadLine();
                if (userInput == "add")
                {
                    Console.WriteLine("Please type in the name of the student.");
                    string userInput2 = Console.ReadLine();
                    studentNames.Add(userInput2);

                    Console.WriteLine("Please type in the student's favorite food.");
                    userInput2 = Console.ReadLine();
                    favoriteFood.Add(userInput2);

                    Console.WriteLine("Please type in the student's hometown.");
                    userInput2 = Console.ReadLine();
                    hometown.Add(userInput2);

                    Console.WriteLine("Please type in the student's favorite color.");
                    userInput2 = Console.ReadLine();
                    favoriteColor.Add(userInput2);
                }
                else if (userInput == "learn")
                {
                    int i = 0;
                    foreach (string elements in studentNames)
                    {
                        i++;
                        Console.WriteLine($"{i}." +elements);
                    }
                    Console.WriteLine("Welcome to our C# class. Which student would you like to learn more about?(Enter a number)");
                    userInput = Console.ReadLine();
                    while (!Regex.IsMatch(userInput, @"^\d{1,10}$"))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        userInput = Console.ReadLine();
                    }
                    studentNumber = int.Parse(userInput);
                }
                else
                {
                    repeat = Confirm("Invalid input! Would you like to run the program again?(y/n)");
                }
                for (int i = 0; i < studentNames.Count; i++)
                {
                    if (studentNumber - 1 == i)
                    {
                        Console.WriteLine("You chose:" + studentNames[studentNumber - 1]);
                        Console.WriteLine($"Would you like to know {studentNames[studentNumber - 1]}'s hometown, favorite food, or favorite color?");
                        string infoInput2 = Console.ReadLine().ToLower();

                        if (infoInput2 == "hometown")
                        {
                            Console.WriteLine($"{studentNames[studentNumber - 1]}'s hometown is {hometown[studentNumber - 1]}.");
                        }
                        else if (infoInput2 == "favorite food")
                        {
                            Console.WriteLine($"{studentNames[studentNumber - 1]}'s favorite food is {favoriteFood[studentNumber - 1]}");
                        }
                        else if (infoInput2 == "favorite color")
                        {
                            Console.WriteLine($"{studentNames[studentNumber - 1]}'s favorite color is {favoriteColor[studentNumber - 1]}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            
                        }
                    }
                }
                repeat = Confirm("Do you want to continue (y/n)?");
            }
        }
        public static bool Confirm(string message)//validation for restart program msg
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower() == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return Confirm(message);
            }
        }
    }
}