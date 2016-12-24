using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class QuickSort : Sorting
    {
        public int[] Sort(int[] vett)
        {
            return Quicksort(vett.ToList()).ToArray();
        }

        //agisce NON modificando la lista parametro---->FUNZIONANTE
        private static List<int> Quicksort(List<int> ListToSort)
        {
            //caso base-->cella singola:ordinata
            if (ListToSort.Count() <= 1)
                return ListToSort;

            //assegna il pivot come elemento interno della lista
            int pivot = new Random().Next(ListToSort.Count());//    posizione della cella
            pivot = ListToSort[pivot];//    contenuto effettivo

            List<int> left_List = new List<int>();//   lista di elementi < di pivot
            List<int> right_List = new List<int>();//  lista di elementi > di pivot
            List<int> middle_List = new List<int>();//   lista di elementi == di pivot

            //Partiziona gli elementi in tre liste
            for (int i = 0; i < ListToSort.Count(); i++)
            {
                if (ListToSort[i] < pivot)
                    left_List.Add(ListToSort[i]);//    Lista di elementi < pivot
                else if (ListToSort[i] > pivot)
                    right_List.Add(ListToSort[i]);//   Lista di elementi > pivot
                else
                    middle_List.Add(ListToSort[i]);//    Lista di elementi == pivot
            }

            //assembla una lista composta da Left + middle + right chiamando ricorsivamente Left e Right
            List<int> merged_List = Quicksort(left_List);
            merged_List.AddRange(middle_List);
            merged_List.AddRange(Quicksort(right_List));

            return merged_List;//restituisce una lista ordinata
        }

        //agisce modificando la lista parametro----> NON FUNZIONANTE
        private static void Quicksort(List<int> ListToSort, int start, int end)
        {
            //caso base-->cella singola:ordinata
            if ((end - start) <= 1)
                return;

            //assegna il pivot come elemento interno della lista
            int pivot = new Random().Next(start, end);//    posizione della cella
            pivot = ListToSort[pivot];//    contenuto effettivo

            List<int> left_List = new List<int>();//   lista di elementi < di pivot
            List<int> right_List = new List<int>();//  lista di elementi > di pivot
            List<int> middle_List = new List<int>();//   lista di elementi == di pivot

            //Partiziona gli elementi in tre liste
            for (int i = start; i < end; i++)
            {
                if (ListToSort[i] < pivot)
                    left_List.Add(ListToSort[i]);//    Lista di elementi < pivot
                else if (ListToSort[i] > pivot)
                    right_List.Add(ListToSort[i]);//   Lista di elementi > pivot
                else
                    middle_List.Add(ListToSort[i]);//    Lista di elementi == pivot
            }

            //riassembla la lista iniziale = Left + middle + right
            //
            int index;//index per i tre cicli
            for (index = 0; index < left_List.Count; index++)//                                      <---monta la lista di sinistra
            {
                ListToSort[start + index] = left_List[index];
            }
            for (; index < middle_List.Count + start + left_List.Count; index++)//                    <---monta la lista centrale
            {
                ListToSort[start + index] = middle_List[index - start - left_List.Count];
            }
            for (; index < right_List.Count + start + left_List.Count + middle_List.Count; index++)// <---monta la lista di destra
            {
                ListToSort[start + index] = right_List[index - start - left_List.Count - middle_List.Count];
            }

            //Reitera ricorsivamente il ciclo
            Quicksort(ListToSort, start, left_List.Count);
            Quicksort(ListToSort, start + index - right_List.Count, end);
        }
    }
}
