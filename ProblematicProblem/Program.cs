using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
           
           static bool cont = true;
           static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        
        static void Main(string[] args)
        {
            Random rng = new Random();
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = true;
            var contResponse = Console.ReadLine().ToLower();


            if (contResponse.ToLower() != "yes")
            {
                Console.WriteLine("GoodBye!");
                return;
            }

            Console.WriteLine();

            Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                bool seeList = (Console.ReadLine().ToLower() == "sure") ? true : false;
                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    bool addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        addToList = (Console.ReadLine().ToLower() == "yes") ? true : false;
                    }
                }

            do
            {
                //Random activity generation starts here
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                //Storing a random number
                //rng.Next can take one param that will be 1 less than the specified number passed in
                int randomNumber = rng.Next(activities.Count);

                //Choosing a string from the list based on the random index                
                //This will be overridden every iteration
                string randomActivity = activities[randomNumber];

                //If wine tasting was chosen and they aren't of age, it will choose again
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    //The activity is removed so it will not be selected again
                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                //Print the activity and ask if it is acceptable if not acceptable we loop again.
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                contResponse = Console.ReadLine();
                if (contResponse.ToLower() != "redo")
                {
                    cont = false;
                }

            } while (cont);

        }

    }
    
}