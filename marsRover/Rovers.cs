using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MickMarsRover
{
    class RoverLauncher{
        private List<Rover> _roverList = new List<Rover>();

        public void addRover(Rover newRover){
            _roverList.Add(newRover);
        }
       
        public List<Rover> getRoverList(){
            return _roverList;
        }

        public void deploy(string userDeployCommandString){
            var xAxis = "empty";
            var yAxis = "empty";
            var roverOrientation = 'c';
            var xStringDone = false;
            var yStringDone = false;

            foreach(char deployCommandCharacter in userDeployCommandString){
                if (deployCommandCharacter == ' '){
                    if (xStringDone){
                        yStringDone = true;
                    }
                    else{
                        xStringDone = true;
                    }
                }
                if (!xStringDone){
                    if (xAxis == "empty"){
                        xAxis = deployCommandCharacter.ToString();
                    }
                    else{
                        xAxis = xAxis + deployCommandCharacter;
                    }
                }
                if (xStringDone && !yStringDone){
                    if (yAxis == "empty"){
                        yAxis = deployCommandCharacter.ToString();
                    }
                    else{
                        yAxis = yAxis + deployCommandCharacter;
                    }
                }
                if (yStringDone){
                    var compassDirection = Char.ToUpper(deployCommandCharacter);
                    roverOrientation = compassDirection;
                }
            }
            if (inputIsValidInteger(xAxis, yAxis) && (inputIsValidOrientationCharacter(roverOrientation))){
                var width = Int32.Parse(xAxis);
                var length = Int32.Parse(yAxis);
                if (checkIfRoverOffOfGrid(width, length)){
                    Rover aNewRover = new Rover(width, length, roverOrientation);
                    addRover(aNewRover);
                }
                else{
                    Console.WriteLine("that location is off the grid, try again:");
                }
            }
            else{
                Console.WriteLine("Rover must be at a coordinate of 2 integers and a direction character with a space between, an example would be 5 4 N");
            }
        }

        public void locationChanger(string userCommandInput){
            if (verifyCommandInputIsValid(userCommandInput)){
                foreach (char command in userCommandInput){
                    var oldOrientation = _roverList[_roverList.Count - 1].getOrientation();
                    var oldXAxis = _roverList[_roverList.Count - 1].getX();
                    var oldYAxis = _roverList[_roverList.Count - 1].getY();

                    if (command == 'M'){
                        roverLocationChanger(oldOrientation, oldXAxis, oldYAxis);
                    }
                    roverOrientationChanger(oldOrientation, command);                    
                }
            }
        }
        
        public static bool inputIsValidInteger(string xAxis, string yAxis){
            var value = 0;
            return (int.TryParse(xAxis, out value) && int.TryParse(yAxis, out value));
        }

        public bool inputIsValidOrientationCharacter(char orientation){
            if(orientation == 'N' || orientation == 'S' || orientation == 'W' || orientation == 'E'){
                return true;
            }
            return false;
        }

        public bool verifyCommandInputIsValid(string theCommandList){
            var isTrue = true;
            foreach (char command in theCommandList){
                if (command != 'M' && command != 'L' && command != 'R'){
                    isTrue = false;
                }
            }
            if (!isTrue){
                Console.WriteLine("valid entries for movement are M R or L, try again:");
            }
            return isTrue;
        }

        public bool checkIfRoverOffOfGrid(int xLocation, int yLocation){
            var lengthWidthMinimum = 0;
            if (xLocation <= Grid.getWidth() && xLocation >= lengthWidthMinimum && yLocation <= Grid.getLength() && yLocation >= lengthWidthMinimum){
                return true;
            }
            return false;
        }

        public bool willTwoRoversCrash(int xLocation, int yLocation){
            foreach (Rover oldRover in _roverList){
                if (xLocation == oldRover.getX() && yLocation == oldRover.getY()){
                    return true;
                }
            }
            return false;
        }

        public void roverLocationChanger(char oldOrientation, int oldXAxis, int oldYAxis){
            var movementAmount = 1;
            if(oldOrientation == 'N' && (!willTwoRoversCrash(oldXAxis, (movementAmount + oldYAxis)) && checkIfRoverOffOfGrid(oldXAxis, (movementAmount + oldYAxis)))){
                _roverList[_roverList.Count - 1].setPosition(oldXAxis, (movementAmount + oldYAxis));
            }
            else if(oldOrientation == 'E' && (!willTwoRoversCrash((movementAmount + oldXAxis), oldYAxis) && checkIfRoverOffOfGrid((movementAmount + oldXAxis), oldYAxis))){
                _roverList[_roverList.Count - 1].setPosition((movementAmount + oldXAxis), oldYAxis);
            }
            else if(oldOrientation == 'S' && (!willTwoRoversCrash(oldXAxis, (oldYAxis - movementAmount)) && checkIfRoverOffOfGrid(oldXAxis, (oldYAxis - movementAmount)))){
                _roverList[_roverList.Count - 1].setPosition(oldXAxis, (oldYAxis - movementAmount));
            }
            else if(oldOrientation == 'W' && (!willTwoRoversCrash((oldXAxis - movementAmount), oldYAxis) && checkIfRoverOffOfGrid((oldXAxis - movementAmount), oldYAxis))){
                _roverList[_roverList.Count - 1].setPosition((oldXAxis - movementAmount), oldYAxis);
            }
            else{
                Console.WriteLine("with the last move you would collide with a rover or fall off the grid, try again:");
            }
        }

        public void roverOrientationChanger(char oldOrientation, char pivotCommand){
            if (oldOrientation == 'N' && pivotCommand == 'R'){
                _roverList[_roverList.Count - 1].setOrientation('E');
            }
            if (oldOrientation == 'N' && pivotCommand == 'L'){
                _roverList[_roverList.Count - 1].setOrientation('W');
            }
            if (oldOrientation == 'S' && pivotCommand == 'R'){
                _roverList[_roverList.Count - 1].setOrientation('W');
            }
            if (oldOrientation == 'S' && pivotCommand == 'L'){
                _roverList[_roverList.Count - 1].setOrientation('E');
            }
            if(oldOrientation == 'W' && pivotCommand == 'R'){
                _roverList[_roverList.Count - 1].setOrientation('N');
            }
            if(oldOrientation == 'W' && pivotCommand == 'L'){
                _roverList[_roverList.Count - 1].setOrientation('S');
            }
            if(oldOrientation == 'E' && pivotCommand == 'R'){
                _roverList[_roverList.Count - 1].setOrientation('S');
            }
            if(oldOrientation == 'E' && pivotCommand == 'L'){
                _roverList[_roverList.Count - 1].setOrientation('N');
            }
        }
    }
}
