using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Program

    {
        static void Main(string[] args)
        {
            string x = "";
            int resultado;
            int n1 = 0, n2 = 0;

            Pilha Calc = new Pilha(100);

            Console.Clear();
            Console.WriteLine("Escreva um número ou operador: " + "\n" + "Digite S para sair.");

            while (x != "S" || x != "s")
            {
                x = Console.ReadLine();

                if (Operador(x))
                {
                    if (Calc.Vazia())
                    {
                        Erro();                    
                    }
                    else
                    {
                        n1 = Calc.Desempilhar();
                    }

                    if (Calc.Vazia())
                    {
                        Erro();                   
                    }
                    else
                    {
                        n2 = Calc.Desempilhar();
                    }
                    resultado = Calcular(x, n1, n2);
                    Calc.Empilhar(resultado);
                    Console.WriteLine(resultado);
                }

                else if (Calc.Cheia())
                {
                    Console.WriteLine("A pilha está cheia!");
                }

                else
                {
                    Calc.Empilhar(Convert.ToInt32(x));
                }

            }

        }

        public static void Erro()
        {
            Console.WriteLine("Erro! Não há quantidade de números suficientes para realizar uma operação.");
        }

        public static bool Operador(string x)
        {
            bool resultado = false;
            if (x == "+" || x == "-" || x == "*" || x == "/")
            {
                resultado = true;
            }

            return resultado;
        }

        public static int Calcular(string x, int n1, int n2)
        {

            switch (x)
            {
                case "+":
                    return n1 + n2;

                case "-":
                    return n2 - n1;

                case "*":
                    return n2 * n1;

                case "/":
                    return n2 / n1;

                default:
                    ;
                    return Convert.ToInt32(x);

            }
        }
    }
}
