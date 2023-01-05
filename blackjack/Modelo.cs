using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace blackjack
{
    public class Modelo 
    {
        public static int numeroCartas = 53;
        public static int juegos = 0;
        public static int gana = 0;
        public static int juegosTotales = 0;
        public static double dineroApostado;
        public static double dineroObtenido;
   
    public enum cartas{
        Corazones, Diamantes, Picas, Trevoles
    }
    public enum valores{
        A = 1, Dos, Tres, Cuatro, Cinco, Seis, Siete, Ocho, Nueve, Diez, J, Q, K
    }

        

        public static int crupier(ArrayList numeros)
        {
          //Metodo rand que muestra 2 cartas y las quita del mazo.
            int suma = 0;
            Random random = new Random();
            int n = random.Next(numeroCartas--);         
            int primeraCarta = (int)numeros[n];
            numeros.RemoveAt(n);
            int m = random.Next(numeroCartas--);
            int segundaCarta = (int)numeros[m];
            numeros.RemoveAt(m);
            suma += primeraCarta + segundaCarta;       
            while (suma <= 15)
            {
                int aux = random.Next(numeroCartas--);
                suma += (int)(numeros[aux]);
                numeros.RemoveAt(aux);
            }
            return suma;//Devuelve el total de puntos de las cartas.
        }


        //Metodo juego


        public static int juego(string jugador,ArrayList numeros)
        {
            int suma = 0;
            Random random = new Random();
            int n = random.Next(numeroCartas--);
            int primeraCarta = (int)numeros[n];
            numeros.RemoveAt(n);
            int m = random.Next(numeroCartas--);
            int segundaCarta = (int)numeros[m];
            numeros.RemoveAt(m);
            suma += primeraCarta + segundaCarta;
            Console.Write($"{jugador}: Primera carta: {primeraCarta}\n segunda carta: {segundaCarta}\n");
            if (suma> 21)
            {
                Console.WriteLine($"{jugador} Has perdido =( ");
                return 1;
            }
            else
            {
                Console.WriteLine($"La suma de las cartas es de: {suma}");
                Console.WriteLine($"{jugador} desea tomar otra carta? (SI/NO)");
                while (Console.ReadLine() == "SI" || Console.ReadLine() == "si")
                {
                    int k = random.Next(numeroCartas--);
                    suma += (int)numeros[k];
                    Console.WriteLine($"La carta tomada por {jugador} es: {numeros[k]}, La suma es de: {suma}");
                    numeros.Remove(k);
                    Console.WriteLine($"{jugador} desea tomar otra carta? (SI/NO)");
                }
                if (suma == 21)
                {
                    Console.WriteLine($"{jugador} Has ganado =)");
                    SumaApuesta();
                    return 0;
                }
                else if(suma>21)
                {
                    Console.WriteLine($"{jugador} Has perdido =( ");
                    return 1;
                }
            }
            return suma;
        }


        //verifica


public static void verificaJuego(int verificaJugador,int verificaCrupier,string nombre)    
        {
            if (verificaJugador == 0)
            {
                Console.WriteLine($"El resultado del crupier es: {verificaCrupier}");
                if (verificaCrupier==21)
                {
                    Console.WriteLine("crupier gano");
                }

            }
            else if (verificaJugador == 1)
            {
                Console.WriteLine((verificaCrupier> 21)? $"El crupier tuvo {verificaCrupier}, ambos empataron.": $"El crupier tuvo {verificaCrupier}, o {nombre} perdio");
                gana += (verificaCrupier> 21)? 0: 1;
            }
            else
            {
                Console.WriteLine($"El crupier tuvo: {verificaCrupier}");
                if (verificaCrupier> 21)
                {
                    Console.WriteLine($"{nombre} gano");
                    juegos += 1;
                }
                else
                {
                    Console.WriteLine((verificaJugador> verificaCrupier)? $"{nombre} gano": (verificaJugador < verificaCrupier)? "crupier gano": "empataron");
                    juegos += (verificaJugador> verificaCrupier)? 1: 0;
                    gana += (verificaJugador <verificaCrupier)? 1: 0;
                }

            }
        }




  public static void SumaApuesta(){
         dineroObtenido = dineroApostado+100;
  }   




      
    }
}