using System;
using System.Text;

namespace estudio
{

    class Program
    {

        static int PideFallos()
        {
            System.Console.Write("Introduce el número máximo de fallos: ");
            return int.Parse(Console.ReadLine());
        }
        static string PidePalabraSecreta()
        {
            System.Console.Write("Introduce la palabra a adivinar: ");
            return Console.ReadLine();
        }
        static void MuestraEstadoDeJuego(string palabraParcialmeteAcertada, ref string letrasFalladas)
        {

            System.Console.WriteLine("\nPalabra: " + palabraParcialmeteAcertada);
            System.Console.WriteLine("Fallos: " + letrasFalladas);

        }

        static bool EstaLetraEnLetras(char letra, string letras)
        {
            return letras.Contains(letra);
        }
        static bool EstaLetraEnLetrasAcertadas(char letra, string palabraParcialmenteAcertada)
        {
            return EstaLetraEnLetras(letra, palabraParcialmenteAcertada); ;
        }
        static bool EstaLetraEnletrasFalladas(char letra, ref string falladas)
        {
            return EstaLetraEnLetras(letra, falladas);
        }
        static bool EstaLetraEnLetrasIntroducidas(char letra, string palabraParcialmeteAcertada, ref string falladas)
        {
            //no se si devule ture o false
            return EstaLetraEnletrasFalladas(letra, ref falladas) || EstaLetraEnLetrasAcertadas(letra, palabraParcialmeteAcertada);
        }
        static char PideLetraNoRepetida(string palabraParcialmeteAcertada, ref string falladas, string palabraSecreta)
        {
            char letra;
            int i = 0;
            do
            {
                System.Console.Write("Introduce una letra: ");
                letra = Console.ReadKey().KeyChar;
                if(palabraSecreta.IndexOf(letra)==-1)
                falladas = falladas + letra;
                i++;

            } while (EstaLetraEnLetrasIntroducidas(letra, palabraParcialmeteAcertada, ref falladas));

            return letra;
        }
        static string AñadeLetrasALetrasAMostrar(char letra, string palabraSecreta, StringBuilder palabraParcialmeteAdivinada)
        {
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                if (palabraSecreta[i] == letra)
                    palabraParcialmeteAdivinada[i] = palabraSecreta[i];

            }
            return palabraParcialmeteAdivinada.ToString();
        }

        static void Jugar(string palabraSecreta, int fallos)
        {
            StringBuilder palabraParcialmenteAcertada = new StringBuilder(palabraSecreta);
            for (int i = 0; i < palabraSecreta.Length; i++)
            {
                palabraParcialmenteAcertada[i] = '_';
            }
            
            string palbraParcialmenteAcertada = "";
            string falladas = "";
            for (int i = 0; i < fallos && (palbraParcialmenteAcertada != palabraSecreta); i++)
            {
                char letra;
                MuestraEstadoDeJuego(palabraParcialmenteAcertada.ToString(), ref falladas);
                letra = PideLetraNoRepetida(palabraParcialmenteAcertada.ToString(), ref falladas,palabraSecreta);
                palbraParcialmenteAcertada = AñadeLetrasALetrasAMostrar(letra, palabraSecreta, palabraParcialmenteAcertada);
            }

            MuestraEstadoDeJuego(palabraParcialmenteAcertada.ToString(), ref falladas);


        }
        static void Main(string[] args)
        {
            string palabraSecreta = PidePalabraSecreta();
            int fallos = PideFallos();
            Jugar(palabraSecreta, fallos);



        }
    }
}
