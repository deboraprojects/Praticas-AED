using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    class Fila
    {
        private int[] vet;
        private int inicio;
        private int fim;

        public Fila(int tam)
        {
            vet = new int[tam + 1];
            inicio = fim = 0;
        }

        public void Enfileirar(int i)
        {
            vet[fim] = i;
            fim = (fim + 1) % vet.Length;
        }

        public int Desenfileirar()
        {
            int item = vet[inicio];
            inicio = (inicio + 1) % vet.Length;
            return item;
        }

        public bool Vazia()
        {
            return inicio == fim;
        }

        public bool Cheia()
        {
            return ((fim + 1) % vet.Length) == inicio;
        }
    }
}