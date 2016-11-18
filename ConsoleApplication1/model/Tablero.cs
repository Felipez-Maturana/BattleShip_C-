using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.model
{
    class Tablero
    {
        private int barcosEnemigos;
        private int barcosJugador;
        private int columnas;
        private int filas;
        //private int Dificultad;
        private bool partidaFinalizada;
        private bool partidaIniciada;

        private char[,] board;
        private Jugador ultimoJugador;

        private List<Ship> _ListBarcosJugador;
        private List<Ship> _ListBarcosEnemigos;



        public Tablero() //Constructor
        {
            filas = 5;
            columnas = 10;
            barcosEnemigos = 0; //Inicialmente no hay barcos de ningUn jugador
            barcosJugador = 0;
            //this.filas = filas;
            //this.columnas = columnas;
            board = new char[5, 10]; // matriz de dimensiOn filaxcolumnas 
            partidaFinalizada = false; //No ha finalzado la partida
            partidaIniciada = false; //No ha comenzado la partida

            _ListBarcosJugador = new List<Ship>();
            _ListBarcosEnemigos = new List<Ship>();

        }

        public Tablero (int filas, int columnas) //Constructor
        {
            if (filas >= 0 && columnas >= 0 && columnas%2 ==0) //Se verifica que la cantidad de columnas sea par y mayor que cero.
            {

                barcosEnemigos = 0; //Inicialmente no hay barcos de ningUn jugador
                barcosJugador = 0; 
                this.filas = filas;
                this.columnas = columnas;
                board = new char[filas, columnas]; // matriz de dimensiOn filaxcolumnas 
                partidaFinalizada = false; //No ha finalzado la partida
                partidaIniciada = false; //No ha comenzado la partida
                _ListBarcosJugador = new List<Ship>();
                _ListBarcosEnemigos = new List<Ship>();
            }
        }


        //Inicio de Propiedades (Property)
        public int BarcosEnemigos //set y get para Barcos enemigos
        {
            get
            {
                return barcosEnemigos;
            }
            set
            {
                if (value >= 0) //Se debe verificar que el valor sea mayor o igual que cero
                    barcosEnemigos = value;
            }
        }

        public int BarcosJugador //set y get para Barcos Jugador
        {
            get
            {
                return barcosJugador;
            }
            set
            {
                if (value >= 0) //Se debe verificar que el valor sea mayor o igual que cero
                    barcosJugador = value;
            }
        }

        public int Filas
        {
            get
            {
                return filas;
            }
        }

        public int Columnas
        {
            get
            {
                return columnas;
            }
        }

        public bool PartidaFinalizada
        {
            get
            {
                return partidaFinalizada; //Obtener el atributo
            }
            set //Cuando se quiera cambiar este atributo debe existir un ganador.
            {
                if ((barcosEnemigos == 0 && barcosJugador > 0) || (barcosJugador ==0 && barcosEnemigos >0))
                    //para que exista un ganador un jugador no debe poseer barcos, mientras que el otro debe tener al menos 1.
                {
                    if (partidaIniciada == true) //Ademas, la partida debe haber comenzado
                        //De lo contrario, puede haber un ganador mientras el jugador posiciona un barco.
                    {
                        partidaFinalizada = value;
                    }
                }
            }
        }

        public bool PartidaIniciada
        {
            get
            {
                return partidaIniciada; //obtener estado de la partida 
            }
            set
            {
                //Para no utilizar MATH.ABS se realizan mas verificaciones
                //Para dar una partida por iniciada, es necesario que la diferencia entre los barcos que posee cada jugador
                //no sea superior en a lo mAs una unidad.
                int diferencia1 = barcosEnemigos - barcosJugador; //
                int diferencia2 = barcosJugador - barcosEnemigos;
                if(barcosEnemigos>=1 && barcosJugador >=1)
                {
                    if( (diferencia1 <=1 && diferencia1 >=0) || (diferencia2 <=1 || diferencia2 >=0)  )
                    {
                        partidaIniciada = value;
                    }
           
                }
            }
        }


        public char [,] Board
        {
            get
            {
                return board;
            }
        }

        public Jugador UltimoJugador
        {
            get
            {
                return ultimoJugador;
            }
            set
            {
                ultimoJugador = value;
            }
        }

        public List<Ship> ListBarcosEnemigos
        {
            get
            {
                return _ListBarcosEnemigos;
            }
        }

        public List<Ship> ListBarcosJugador
        {
            get
            {
                return _ListBarcosJugador;
            }

        }

        

        
        //Fin propiedades

        //INICIO METODOS (Comportamientos)

        
        public void imprimirBoard()
        {
            int i, j;
            string boardSTR = "";

            for(i=0; i< filas; i++)
            {
                boardSTR += "|";
                for (j=0; j< columnas; j++)
                {
                    if (j== columnas/2)
                    {
                        boardSTR += "*|"; //Separador visual entre los dos tableros
                    }
                    boardSTR += board[i,j] + "|";
                }
                boardSTR += i+"\n";
            }

            boardSTR += " ";
            for (j=0; j<columnas; j++)
            {
                
                if (j== columnas/2)
                {
                    boardSTR += "  ";
                }
                boardSTR += j+" ";
            }
            boardSTR += "\n";

            Console.WriteLine(boardSTR);
        }
        


        public void ImprimirBarcos()
        {

        }


        public override string ToString()
        {
            string salida = "";
            salida += "Cantidad de barcos Enemigos: " + barcosEnemigos +"\n";
            salida += "Cantidad de Barcos Jugador: " + barcosJugador +"\n";
            salida += "Filas: " + filas + ", Columnas: " + columnas + "\n";
            salida += "Partida Finalziada: " + partidaFinalizada + ", Partida Comenzada: " + PartidaIniciada;

            foreach(Ship Barco in ListBarcosJugador)
            {
                Console.WriteLine(Barco);
            }


            return salida;
        }

    }
}
