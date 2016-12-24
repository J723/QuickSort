using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class QuickSort
    {
        //questa funzione mette nel posto corretto il pivot
        //elementi minori di pivot a sinistra
        //elementi maggiori di pivot a destra
        public int Partizionamento(int[]vett, int low, int high)
        {
            int temp;
            int pivot = vett[high];  //pivot = ultima cella del vettore
            int i = low - 1;  //index dell'elemento più piccolo
            for (int c=low; c <= high-1;c++) //confronta tutte le celle con il pivot
            {
                //Se l'elemento è piu piccolo o uguale del pivot
                if (vett[c] <= pivot)
                {
                    i++;

                    //swap dell'elemento corrente con l'elemento più piccolo
                    //trovato fino ad ora
                    temp = vett[i];
                    vett[i] = vett[c];
                    vett[c] = temp;
                }
            }
            //swap dell'elemento più piccolo + 1
            //con il pivot
            temp = vett[i + 1];
            vett[i + 1] = vett[high];
            vett[high] = temp;

            //viene restituita la posizione di pivot + 1
            return i + 1;
        }

        public void sort(int []vett, int low, int high)
        {
            if (low < high)
            {
                //viene determinata la corretta posizione di pivot
                int pivotPos = Partizionamento(vett, low, high);

                //ricorsivamente vengono riordinate le partizioni
                //precedenti e successive al pivot
                sort(vett, low, pivotPos - 1);
                sort(vett, pivotPos + 1, high);
            }
        }
    }
}
