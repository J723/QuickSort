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
            while (true)
            {
                int[][] arrayTosort = new int[3][]
                {
                    new int[20],
                    new int[20],
                    new int[20]
                };
                Random r = new Random();

                Console.WriteLine("Ordinamento array con algoritmo Quicksort\nArray Iniziale; valori da {0} a {1}, estremi inclusi\n", 0, 99999);
                //Riempimento casuale dell'array | numeri da 0 a 100
                for (int i = 0; i < arrayTosort[0].Length; i++)
                    arrayTosort[0][i] = r.Next(100000);

                //copie dell'array da ordinare (SENZA INDICIZZAZIONE)
                for (int i = 0; i < arrayTosort[0].Length; i++)
                    arrayTosort[1][i] = arrayTosort[0][i];

                //Controlla l'esattezza dell' algoritmo
                //
                Array.Sort(arrayTosort[1]);
                arrayTosort[2] = new QuickSort().Sort(arrayTosort[0]);

                bool equal = arrayTosort[1].SequenceEqual(arrayTosort[2]);
                Console.WriteLine("L'algoritmo {0}\nperò adesso ti consiglio di sederti comodo comodo che qui i calcoli da fare non sono pochi\ntorna tra qualche ora...", equal ? "funziona! :)" : "non funziona... :(");

                //Calcoli delle tempistiche e dell'efficienza
                long[] d1 = RunQuicksort();
                long[] d2 = RunArraySort();
                long[] data = new long[]
                {
                    d1[0],
                    d2[0],
                    d1[1],
                    d2[1],
                };

                WriteMenu(data);

                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void WriteArray(int[] array, bool vertical, string title)
        {
            Console.WriteLine(title);
            if (vertical)
            {
                Console.WriteLine("   ------>   ");
                for (int n = 0; n < array.Length; n++)
                {
                    if (n % 4 == 0)//   ogni 4 numeri va a capo
                        Console.Write("\n");
                    WriteNum(array[n]);
                }
            }
            else
            {
                for (int n = 0; n < array.Length; n++)
                {
                    WriteNum(array[n]);
                }
            }

        }      
        
        private static void WriteArray(int[][] array, bool vertical, string[] titles)
        {
            if (vertical)
            {
                Console.Write("\n");
                    
                //sceglie l'array più grande per il ciclo fondamentale
                int length = array[0].Length;
                foreach (Array a in array)
                    if (a.Length > length)
                        length = a.Length;

                //stampa i titoli
                List<int> indexes = new List<int>();
                for(int t = 0; t < array.Length; t++)
                {
                    Console.Write(titles[t]);
                    Console.SetCursorPosition(Console.CursorLeft + 5, Console.CursorTop);
                    indexes.Add(Console.CursorLeft);
                }
                Console.Write("\n");

                //inizializzazione indici dei singoli array
                int[] ind = new int[array.Length];
                for (int i = 0; i < ind.Length; i++)
                    ind[i] = 0;

                //stampa l'array incolonnandolo e ogni 4 numeri scrive una riga dell'altro
                for (int m = 0; m < length; m++)// numero di righe max
                {
                    for (int n = 0; n < array.Length; n++)// dove n rappresente il numero dell'array corrente | numero di colonne max
                    {
                        //stampa quattro numeri di un array
                        for (int a = 0; a < 4 && ind[n] < array[n].Length; ind[n]++, a++)// dove ind[n] rappresenta l'indice dell'array del ciclo corrente e 'a' rappresenta l'incremento di ind[n] durante il ciclo corrente
                            WriteNum(array[n][ind[n]]);
                        Console.SetCursorPosition(indexes[n], Console.CursorTop);
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int n = 0; n < array[i].Length; n++)
                        WriteNum(array[i][n]);
                    Console.Write(" - {0}\n", titles[i]);
                }
            }
        }    
        
        private static void WriteNum(int l)
        {
            if (l < 10)
                Console.Write("  {0}|", l);
            else if (l >= 100)
                Console.Write("{0}|", l);
            else
                Console.Write(" {0}|", l);
        }    

        private static void WriteMenu(long[] time)
        {
            Console.CursorVisible = false;
            Console.Write("\n");
            string[] e = new string[4];
            for (int i = 0; i < 4; i++)
            {
                if (time[i] < 1)
                    e[i] = "meno di un millisecondo";
                else
                    e[i] = time[i] + "ms";
            }

            int[] indexes = new int[2];
            Console.Write("Algorythm:                           ");
            indexes[0] = Console.CursorLeft;
            Console.Write("Array.Sort()                     ");
            indexes[1] = Console.CursorLeft;
            Console.Write("Quicksort\nTempo medio di esecuzione:");

            Console.SetCursorPosition(indexes[0], Console.CursorTop);
            Console.Write(e[1]);

            Console.SetCursorPosition(indexes[1], Console.CursorTop);
            Console.Write(e[0]);

            Console.Write("\nVarianza sul tempo:                       ");
            Console.SetCursorPosition(indexes[0], Console.CursorTop);
            Console.Write(e[3]);

            Console.SetCursorPosition(indexes[1], Console.CursorTop);
            Console.Write(e[2]);

            Console.Write("\n\n\n");
            if (time[0] < time[1] || time[3] < time[2])
                Console.WriteLine("Per qualche oscura stregoneria il metodo che ci propone la libreria di c# è il più efficiente...   :/");
            else
                Console.WriteLine("Grazie ad innumerervoli sacrifici di sangue ed alla stregoneria, il metodo Quicksort è risultato più efficiente");
        }

        private static long[] RunQuicksort()
        {
            int[] array = new int[10000];
            long[] times = new long[10000];
            long media = 0;
            double varianza = 0;
            QuickSort quick = new QuickSort();
            Random r = new Random();

            //esecuzione dei cicli
            for (int i = 0; i < times.Length; i++)
            {
                //riempimento
                for (int n = 0; n < 10000; n++)
                    array[n]= r.Next(100000);

                //ordinamento e conta
                var watch = System.Diagnostics.Stopwatch.StartNew();
                array = quick.Sort(array);
                watch.Stop();
                times[i] = watch.ElapsedMilliseconds;
            }

            //calcolo della media
            for (int i = 0; i < times.Length; i++)
                media += times[i];
            media /= times.Length;

            //calcolo dello scarto quadratico medio
            for (int i = 0; i < times.Length; i++)
                varianza += Math.Pow((times[i] - media), 2);
            varianza /= times.Length;

            varianza = Math.Sqrt(varianza);

            long[] results = new long[] { media, (long)varianza };
            return results;
        }

        private static long[] RunArraySort()
        {
            int[] array = new int[10000];
            long[] times = new long[10000];
            long media = 0;
            double varianza = 0;
            Random r = new Random();

            //esecuzione dei cicli
            for (int i = 0; i < times.Length; i++)
            {
                //riempimento
                for (int n = 0; n < 10000; n++)
                    array[n] = r.Next(100000);

                //ordinamento e conta
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Array.Sort(array);
                watch.Stop();
                times[i] = watch.ElapsedMilliseconds;
            }

            //calcolo della media
            for (int i = 0; i < times.Length; i++)
                media += times[i];
            media /= times.Length;

            //calcolo dello scarto quadratico medio
            for (int i = 0; i < times.Length; i++)
                varianza += Math.Pow((times[i] - media), 2);
            varianza /= times.Length;

            varianza = Math.Sqrt(varianza);

            long[] results = new long[] { media, (long)varianza };
            return results;
        }
    }
}
