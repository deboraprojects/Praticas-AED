namespace Pratica5
{
    class OrdenacaoEstatistica
    {
        // TODO: contador de comparações e trocas
        // TODO: declarar demais métodos de ordenação
        public static int cont_c, cont_t;
        public static void Bolha(int[] vet)
        {

            cont_c = cont_t = 0;

            int i, j, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                for (j = vet.Length - 1; j > i; j--)
                {
                    cont_c++;
                    if (vet[j] < vet[j - 1])
                    {
                        temp = vet[j];
                        vet[j] = vet[j - 1];
                        vet[j - 1] = temp;
                        cont_t++;
                    }
                }
            }
        }

        public static void Selecao(int[] vet)
        {
            cont_c = cont_t = 0;

            int i, j, min, temp;
            for (i = 0; i < vet.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < vet.Length; j++)
                {
                    cont_c++;
                    if (vet[j] < vet[min])
                    {
                        min = j;
                        cont_t++;
                    }
                }
                temp = vet[i];
                vet[i] = vet[min];
                vet[min] = temp;
                cont_t++;
            }
        }

        public static void Insercao(int[] vet)
        {
            cont_c = cont_t = 0;

            int temp, i, j;
            for (i = 1; i < vet.Length; i++)
            {
                temp = vet[i];
                cont_t++;

                j = i - 1;
                while (j >= 0 && temp < vet[j])
                {
                    cont_c++;

                    vet[j + 1] = vet[j];
                    j--;

                    vet[j + 1] = temp;

                }

            }
        }

        public static void ShellSort(int[] vet)
        {
            cont_c = cont_t = 0;

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
                    cont_t++;

                    j = i;
                    while (j > (h - 1) && vet[j - h] > x)
                    {
                        cont_c++;
                        vet[j] = vet[j - h];
                        cont_t++;

                        j -= h;
                    }
                    vet[j] = x;
                }

            } while (h != 1);
        }

        public static void QuickSort(int[] vet, int esq, int dir)
        {
            int i, j, x, temp;

            x = vet[(esq + dir) / 2]; // pivo
            i = esq;
            j = dir;
            do
            {
                while (x > vet[i]) i++;
                while (x < vet[j]) j--;

                cont_c++;
                if (i <= j)
                {

                    temp = vet[i];
                    vet[i] = vet[j];
                    vet[j] = temp;
                    cont_t++;

                    i++;
                    j--;
                }
            } while (i <= j);

            cont_c++;
            if (esq < j)
            {
                QuickSort(vet, esq, j);
            }
            cont_c++;
            if (i < dir)
            {
                QuickSort(vet, i, dir);
            }
        }

        public static void HeapSort(int[] vet)
        {
            cont_c = cont_t = 0;

            ConstroiMaxHeap(vet);
            int n = vet.Length;

            for (int i = vet.Length - 1; i > 0; i--)
            {
                troca(vet, i, 0);
                refaz(vet, 0, --n);
            }
        }

        private static void ConstroiMaxHeap(int[] vet)
        {

            for (int i = vet.Length / 2 - 1; i >= 0; i--)
                refaz(vet, i, vet.Length);

        }

        private static void refaz(int[] vet, int pos, int tamanhoDoVetor)
        {
            int max = 2 * pos + 1, right = max + 1;

            cont_c++;
            if (max < tamanhoDoVetor)
            {
                cont_c++;
                if (right < tamanhoDoVetor && vet[max] < vet[right])
                    max = right;

                cont_c++;
                if (vet[max] > vet[pos])
                {
                    troca(vet, max, pos);
                    refaz(vet, max, tamanhoDoVetor);
                }
            }
        }

        public static void troca(int[] vet, int j, int aposJ)
        {
            int aux = vet[j];
            vet[j] = vet[aposJ];
            vet[aposJ] = aux;
            cont_t++;

        }

        private static void Merge(int[] vet, int i, int m, int j)
        {

            int[] temp = new int[m - i + 1];
            int k;
            for (k = i; k <= m; k++)
            {
                temp[k - i] = vet[k];
                cont_t++;
            }
            int esq = 0, dir = m + 1;
            k = m - i + 1;
            while (esq < k && dir <= j)
            {
                cont_c++;
                if (temp[esq] <= vet[dir])
                {
                    vet[i++] = temp[esq++];
                    cont_t++;
                }
                else
                {
                    vet[i++] = vet[dir++];
                    cont_t++;
                }

            }
            while (esq < k)
            {
                vet[i++] = temp[esq++];
                cont_t++;
            }

        }
        public static void MergeSort(int[] vet, int i, int j)
        {
            cont_c++;
            if (i < j)
            {
                int m = (i + j) / 2;
                MergeSort(vet, i, m);
                MergeSort(vet, m + 1, j);
                Merge(vet, i, m, j); // intercala v[i..m] e v[m+1..j] em v[i..j]
            }

        }

    }
}