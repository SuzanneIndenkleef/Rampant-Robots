using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            string mode = "";
            Factory GameFactory;

            // Instruction
            Console.WriteLine("RAMPANT ROBOTS");
            Console.WriteLine("Use the wasd-keys to move the mechanic (M) " +
                "and try to oil all of the robots (R) in the factory!" + Environment.NewLine);

            // Set difficulty
            while (mode != "1" & mode != "2" & mode != "3")
            {
                Console.WriteLine("Choose 1 for Easy-Mode, 2 for Hard-Mode and 3 for Expert-Mode");
                mode = Console.ReadLine();
            }
            if (mode == "1")
            {
                GameFactory = new Factory(5, 5, 3, 10, true);
            }
            else if (mode == "2")
            {
                GameFactory = new Factory(10, 10, 5, 10, true);
            }
            else
            {
                GameFactory = new Factory(25, 25, 10, 10, true);
            }
            
            // Start game
            GameFactory.Run();

            // Close application
            Console.WriteLine("Press Enter to close");
            Console.ReadLine();
        }
    }
}

