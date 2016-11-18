using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.model
{
    class Jugador
    {
        public String _Nombre;
        public int _ID;

        public Jugador (String Nombre, int ID)
        {
            this._Nombre = Nombre;
            this._ID = ID;
        }

        public String Nombe
        {
            get
            {
                return _Nombre;
            }
            set
            {
                _Nombre = value;
            }
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                ID = value;
            }
        }

               
        public override string ToString()
        {
            return "Jugador :"+_Nombre+ " ID: "+_ID;
        }
        



    }
}
