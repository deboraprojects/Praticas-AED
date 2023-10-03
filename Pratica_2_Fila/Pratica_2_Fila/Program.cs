using Restaurante;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int cliente = 1, opção = 0, mudarFila;

            Fila pedido = new Fila(100);
            Fila pag = new Fila(100);
            Fila encomenda = new Fila(100);

            while (opção != 5)

            {
                Menu();
                opção = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opção)
                {

                    case 1:
                        
                        pedido.Enfileirar(cliente);                       
                        Console.WriteLine("O cliente " + cliente + " entrou na fila de pedidos.");
                        cliente++;
                        break;

                    case 2:
                        if (pedido.Vazia())
                        {
                            Erro();
                            break;
                        }

                        else
                        {
                            mudarFila = pedido.Desenfileirar();
                            pag.Enfileirar(mudarFila);
                            Console.WriteLine("O cliente " + mudarFila + " saiu da fila de pedidos e entrou na fila de pagamento.");
                        }
                        break;

                    case 3:
                        if (pag.Vazia())
                        {
                            Erro();
                            break;
                        }

                        else
                        {
                            mudarFila = pag.Desenfileirar();
                            encomenda.Enfileirar(mudarFila);
                            Console.WriteLine("O cliente " + mudarFila + " saiu da fila de pagamento e entrou na fila de encomenda.");
                        }
                        break;

                    case 4:
                        if (encomenda.Vazia())
                        {
                            Erro();
                            break;
                        }

                        else
                        {
                            mudarFila = encomenda.Desenfileirar();
                            Console.WriteLine("O cliente " + mudarFila + " finalizou o pedido.");
                        }
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            }

            Console.ReadKey();

        }

        public static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("Escolha uma das opções: ");
            Console.WriteLine("1 - Inserção de cliente na fila de pedidos");
            Console.WriteLine("2 - Remoção de cliente da fila de pedidos");
            Console.WriteLine("3 - Remoção de cliente da fila de pagamentos");
            Console.WriteLine("4 - Remoção de cliente da fila de encomendas");
            Console.WriteLine("5 - Sair");
        }

        public static void Erro()
        {
            Console.WriteLine("Não é possível realizar a operação, pois a fila anterior está vazia!");
        }
    }
}

