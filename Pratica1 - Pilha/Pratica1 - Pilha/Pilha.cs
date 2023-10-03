using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * CLASSE PILHA - IMPLEMENTA O TIPO ABSTRATO DE DADOS PILHA ESTÁTICA
 * OPERAÇÕES: 
 *	vazia() -> retorna true se a pilha está vazia.
 *	cheia() -> returna true se a pilha está cheia.
 *	empilhar(x) -> coloca o elemento x no topo da pilha.
 *	desempilhar() -> retorna o elemento situado no topo da pilha.
 */

namespace Calculadora
{
    class Pilha
    {
        private int[] vet; // vetor para armazenar os elementos da pilha
        private int topo; // indica a posição do topo

        public Pilha(int tam) // CONSTRUTOR
        { 
            vet = new int[tam];
            topo = 0;
        }

        public void Empilhar(int x)
        {
            vet[topo] = x;
            topo++;
        }

        public int Desempilhar()
        {
            topo--;
            return (vet[topo]);
        }

        public bool Vazia()
        {
            return (topo == 0);
        }

        public bool Cheia()
        {
            return (topo == vet.Length);
        }

    }
}
