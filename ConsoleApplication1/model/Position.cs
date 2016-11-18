using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.model
{
    class Position
    {
        private int _x;
        private int _y;

        public Position(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public override string ToString()
        {
            return "X: "+_x+" Y: "+_y;
        }


        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }


        public override bool Equals(object obj)
        {
            return (this._x == ((Position)obj).x && this._y == ((Position)obj).y);
        }



    }
}
