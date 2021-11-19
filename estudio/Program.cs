using System;
using System.Text;

namespace estudio
{

    class Program
    {

        static void PresentacionDeJuego()
        {
            System.Console.WriteLine("1. El programa pedirá que introduzcas el número de participantes a jugar.\n2. Cada participante tirará 3 veces un dado con valores entre 1 y 100 (electrónico se entiende),sumándose el valor de las 3 jugadas. Ganará el participante que obtenga mayor puntuación según las siguientes reglas:◦ Si el nº obtenido es múltiplo de 3 o de 5 sumara 10 pts.◦ Si el nº obtenido es múltiplo de 4 o de 6 sumara 5 pts.◦ Si el nº obtenido es mayor de 80 sumara 2 pts.◦ Si el nº obtenido es mayor de 50 sumar 1 pts.◦ Si el nº obtenido es menor de 50 restará 2 pts.◦ Si el nº obtenido es menor de 20 restará 1 pts.");
        }

        static int PideNumeroDeParticipanes()
        {
            System.Console.Write("Introduce numero de participantes");
            return int.Parse(Console.ReadLine());
        }

        static int TiradaDado()
        {
            Random tirada = new Random();
            return tirada.Next(1, 101);
        }
        static int CalculaPuntos(int tirada)
        {
             int puntos = 0;

                if (tirada % 3 == 0 || tirada % 5 == 0)
                    puntos += 10;
                if (tirada % 4 == 0 || tirada % 6 == 0)
                    puntos += 5;
                if (tirada > 50)
                    puntos++;
                if (tirada > 80)
                    puntos += 2;
                if (tirada < 50)
                    puntos -= 2;
                if (tirada < 20)
                    puntos--;

                
            return puntos;
        }
        static int JuegoParticipante(int participante)
        {
           
            const int TIRADAS_POR_PARTIDA = 3;
            int tirada;
            int contadorTirada = 1;
            int puntosJugada = 0;
            do
            {
                tirada = TiradaDado();
                puntosJugada += tirada;
                contadorTirada++;
            } while (contadorTirada < TIRADAS_POR_PARTIDA);
            puntosJugada = CalculaPuntos(puntosJugada);
            return puntosJugada;
        }

        static void MejorPuntuacionJuego(int nuemeroParticipantes)
        {
            int mejorJugador = 0;
            string texto = "";
            int puntuacionGanador = int.MinValue;
            int puntuacion = 0;
            for (int participante = 0; participante < nuemeroParticipantes; participante++)
            {
                puntuacion = JuegoParticipante(participante);
                if (puntuacion > puntuacionGanador)
                {
                    puntuacionGanador = puntuacion;
                    mejorJugador = participante;
                }

            }
            texto = $"Soy el jugadro {mejorJugador} y he ganado con {puntuacionGanador} puntos.";
            System.Console.WriteLine("________________________________________________________");
            System.Console.WriteLine(texto);
        }
        static void Main()
        {
            PresentacionDeJuego();
            int nuemeroParticipantes = PideNumeroDeParticipanes();
            MejorPuntuacionJuego(nuemeroParticipantes);
        }


    }
}
