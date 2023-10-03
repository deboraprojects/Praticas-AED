using System.Threading;
using System.Windows.Forms;

namespace Pratica5 {
    class OrdenacaoGrafica {
        // TODO: declarar demais métodos de ordenação
        public static void Bolha(int[] vet, Panel p) {
            int i, j, temp;
            for (i = 0; i < vet.Length - 1; i++) {
                for (j = vet.Length - 1; j > i; j--) {
                    if (vet[j] < vet[j - 1]) {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                    }
                }
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(10); // espera 10 milisegundos

                if(vet.Length > 500)
                {
                    p.Invalidate(); // redesenha o painel
                    Thread.Sleep(1); // espera 10 milisegundos
                }
            }
        }

        public static void selecao(int[] vet, Panel p)
        {
            int i, j, min, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < vet.Length; j++)
                {
                    if (vet[j] < vet[min])
                    {
                        min = j;
                    }
                }
                temp = vet[i];
                vet[i] = vet[min];
                vet[min] = temp;
                p.Invalidate(); 
                Thread.Sleep(10);

                if (vet.Length > 500)
                {
                    p.Invalidate(); // redesenha o painel
                    Thread.Sleep(1); // espera 10 milisegundos
                }

            }
        }

        public static void insercao(int[] vet, Panel p)
        {
            int temp, i, j;
            for (i = 1; i < vet.Length; i++)
            {
                temp = vet[i];
                j = i - 1;
                p.Invalidate();
                Thread.Sleep(10);
                if (vet.Length > 500)
                {
                    p.Invalidate(); // redesenha o painel
                    Thread.Sleep(1); // espera 10 milisegundos
                }
                while (j >= 0 && temp < vet[j])
                {
                    vet[j + 1] = vet[j];
                    j--;
                }
                vet[j + 1] = temp;
            }
        }

        public static void shellSort(int[] vet, Panel p)
        {
            int i, j, x, n;
            int h = 1;
            n = vet.Length;
            do
            {
                h = h * 3 + 1;
            } while (h <= n);
            do
            {
                h /= 3;
                for (i = h; i < n; i++)
                {
                    x = vet[i];
                    j = i;
                    while (j > (h - 1) && vet[j - h] > x)
                    {
                        vet[j] = vet[j - h];
                        j -= h;
                    }
                    vet[j] = x;
                    p.Invalidate();
                    Thread.Sleep(10);
                    if (vet.Length > 500)
                    {
                        p.Invalidate(); // redesenha o painel
                        Thread.Sleep(1); // espera 10 milisegundos
                    }
                }
            } while (h != 1);
        }

        public static void quickSort(int[] vet, int esq, int dir, Panel p)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x > vet[i]) i++;
                while (x < vet[j]) j--;
                if (i <= j)
                {
                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    i++;
                    j--;
                }
                p.Invalidate();
                Thread.Sleep(10);
                if (vet.Length > 500)
                {
                    p.Invalidate(); // redesenha o painel
                    Thread.Sleep(1); // espera 10 milisegundos
                }
            } while (i <= j);
            if (esq < j) quickSort(vet, esq, j, p);
            if (i < dir) quickSort(vet, i, dir, p);
        }

        public static void heapSort(int[] v, Panel p)
        {
            constroiMaxHeap(v);
            int n = v.Length;

            for (int i = v.Length - 1; i > 0; i--)
            {
                troca(v, i, 0);
                refaz(v, 0, --n);
                p.Invalidate();
                Thread.Sleep(10);
                if (v.Length > 500)
                {
                    p.Invalidate(); // redesenha o painel
                    Thread.Sleep(1); // espera 10 milisegundos
                }
            }
        }

        private static void constroiMaxHeap(int[] v)
        {
            for (int i = v.Length / 2 - 1; i >= 0; i--)
                refaz(v, i, v.Length);

        }

        private static void refaz(int[] vetor, int pos, int tamanhoDoVetor)
        {

            int max = 2 * pos + 1, right = max + 1;
            if (max < tamanhoDoVetor)
            {

                if (right < tamanhoDoVetor && vetor[max] < vetor[right])
                    max = right;

                if (vetor[max] > vetor[pos])
                {
                    troca(vetor, max, pos);
                    refaz(vetor, max, tamanhoDoVetor);
                }
            }
        }

        public static void troca(int[] v, int j, int aposJ)
        {
            int aux = v[j];
            v[j] = v[aposJ];
            v[aposJ] = aux;
        }

        private static void merge(int[] v, int i, int m, int j, Panel p)
        {
            int[] temp = new int[m - i + 1];
            int k;
            for (k = i; k <= m; k++)
                temp[k - i] = v[k];
            int esq = 0, dir = m + 1;
            k = m - i + 1;
            while (esq < k && dir <= j)
            {
                if (temp[esq] <= v[dir])
                    v[i++] = temp[esq++];
                else
                    v[i++] = v[dir++];
            }
            while (esq < k)
                v[i++] = temp[esq++];
            if (v.Length > 500)
            {
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(1); // espera 10 milisegundos
            }
            p.Invalidate();
            Thread.Sleep(10);

        }
        public static void mergeSort(int[] v, int i, int j, Panel p)
        {
            if (i < j)
            {
                int m = (i + j) / 2;
                mergeSort(v, i, m, p);
                mergeSort(v, m + 1, j, p);
                merge(v, i, m, j, p); // intercala v[i..m] e v[m+1..j] em v[i..j] 
            }
        }

    }
}
