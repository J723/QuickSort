# QuickSort

**Algoritmo QuickSort**

L&#39;idea di base di questo algoritmo ricorsivo è scegliere un elemento dall&#39;array ,definito pivot, e una volta scelto ciò spostare a destra e a sinistra tutti gli altri elementi dell&#39;array a seconda se sono più piccoli o più grandi del pivot.

Lo pseudocodice dell&#39;algoritmo è il seguente:

Procedure Quicksort(A)<br />
Input A, vettore a1, a2, a3 .. an<br />
&nbsp;&nbsp;begin<br />
&nbsp;&nbsp;&nbsp;&nbsp;if n ≤ 1 then return A<br />
&nbsp;&nbsp;&nbsp;&nbsp;else<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;begin<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;scegli un elemento pivot ak<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;calcola il vettore A1 dagli elementi ai di A tali che i ≠ K e ai ≤ ak<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;calcola il vettore A2 dagli elementi aj di A tali che j ≠ K e aj > ak<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A1 ← Quicksort(A1)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A2 ← Quicksort(A2)<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;return A1 · (ak) · A2;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;end<br />

La funzione che invece descrive lo spazio utilizzato è invece S(n) = O(n)

Il caso migliore che può capitare è un vettore dove il pivot è l&#39;elemento centrale e le due metà dell&#39;array sono perfettamente bilanciati di dimensione array/2 , e il tempo medio di esecuzione è O(nlogn).

E&#39; utile usare questo algoritmo quando si hanno molti dati da dover ordinare e infatti questo algoritmo divide un enorme &quot;problema&quot; in tanti piccoli sottoproblemi molto più semlici da dover ordinare.
