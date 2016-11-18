using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.model
{
    class Game
    {
        private int _Puntaje;

        private Tablero _Board;

        private Jugador _Player1;

        private Jugador _Player2;


        public Tablero Tablero
        {
            get
            {
                return _Board;
            }
        }

            

        public Game(int filas, int columnas)
        {
            _Puntaje = 0;
            _Board = new Tablero(filas, columnas);



        }
           
        public int Puntaje
        {
            get
            {
                return _Puntaje;
            }
            set
            {
                if(value >=0)
                {
                    _Puntaje = value;
                }
            }
        }

        public Jugador Player1
        {
            get
            {
                return _Player1;
            }
            set
            {
                _Player1 = value;
            }
        }

        public Jugador Player2
        {
            get
            {
                return _Player2;
            }
            set
            {
                _Player2 = value;
            }
        }



        private void createBoard(int filas, int columnas, int Dificultad)
        {
            this._Board = new Tablero(filas,columnas);

        }

        public bool putShip(Ship s, Position p, int orientacion)
        {
            int X = p.x;
            int Y = p.y;
            int inicio;
            int final;
            int largoBarco = s.Largo-1;
            int anchoBarco = s.Ancho-1;

            if (s.Comandante == _Player1) //Le corresponde la mitad izquierda del tablero
            {
                inicio = 0;
                final = _Board.Columnas / 2; //Su tablero termina en la mitad de las columnas
            }
            else if (s.Comandante == _Player2) //Le corresponde la mitad derecha del tablero 
            {
                inicio = _Board.Columnas / 2; //Su tablero comienza en la mitad de las columnas
                final = _Board.Columnas;
            }
            else
            {
                return false; // Si el barco no es ni del jugador 1 ni del 2. No se puede posicionar
            }


            if (_Board.PartidaIniciada ==false && orientacion == 0) //Posicionamiento Vertical 
            {
                if (X >= 0 && Y >= inicio && (Y + anchoBarco) < final && (X + largoBarco) < _Board.Filas) //Se consulta si es que no viola las condiciones del tablero.
                {
                    //Se debe consultar si las posiciones que ocupen el largo del barco deben estar libres
                    while(largoBarco>=0)
                    {
                        if (_Board.Board[X, Y + anchoBarco] == '\0') //Si esta vacia continua preguntando 
                        {
                            largoBarco -= 1;
                        }
                        else
                        {
                            //No hay espacios a lo Largo (hacia abajo)
                            return false;
                        }

                    }
                    while(anchoBarco>=0)
                    {
                        if (_Board.Board[X + largoBarco, Y] == '\0') //Si esta vacia continua preguntando 
                        {
                            anchoBarco -= 1;
                        }
                        else
                        {
                            //No hay espacios a lo Ancho"
                            return false;
                        }
                    }

                    int AuxAncho = s.Ancho-1;
                    int AuxLargo = s.Largo-1;
                    int i;
                    int j;
                    for(i =0; i<=AuxAncho; i++)
                    {
                        for (j=0; j<=AuxLargo; j++)
                        {
                            _Board.Board[X+j, Y+i] = s.letra;
                            s.Posiciones.Add(new Position(X + j, Y + i));
                            //Posicionamiento en el tablero.
                            //_Board._List
                        }
                    }
                    if (s.Comandante == _Player1)
                    {
                        _Board.BarcosJugador += 1;
                        _Board.ListBarcosJugador.Add(s);
                    }
                    else if(s.Comandante == _Player2)
                    {
                        _Board.BarcosEnemigos += 1;
                        _Board.ListBarcosEnemigos.Add(s);
                    }
                    return true;

                }
                else
                {
                    //La posicion ingresada es incorrecta
                    return false;
                }

            }
            else if (_Board.PartidaIniciada == false && orientacion == 1)
            {
                if (X >= 0 && Y >= inicio && (X + anchoBarco) < _Board.Filas && (Y + largoBarco) < final) //Se consulta si es que no viola las condiciones del tablero.
                {
                    //Se debe consultar si las posiciones que ocupen el largo del barco deben estar libres
                    while (largoBarco >= 0)
                    {
                        if (_Board.Board[X + anchoBarco, Y] == '\0') //Si esta vacia continua preguntando 
                        {
                            largoBarco -= 1;
                        }
                        else
                        {
                            //No hay espacios a lo Largo (hacia abajo)
                            return false;
                        }
                    }
                    while (anchoBarco >= 0)
                    {
                        if (_Board.Board[X, Y + largoBarco] == '\0') //Si esta vacia continua preguntando 
                        {
                            anchoBarco -= 1;
                        }
                        else
                        {
                            //No hay espacios a lo Ancho
                            return false;
                        }
                    }

                    int AuxAncho = s.Ancho - 1;
                    int AuxLargo = s.Largo - 1;
                    int i;
                    int j;
                   
                    for (i = 0; i <= AuxAncho; i++)
                    {
                        for (j = 0; j <= AuxLargo; j++)
                        {
                            _Board.Board[X + i, Y + j] = s.letra;
                            s.Posiciones.Add(new Position(X + i, Y + j));
                            //Posicionando el barco en el tablero
                        }
                    }

                    if (s.Comandante == _Player1)
                    {
                        _Board.BarcosJugador += 1;
                        _Board.ListBarcosJugador.Add(s);
                    }
                    else if (s.Comandante == _Player2)
                    {
                        _Board.BarcosEnemigos += 1;
                        _Board.ListBarcosEnemigos.Add(s);
                    }

                    return true;

                }
                else
                {
                    //La posicion ingresada es incorrecta
                    return false;
                }
            }
            else
            {
                //No corresponde ni al posicionamiento horizontal ni vertical
                //O la partida ya comenzo, por lo cual no es posible seguir posicionando barcos
                return false;
            }



        }


        public bool play(Ship s, Position p)
        {
            if ( Math.Abs(_Board.BarcosEnemigos - _Board.BarcosJugador) <= 1  && _Board.PartidaIniciada == false)
            //Si la partida no ha comenzado, pero cumple las condiciones necesarias para comenzar, 
            //Se cambia El estado de la partida
            {
                _Board.PartidaIniciada = true;
            }

            if (_Board.PartidaIniciada && !_Board.PartidaFinalizada)
            // Si la partida ha comenzado y no ha terminado es posible efectuar jugadas
            {
                if (_Board.Board[p.x,p.y] != '\0' || _Board.Board[p.x, p.y] != 'X' || _Board.Board[p.x, p.y] != 'O' || _Board.Board[p.x, p.y] != '@')
                {
                    if (s.Comandante == _Player1) // El ataque lo efectua el jugador
                                                  //Entonces se debe revisar si el ataque dio en un barco del Enemigo
                    {
                        //Algoritmo de busqueda lineal.
                        //Para cada barco en la lista de barcos enemigos
                        foreach (Ship barco in _Board.ListBarcosEnemigos)
                            //Para cada posicion de ese barco
                            foreach (Position pos in barco.Posiciones)
                                //Si la posicion donde se esta atacando la posee un barco
                                if (p.Equals(pos))
                                {
                                    if (barco.Defensa == 0)
                                    {
                                        barco.Vida -= 1;
                                        if (barco.Vida == 0)
                                        {
                                            _Board.BarcosEnemigos -= 1;
                                            if (_Board.BarcosEnemigos == 0)
                                            {
                                                _Board.PartidaFinalizada = true;
                                            }
                                            _Board.Board[p.x, p.y] = 'O';
                                            return true;
                                        }
                                        else
                                        {
                                            _Board.Board[p.x, p.y] = 'X';
                                            return true;
                                        }
                                    }
                                    else if (barco.Defensa > 0)
                                    {
                                        barco.Defensa -= 1;
                                        _Board.Board[p.x, p.y] = 'Q';
                                        return true;
                                    }
                                }
                    }
                    else if (s.Comandante == _Player2) //El ataque lo efectua el enemigo
                                                       //Entonces se debe revisar si el ataque dio en un barco del Jugador
                    {
                        foreach (Ship barco in _Board.ListBarcosJugador)
                            foreach (Position pos in barco.Posiciones)
                                if (p.Equals(pos))
                                    if (barco.Defensa == 0)
                                    {
                                        barco.Vida -= 1;
                                        if (barco.Vida == 0)
                                        {
                                            _Board.BarcosJugador -= 1;
                                            if (_Board.BarcosJugador == 0)
                                            {
                                                _Board.PartidaFinalizada = true;
                                            }
                                            _Board.Board[p.x, p.y] = 'O';
                                            return true;
                                        }
                                        else
                                        {
                                            _Board.Board[p.x, p.y] = 'X';
                                            return true;
                                        }
                                    }
                                    else if (barco.Defensa > 0)
                                    {
                                        barco.Defensa -= 1;
                                        _Board.Board[p.x, p.y] = 'Q';
                                        return true;
                                    }
                                
                            
                                



                    }



                }


                
            }
            return false;
            
            
        }



    }
}
