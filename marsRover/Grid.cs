using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MickMarsRover
{
    public class Grid
    {
        private int length = 0;
        private int width = 0;

        public Grid(int enteredLength, int enteredWidth)
        {
            length = enteredLength;
            width = enteredWidth;
        }
        public void getSize()
        {
            Console.WriteLine("length = " + length + " width = " + width);
        }
        
        public void gridInterface()
        {
            string gridDimensionsEntry = Console.ReadLine();
            string xAxis = "empty", yAxis = "empty";
            bool xStringDone = false;
            
            for (int i = 0; i < gridDimensionsEntry.Length; ++i)
            {
                if(gridDimensionsEntry[i] == ' ')
                {
                    xStringDone = true;
                    ++i;
                }
                if(!xStringDone)
                {
                    //handler for if gridDimensionEntry[i] is not an int
                    if (xAxis == "empty")
                    {
                        xAxis = gridDimensionsEntry[i].ToString();
                    }
                    else
                    {
                        xAxis = xAxis + gridDimensionsEntry[i];
                    }

                }
                if (xStringDone)
                {
                    //handler for if gridDimensionEntry[i] is not an int
                    if (yAxis == "empty")
                    {
                        yAxis = gridDimensionsEntry[i].ToString();
                    }
                    else
                    {
                        yAxis = yAxis + gridDimensionsEntry[i];
                    }
                }

            }
            width = Int32.Parse(xAxis);
            length = Int32.Parse(yAxis);

        }

    }
}
