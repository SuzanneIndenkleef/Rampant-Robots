using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Robot
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public bool Alive { get; set; }
        public int FactoryWidth { get; set; }
        public int FactoryHeight { get; set; }
        public bool PositionCheckUp, PositionCheckDown, PositionCheckLeft, PositionCheckRight;

        // Constructor
        public Robot(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Alive = true;
        }

        // Make the robot move in a certain direction: 1 stands for right, 2 for left, 3 for down and 4 for up
        public void Move(int movement)
        {
            if (movement == 1 & XPosition != FactoryWidth & PositionCheckRight)
            {
                XPosition++;
            }
            else if (movement == 2 & XPosition != 1 & PositionCheckLeft)
            {
                XPosition--;
            }
            else if (movement == 3 & YPosition != FactoryHeight & PositionCheckDown)
            {
                YPosition++;
            }
            else if (movement == 4 & YPosition != 1 & PositionCheckUp)
            {
                YPosition--;
            }
        }

        // When a robot is oiled, it will no longer be part of the game
        public void Oil()
        {
            Alive = false;
        }
    }
}
