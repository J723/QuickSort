using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] vett = new int[10000];
            int somma = 0;
            for (int i = 0; i <= 10000; i++)
            {
                //Riempe il vettore con numeri random
                for (int c = 0; c < vett.Length; c++)
                {
                    vett[c] = r.Next(0, 99999);
                }

                QuickSort QS = new QuickSort();
                var watch = System.Diagnostics.Stopwatch.StartNew(); //Inizia il timer

                QS.sort(vett, 0, vett.Length - 1);

                watch.Stop(); //Stoppa il timer
                var elapsedMs = watch.ElapsedMilliseconds;

                somma = somma + Convert.ToInt32(elapsedMs);
                ////Stampa il vettore riordinato
                //for (int c = 0; c < vett.Length; c++)
                //{
                //    Console.WriteLine(vett[c]);
                //}
            }

            Console.WriteLine("Tempo medio impiegato: " + somma / 10000 + "ms");
            Console.ReadLine();
        }
    }
}
