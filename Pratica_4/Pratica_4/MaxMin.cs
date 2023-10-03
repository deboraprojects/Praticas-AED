using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxMin
{
    class MaxMin
    {

        // Operação relevante: TESTES (if)
        // T(n) = 2n - 2
        public static void MaxMin1(int[] vet, out int ma, out int me)
        {

            int count1 = 0;

            ma = me = vet[0];
            for (int i = 1; i < vet.Length; i++)
            {
                
                if (count1++ >= 0 && vet[i] < me)
                
                    me = vet[i];

                if (count1++ >= 0 && vet[i] < ma)
                
                    ma = vet[i];
                           
            }

            Console.WriteLine("MaxMin1: " +count1);
        }

        // Melhor caso: T(n) = n - 1
        // Pior caso: T(n) = 2n - 2
        // Caso médio: T(n) = 3n/2 - 3/2
        public static void MaxMin2(int[] vet, out int ma, out int me)
        {
            int count2 = 0;
            ma = me = vet[0];
            for (int i = 1; i < vet.Length; i++)
            {
                if (count2++ >= 0 && vet[i] < me)
                    me = vet[i];          
                    
                else     
                    if (count2++ >= 0 && vet[i] > ma)
                    ma = vet[i];                                          
            }

            Console.WriteLine("MaxMin2: " + count2);
        }

        // T(n) = 3n/2 - 2
        public static void MaxMin3(int[] vet, out int ma, out int me)
        {
            int count3 = 0; 
            if (count3++ >= 0 && vet[0] < vet[1])
            {
                me = vet[0];
                ma = vet[1];
            }
            else
            {
                me = vet[1];
                ma = vet[0];
            }
            for (int i = 2; i < vet.Length; i += 2)
            {
                if (count3++ >= 0 && vet[i] < vet[i + 1])
                {
                    if (count3++ >= 0 && vet[i] < me)
                        me = vet[i];
                    if (count3++ >= 0 && vet[i + 1] > ma)
                        ma = vet[i + 1];
                }
                else
                {
                    if (count3++ >= 0 &&  vet[i + 1] < me)
                        me = vet[i + 1];
                    if (count3++ >= 0 &&  vet[i] > ma)
                        ma = vet[i];
                }
              
            }

            Console.WriteLine("MaxMin3: " + count3);
        }
    }
}
