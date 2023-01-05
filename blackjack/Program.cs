using System;
using System.Collections;

namespace blackjack
{
    class Program : Modelo
    {
      public static double dineroApostado;
      public static double dineroObtenido;
        static void Main(string[] args)
        {

           Modelo mod = new Modelo();

            Console.WriteLine("Ingrese el nombre del jugador: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la cantidad de dinero a apostar: ");
            dineroApostado = int.Parse(Console.ReadLine());
            Console.WriteLine("No va mas: ");
            ArrayList numeros = new ArrayList();
            for (int i = 0; i <4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    numeros.Add(j);
                }
            }


            do
            {
                juegosTotales += 1;
                int v_jugador = Modelo.juego(nombre, numeros);
                int v_cupier = Modelo.crupier(numeros);
                verificaJuego(v_jugador, v_cupier, nombre);
                Console.WriteLine("Desea jugar otra partida? (SI/NO)");
            } while (Console.ReadLine()=="SI"||Console.ReadLine()=="si");
            Console.WriteLine($"Hubo un total de: {juegosTotales} juegos. Marcador--> {nombre} -> {juegos} - {gana} <- crupier");
            if (juegos==gana)
            {
                Console.WriteLine("Resultados");
            }
            else if(juegos>gana)
            {
                while(juegos>gana){
                    dineroObtenido = dineroApostado+100;
                }
               // dineroObtenido = dineroApostado+100;
                Console.WriteLine("Ganador definitivo", nombre);
                Console.WriteLine("Dinero obtenido:"+dineroObtenido);
                
            }
            else
            {
                 dineroObtenido = dineroApostado-100;
                Console.WriteLine("El crupier gana");
                 Console.WriteLine("Dinero obtenido:"+dineroObtenido);
            }

            Console.WriteLine("Fin del juego");
            Console.ReadKey();
        }

    }

}

