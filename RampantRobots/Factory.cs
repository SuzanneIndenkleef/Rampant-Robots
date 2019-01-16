using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Factory
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Robots { get; set; }
        public int Turns { get; set; }
        public bool RobotsMove { get; set; }
        public Random Rnd = new Random();

        Mechanic Mechanic = new Mechanic();
        List<Robot> RobotList = new List<Robot>();
        Random rnd = new Random();

        //Constructor
        public Factory(int width, int height, int robots, int turns, bool robotsMove)
        {
            Width = width;
            Height = height;
            Robots = robots;
            Turns = turns;
            RobotsMove = robotsMove;

            BuildRobots();
        }

        // Build robots and save robots in RobotList
        public void BuildRobots()
        {
            for (int i = 0; i < Robots; i++)
            {
                int x = rnd.Next(1, Width + 1);
                int y = rnd.Next(1, Height + 1);
                while (!CheckPositions(x, y))
                {
                    x = rnd.Next(1, Width + 1);
                    y = rnd.Next(1, Height + 1);
                }
                Robot robot = new Robot(x, y)
                {
                    FactoryWidth = Width,
                    FactoryHeight = Height
                };
                RobotList.Add(robot);
            }
        }

        // Check if a specific position is free
        public bool CheckPositions(int x, int y)
        {
            foreach (var robot in RobotList)
            {
                if (robot.XPosition == x & robot.YPosition == y)
                    return false;
            }
            if (Mechanic.XPosition == x & Mechanic.YPosition == y)
            return false;

            return true;
        }

        // Draw factory
        public void Draw()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Turns left: " + Turns.ToString());
            sb.Append(Environment.NewLine);
            for (int j = 1; j <= Height; j++)
            {
                for (int i = 1; i <= Width; i++)
                {
                    // Insert an M for the position of the mechanic
                    if (Mechanic.XPosition == i & Mechanic.YPosition == j)
                    {
                        sb.Append(" M ");
                    }
                    // Insert an R for the position of a robot
                    else if (RobotList.Any(robot => robot.XPosition == i & robot.YPosition == j & robot.Alive))
                    {
                        sb.Append(" R ");
                    }
                    // Insert a dot for every empty position
                    else
                    {
                        sb.Append(" . ");
                    }                    
                }
                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString());
        }

        // Make the mechanic and the robots move
        public void Move()
        {
            Mechanic.FactoryWidth = Width;
            Mechanic.FactoryHeight = Height;
            foreach (var movement in Mechanic.Movements)
            {
                Mechanic.Move(movement);
                // If the mechanic bumps into a robot, the robot will be oiled
                foreach (var robot in RobotList)
                {
                    if (robot.XPosition == Mechanic.XPosition & robot.YPosition == Mechanic.YPosition & robot.Alive)
                    {
                        robot.Oil();
                        Robots--;
                    }
                }

                if (RobotsMove)
                    foreach (Robot robot in RobotList)
                    {
                        // Check the surrounding positions
                        robot.PositionCheckUp = CheckPositions(robot.XPosition, robot.YPosition - 1);
                        robot.PositionCheckDown = CheckPositions(robot.XPosition, robot.YPosition + 1);
                        robot.PositionCheckLeft = CheckPositions(robot.XPosition - 1, robot.YPosition);
                        robot.PositionCheckRight = CheckPositions(robot.XPosition + 1, robot.YPosition);
                        // Move the robot in a random direction
                        robot.Move(Rnd.Next(1, 5));
                    }
            }
        }

        // Run program
        public void Run()
        {
            while (Turns > 0 & Robots > 0)
            {
                Draw();
                Mechanic.Movements = Console.ReadLine().ToLower();             
                while (!Mechanic.CheckMovements())
                {
                    Console.WriteLine("Use the wasd-keys");
                    Mechanic.Movements = Console.ReadLine();
                }
                Move();              
                Turns--;
            }
            Draw();
            EndOfGame();            
        }

        // Show result at the end of the game
        public void EndOfGame()
        {
            if (Robots == 0)
            {
                Console.WriteLine("Congratulations, you won the game!");
            }
            else
            {
                Console.WriteLine("Goshdarnit, you lost the game...");
            }
        }
    }
}
