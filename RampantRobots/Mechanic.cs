using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RampantRobots
{
    class Mechanic
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public string Movements { get; set; }
        public int FactoryWidth;
        public int FactoryHeight;
        
        public Mechanic()
        {
            XPosition = 1;
            YPosition = 1;
            Movements = null;
        }

        public void Move(char movement)
        {
            if (movement == 'd' & XPosition != FactoryWidth)
            {
                XPosition++;
            }
            else if (movement == 'a' & XPosition != 1)
            {
                XPosition--;
            }
            else if (movement == 's' & YPosition != FactoryHeight)
            {
                YPosition++;
            }
            else if (movement == 'w' & YPosition != 1)
            {
                YPosition--;
            }            
        }

        public bool CheckMovements()
        {
            {
                foreach (var letter in Movements)
                {
                    if (letter != 'w' & letter != 'a' & letter != 's' & letter != 'd')
                        return false;
                }
                return true;
            }
        }
    }
}
