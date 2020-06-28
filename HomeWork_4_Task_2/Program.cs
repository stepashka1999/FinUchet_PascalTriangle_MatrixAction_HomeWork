using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4_Task_2
{
    class Program
    {
        //В задаче 2 неверный пример. Как я понял из формулы. треугольник при n=9 будт иметь 10 строк, т.е n+1. Т.к.  А в примере при n=9 треугольник имеет 8 строк.
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество");
            var N = int.Parse(Console.ReadLine());

            var paskalArray = new int[N, N];

            FillPascalArray(paskalArray);

            Console.WriteLine("Простой вариант: \n");

            for (int k = 0; k < N; k++)
            {
                for (int i = 0; i <= k; i++)
                {
                    Console.Write($"{paskalArray[k - i, i], 10}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Вариант посложнее: \n");

            for (int k = 0; k < N; k++)
            {
                Console.Write(new string(' ', N - k));
                for (int i = 0; i <= k; i++)
                {
                    Console.Write($" {paskalArray[k - i, i], 1}");
                }
                Console.WriteLine();
            }
        }

        static void FillPascalArray(int[,] array)
        {
            var size = array.GetLength(0);

            for(int i = 0; i < size; i++)
                for(int j = 0; j < size; j++)
                {
                    if (i == 0 || j == 0) array[i, j] = 1;
                    else
                    {
                        array[i, j] = array[i-1, j] + array[i, j - 1];
                    }
                }
        }

    }
}
