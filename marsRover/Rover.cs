using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MickMarsRover
{
    public class Rover{
        private int _xPosition = 0;
        private int _yPosition = 0;
        private char _orientation = 'c';

        public Rover(int newXPosition, int newYPosition, char newOrientation){
            _xPosition = newXPosition;
            _yPosition = newYPosition;
            _orientation = newOrientation;
        }

        public void setPosition(int newXPosition, int newYPosition)
        {
            _xPosition = newXPosition;
            _yPosition = newYPosition;
        }

        public void setOrientation(char newOrientation){
            _orientation = newOrientation;
        }

        public char getOrientation(){
            return _orientation;
        }

        public int getX(){
            return _xPosition;
        }

        public int getY(){
            return _yPosition;
        }
    }
}
