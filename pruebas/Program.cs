using System;
using System.Text;

namespace pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "pepe";
            StringBuilder sb=new StringBuilder(8);

            for (int i = 0; i < 8; i++)
            {
                sb[i]='*';
                System.Console.WriteLine(sb[i]);
            }
        }
    }
}
