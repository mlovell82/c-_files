using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MickMarsRover
{
    class Rovers
    {
        private List<Rover> roverList = new List<Rover>();


        public void addRover(Rover newRover)
        {
            roverList.Add(newRover);
        }

        public void roversInterface()
        {
           string inputLine;
            do
            {
                inputLine = Console.ReadLine();
                if (inputLine == "")
                    outputResult();
                else                
                    parseInterface(inputLine);                
            } while (inputLine != null);
        }
        public void parseInterface(string entry)
        {
            if (entry[0] != 'M' && entry[0] != 'R' && entry[0] != 'L')            
                deploy(entry);           
            else            
                locationChanger(entry);            
        }
        public void deploy(string input)
        {
            Rover mars = new Rover();
            addRover(mars);
            string xAxis = "empty", yAxis = "empty";
            char roverOrientation = 'e';
            bool xStringDone = false, yStringDone = false;

            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == ' ')
                {
                    if (xStringDone)
                    {
                        yStringDone = true;
                        ++i;
                    }
                    else
                    {
                        xStringDone = true;
                        ++i;
                    }
                }
                if (!xStringDone)
                {
                    //handler if input[i] is not an int
                    if (xAxis == "empty")
                    {
                        xAxis = input[i].ToString();
                    }
                    else
                    {
                        xAxis = xAxis + input[i];
                    }

                }
                if (xStringDone && !yStringDone)
                {
                    //handler if input[i] is not an int
                    if (yAxis == "empty")
                    {
                        yAxis = input[i].ToString();
                    }
                    else
                    {
                        yAxis = yAxis + input[i];
                    }
                }
                if (yStringDone)
                {
                    //handler for if input[i] is not n e s or w
                    roverOrientation = input[i];
                }

            }

            int width = Int32.Parse(xAxis);
            int length = Int32.Parse(yAxis);
            mars.setPosition(width, length);
            mars.setOrientation(roverOrientation);
        }
        public void locationChanger(string input)
        {
            foreach (char direction in input)
            {
                char oldOrientation = roverList[roverList.Count - 1].equalToOrientation();
                int oldXAxis = roverList[roverList.Count - 1].getX();
                int oldYAxis = roverList[roverList.Count - 1].getY();
                int movementAmount = 1;

                if (direction == 'M')
                {

                    if (oldOrientation == 'n')
                    {
                        roverList[roverList.Count - 1].setPosition(oldXAxis, (movementAmount + oldYAxis));
                    }
                    if (oldOrientation == 'e')
                    {
                        roverList[roverList.Count - 1].setPosition((movementAmount + oldXAxis), oldYAxis);
                    }
                    if (oldOrientation == 's')
                    {
                        roverList[roverList.Count - 1].setPosition(oldXAxis, (oldYAxis - movementAmount));
                    }
                    if (oldOrientation == 'w')
                    {
                        roverList[roverList.Count - 1].setPosition((oldXAxis - movementAmount), oldYAxis);
                    }
                }
                if (direction == 'R')
                {
                    if (oldOrientation == 'n')
                    {
                        roverList[roverList.Count - 1].setOrientation('e');
                    }
                    if (oldOrientation == 'e')
                    {
                        roverList[roverList.Count - 1].setOrientation('s');
                    }
                    if (oldOrientation == 's')
                    {
                        roverList[roverList.Count - 1].setOrientation('w');
                    }
                    if (oldOrientation == 'w')
                    {
                        roverList[roverList.Count - 1].setOrientation('n');
                    }
                }
                if (direction == 'L')
                {
                    if (oldOrientation == 'n')
                    {
                        roverList[roverList.Count - 1].setOrientation('w');
                    }
                    if (oldOrientation == 'e')
                    {
                        roverList[roverList.Count - 1].setOrientation('n');
                    }
                    if (oldOrientation == 's')
                    {
                        roverList[roverList.Count - 1].setOrientation('e');
                    }
                    if (oldOrientation == 'w')
                    {
                        roverList[roverList.Count - 1].setOrientation('s');
                    }
                }
            }
        }
        public void outputResult()
        {
            foreach (Rover entry in roverList)
            {
                entry.getPosition();
                entry.getOrientation();
            }
        }

    }

}
