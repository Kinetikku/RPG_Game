using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace RPG
{
    /// <summary>
    /// Use this class to demonstate your understanding of C# and key programming
    /// concepts such as class inheritance, encapsulation and polymorphism. You are free to 
    /// decide what features to implement but you should discuss your ideas with the 
    /// module coordinator. 
    /// Possible suggestions include:
    /// - Creating a set of characters and game objects, randomising attribute values
    /// - Creating a console based GUI to allow the user to interact with the game character or objects
    /// - Implement training and levelling up mechanics
    /// - Implement combat mechanics
    /// - Implement RPG events such as encountering NPCs, enemies, puzzles or a shop
    /// - Building an outline text based RPG game with characters and an environment to explore
    /// 
    /// Remember to discuss all potential features with the module coordinator
    /// </summary>
    public class Game
    {
        int input;
        public void run()
        {
            bool nextSection = false;
            while (!nextSection)
            {
                Console.WriteLine("Welcome to BEWILDER\n");
                Console.WriteLine("1: Start");
                Console.WriteLine("2: Quit");

                if ((int.TryParse(Console.ReadLine(), out input)) && input == 1)
                {
                    input = 0;
                    Console.WriteLine("Your journey begins....");
                    Thread.Sleep(1500);
                    Console.Clear();
                    nextSection = true;
                }
                else if (input == 2)
                {
                    Environment.Exit(0);
                }
                else
                    Console.WriteLine("You must choose between 1 or 2...");
            }

            nextSection = false;

            while (!nextSection)
            {
                Console.WriteLine("You wake up in a forest. You hear foot steps approaching. What do you do?");
                Console.WriteLine("1: Wait for them to get closer...");
                Console.WriteLine("2: Hide...");

                if ((int.TryParse(Console.ReadLine(), out input)) && input == 1)
                {
                    input = 0;
                    Thread.Sleep(1500);
                    Console.Clear();
                    nextSection = true;
                }
                else if (input == 2)
                {
                    Environment.Exit(0);
                }
                else
                    Console.WriteLine("You must choose between 1 or 2...");
            }

            nextSection = false;

            while (!nextSection)
            {
                Console.WriteLine("You eagerly wait for the noises to get closer, a group of rough looking figures appear from behind the trees in front.");
                Console.WriteLine("They catch your gaze and ask if you are alone. They keep approaching you, you feel a strange feeling, what do you do?");
                Console.WriteLine("1: Ask them to stop approaching...");
                Console.WriteLine("2: Let them get closer...");

                if ((int.TryParse(Console.ReadLine(), out input)) && input == 1)
                {
                    input = 0;
                    Thread.Sleep(1500);
                    Console.Clear();
                    nextSection = true;
                }
                else if (input == 2)
                {
                    Environment.Exit(0);
                }
                else
                    Console.WriteLine("You must choose between 1 or 2...");
            }
        }
    }
}
