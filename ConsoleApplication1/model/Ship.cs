using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.model
{
    class Ship
    {
        private int ancho;
        private int defensa;
        private Jugador comandante;
        private int largo;
        private int tipoAtaque;
        private int vida;
        public char letra;
        private List<Position> _posiciones;

        //Constructor de Ship. Recibe el tipo de Barco que se crearA
        public Ship(int tipo, Jugador Comandante) //jugador duenho
        {
            if (tipo == 1) //Barco Normal
            {
                ancho = 3;
                defensa = 0;
                largo = 1;
                tipoAtaque = 0; //Ataque normal
                vida = ancho * largo;
                comandante = Comandante;
                letra = 'N';
                _posiciones = new List<Position>();

            }
            else if (tipo == 2) //Acorazado
            {
                ancho = 4;
                defensa = 2;
                largo = 1;
                tipoAtaque = 0; //Ataque normal
                vida = ancho * largo;
                comandante = Comandante;
                letra = 'A';
                _posiciones = new List<Position>();
            }
            else if (tipo == 3) //PortaAviones
            {
                ancho = 3;
                defensa = 0;
                largo = 1;
                tipoAtaque = 1; //Ataque En columna
                vida = ancho * largo;
                comandante = Comandante;
                letra = 'P';
                _posiciones = new List<Position>();
            }
            else if (tipo == 4) //Submarino
            {
                ancho = 3;
                defensa = 0;
                largo = 1;
                tipoAtaque = 2; //Ataque en 3x3
                vida = ancho * largo;
                comandante = Comandante;
                letra = 'S';
                _posiciones = new List<Position>();
            }
            else if (tipo == 5) //Buque de Guerra
            {
                ancho = 2;
                defensa = 0;
                largo = 2;
                tipoAtaque = 3; //Ataque por fila;
                vida = ancho * largo;
                comandante = Comandante;
                letra = 'B';
                _posiciones = new List<Position>();
            }

        }
        public int Ancho
        {
            get
            {
                return ancho;
            }
            set
            {
                if (value > 0)
                {
                    ancho = value;
                }
            }
        }

        public int Largo
        {
            get
            {
                return largo;
            }
            set
            {
                if (value > 0) //El largo debe ser mayor a 0.
                {
                    largo = value;
                }
            }
        }

        public int Vida
        {
            get
            {
                return vida;
            }
            set
            {
                if (value >= 0 && value <= ancho* largo) //La vida debe ser menor o igual a 0, y menor 
                {
                    vida = value;
                }
            }
        }

        public int Defensa
        {
            get
            {
                return defensa;
            }
            set
            {
                if (value >= 0)
                {
                    defensa = value;
                }                
            }
        }
        public int TipoAtaque
        {
            get
            {
                return tipoAtaque;
            }
            set
            {
                if (value > 0 && value <= 5) //El largo debe ser mayor a 0.
                {
                    tipoAtaque = value;
                }
            }
        }

        public Jugador Comandante
        {
            get
            {
                return comandante;
            }
        }

        public List<Position> Posiciones
        {
            get
            {
                return _posiciones;
            }
        }


        public void PrintPosiciones()
        {
            int L = Posiciones.Count;
            int i;
            string Salida = "";
            for(i=0; i<L; i++)
            {
                Salida += "Posicion :" + i + " X: " + Posiciones[i].x + " Y: " + Posiciones[i].y +" \n";
            }
            Console.WriteLine(Salida);
        }


        //Sobreescritura del metodo toString (de la clase Object)
        public override string ToString()
        {
            string salida = "";

            salida += "Ancho: " + ancho + "\n";
            salida += "Largo: " + largo + "\n";
            salida += "Vida: " + vida + "\n";
            salida += "Defensa: " + defensa + "\n";
            salida += "tipoAtaque: " + tipoAtaque + "\n";
            salida += "letra: " + letra + "\n";
            salida += "Comandante " + comandante.Nombe + "\n";

            int L = Posiciones.Count;
            int i;
            for (i = 0; i < L; i++)
            {
                salida += "Posicion :" + i + " X: " + Posiciones[i].x + " Y: " + Posiciones[i].y + " \n";
            }

            return salida;
        }

        




    

    }
}
