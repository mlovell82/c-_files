using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MickMarsRover
{
    public class Grid{
        private static int _length = 0;
        private static int _width = 0;
      
        public static int getLength(){
            return _length;
        }

        public static int getWidth(){
            return _width;
        }

        public void setGridDimensions(int newWidth, int newLength){
            _width = newWidth;
            _length = newLength;
        }  
    }
}
