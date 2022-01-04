using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task21._1
{
    internal class Program
    {

        const int n = 2;
        const int k = 5;
        static int[,] plan = new int[n,k];
        static void Main(string[] args)
        {
            /*
            
            Имеется пустой участок земли (двумерный массив) и план сада, 
            который необходимо реализовать. Эту задачу выполняют два садовника, 
            которые не хотят встречаться друг с другом. Первый садовник начинает 
            работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, 
            он спускается вниз. Второй садовник начинает работу с нижнего правого угла сада 
            и перемещается снизу вверх, сделав ряд, он перемещается влево. 
            Если садовник видит, что участок сада уже выполнен другим садовником, 
            он идет дальше. Садовники должны работать параллельно. Создать многопоточное 
            приложение, моделирующее работу садовников. 

             */

            ThreadStart threadStart = new ThreadStart(Gardener2);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardener1();


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write(plan[i, j]+" ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Gardener1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (plan[i, j] >= 0)
                    {
                        plan[i, j] = -1;
                        Thread.Sleep(100);
                    }
                }
            }
        }
        static void Gardener2()
        {
            for (int i = k  - 1; i >=0; i--)
            {
                for (int j = n - 1; j >=0; j--)
                {
                    if (plan[j, i] >=0)
                    {
                        plan[j, i] = -2;
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }
}
