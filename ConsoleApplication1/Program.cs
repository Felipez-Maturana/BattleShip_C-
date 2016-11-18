using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.model;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tablero T1 = new Tablero(4, 4);

            //Console.WriteLine(T1);
            //T1.imprimirBoard();


            

          

            //Console.WriteLine("-"+ char.GetNumericValue(T1.Board[0, 0]) + "-");

            Jugador J1 = new Jugador("FELIPE", 1);
            Jugador J2 = new Jugador("CPU", 0);

            Ship S1 = new Ship(1,J1);
            Ship S2 = new Ship(1,J2);
            Console.WriteLine(S1);

            /*
            List<Ship> ShipsJugador = new List<Ship>
            {
                new Ship(2,J1)
            };

            

            Console.WriteLine(ShipsJugador[0]);
            */


            Game G1 = new Game(5, 10);
            G1.Player1 = J1;
            G1.Player2 = J2;

            Position p = new Position(2, 2);
            Position p3 = new Position(2, 3);
            Position p4 = new Position(2, 3);
            Position p2 = new Position(4, 6);
            G1.putShip(S1, p, 0);
            G1.putShip(S2, p2, 0);

            G1.play(S2, p);
            G1.play(S2, p3);
            G1.play(S2, p4);

            G1.Tablero.imprimirBoard();

            Console.WriteLine(G1.Tablero.ListBarcosJugador[0]);
            //Console.WriteLine(G1.Tablero);
                


            Console.ReadLine();
        }
    }
}
