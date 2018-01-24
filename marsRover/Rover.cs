using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MickMarsRover
{
    public class Rover
    {
        private int xPosition = 0;
        private int yPosition = 0;
        private char orientation = 'n';

        public void setPosition(int newXPosition, int newYPosition)
        {
            xPosition = newXPosition;
            yPosition = newYPosition;
        }
        public void getPosition()
        {
            Console.WriteLine(xPosition + " " + yPosition);
        }

        public void setOrientation(char newOrientation)
        {
            orientation = newOrientation;
        }

        public void getOrientation()
        {
            Console.WriteLine(orientation);
        }
       public char equalToOrientation()
        {
            return orientation;
        }
        public int getX()
        {
            return xPosition;
        }
        public int getY()
        {
            return yPosition;
        }

    }
}
