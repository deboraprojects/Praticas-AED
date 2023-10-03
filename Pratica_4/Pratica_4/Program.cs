using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random ale = new Random();
            int[] crescente = new int[1000];
            int[] decrescente = new int[1000];
            int[] aleatorio = new int[1000];
            int ma, me;

            for (int i = 0; i < crescente.Length; i++)
            {
                crescente[i] = i+1;
                decrescente[i] = decrescente.Length - i;
                aleatorio[i] = ale.Next(1, 1000);
            }

            MaxMin.MaxMin1(crescente, out ma, out me);
            MaxMin.MaxMin2(crescente, out ma, out me);
            MaxMin.MaxMin3(crescente, out ma, out me);
            Console.WriteLine();

            MaxMin.MaxMin1(decrescente, out ma, out me);
            MaxMin.MaxMin2(decrescente, out ma, out me);
            MaxMin.MaxMin3(decrescente, out ma, out me);
            Console.WriteLine();

            MaxMin.MaxMin1(aleatorio, out ma, out me);
            MaxMin.MaxMin2(aleatorio, out ma, out me);
            MaxMin.MaxMin3(aleatorio, out ma, out me);
            Console.WriteLine();
            
            Console.ReadKey();
        }
    }
}
