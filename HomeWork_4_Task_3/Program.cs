using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Task 3.1 Умножение на число

            Console.WriteLine("Задание 3.1 - Умножение матрицы на число\n");

            Console.WriteLine("Введите количество столбцов матрицы: ");
            var col = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество строк матрицы: ");
            var row = int.Parse(Console.ReadLine());


            int[,] matrixA = new int[row, col];

            //Заполняем матрицу
            FillMatrix(matrixA);

            Console.WriteLine("Исходная матрица: \n");
            PrintMatrix(matrixA);

            Console.WriteLine("\nВведите число, на которое хотите умножить эту матрицу: ");
            var mult = int.Parse(Console.ReadLine());


            Console.WriteLine();
            //умножение матрицы на число
            Multiplication(matrixA, mult);

            Console.WriteLine("Результрующая матрица: \n");
            PrintMatrix(matrixA);

            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();

            #endregion

            #region Task 3.2 Сложение / Вычитание

            Console.WriteLine("Задание 3.2 - Сложение матриц\n");

            Console.WriteLine("Введите количество столбцов первой матрицы матрицы: ");
            col = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество строк первой матрицы: ");
            row = int.Parse(Console.ReadLine());


            matrixA = new int[row, col];

            //Заполняем матрицу A
            FillMatrix(matrixA);




            Console.WriteLine("Введите количество столбцов второй матрицы матрицы: ");
            col = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество строк второй матрицы: ");
            row = int.Parse(Console.ReadLine());


            var matrixB = new int[row, col];

            //Заполняем матрицу B
            FillMatrix(matrixB);

            Console.WriteLine("Первая матрица: \n");
            PrintMatrix(matrixA);

            Console.WriteLine("\nВторая матрица: \n");
            PrintMatrix(matrixB);


            Console.WriteLine("\nРезультрующая матрица сложения: \n");
            var resMatrix = Addition(matrixA, matrixB);

            if (resMatrix != null) PrintMatrix(resMatrix);

            Console.WriteLine("\nРезультрующая вычитания : \n");
            resMatrix = Subtraction(matrixA, matrixB);

            if (resMatrix != null) PrintMatrix(resMatrix);

            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();

            #endregion

            #region Task 3.3 Перемножение

            Console.WriteLine("Задание 3.2 - Умножение матриц \n");

            Console.WriteLine("Введите количество столбцов первой матрицы матрицы: ");
            col = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество строк первой матрицы: ");
            row = int.Parse(Console.ReadLine());


            matrixA = new int[row, col];

            //Заполняем матрицу A
            FillMatrix(matrixA);




            Console.WriteLine("Введите количество столбцов второй матрицы матрицы: ");
            col = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество строк второй матрицы: ");
            row = int.Parse(Console.ReadLine());


            matrixB = new int[row, col];

            //Заполняем матрицу B
            FillMatrix(matrixB);

            Console.WriteLine("Первая матрица: \n");
            PrintMatrix(matrixA);

            Console.WriteLine("Вторая матрица: \n");
            PrintMatrix(matrixB);


            Console.WriteLine("Результрующая матрица: \n");
            resMatrix = Multiplication(matrixA, matrixB);

            if (resMatrix != null) PrintMatrix(resMatrix);

            #endregion
        }

        /// <summary>
        /// Выводит двумерную матрицу в консоль, меняя цвет на голубой
        /// </summary>
        /// <param name="matrix">Матрица целых чисел</param>
        static void PrintMatrix(int[,] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
           
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write($"{"|",2}");
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    
                    Console.Write($"{matrix[i,j], 8}");
                }
                Console.WriteLine($"{"|",2}");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Заполняет матрицу рандомными значениями от 0 до 20
        /// </summary>
        /// <param name="matrix">Матрица целых чисел</param>
        static void FillMatrix(int[,] matrix)
        {
            Random rnd = new Random();

            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(0, 20);
                }
            }            
        }

        /// <summary>
        /// Складывает два матрицы
        /// </summary>
        /// <param name="matrixA">Первая матрица целых чисел</param>
        /// <param name="matrixB">Вторая матрица целых чисел</param>
        /// <returns>Результирующую матрицу</returns>
        static int[,] Addition(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0) || matrixA.GetLength(1) != matrixB.GetLength(1))
            {
                Console.WriteLine("Данные матрицы нельзя сложить.");
                return null;
            }


            int[,] res = (int[,])matrixA.Clone();

            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    res[i, j] += matrixB[i, j];
                }
            }

            return res;
        }

        /// <summary>
        /// Вычитает из первой матрицы вторую
        /// </summary>
        /// <param name="matrixA">Первая матрица</param>
        /// <param name="matrixB">Вторая матрица</param>
        /// <returns>Разность двух матриц</returns>
        static int[,] Subtraction(int[,] matrixA, int[,] matrixB)
        {
            if(matrixA.GetLength(0) != matrixB.GetLength(0) || matrixA.GetLength(1) != matrixB.GetLength(1))
            {
                Console.WriteLine("Данные матрицы нельзя вычесть.");
                return null;
            }
            

            int[,] res = (int[,])matrixA.Clone();
            
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    res[i, j] -= matrixB[i,j];
                }
            }

            return res;
        }

        /// <summary>
        /// Умножает матрицу на число
        /// </summary>
        /// <param name="matrix">Матрица целых чисел</param>
        /// <param name="multiplier">Целое число</param>
        static void Multiplication(int[,] matrix, int multiplier)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= multiplier;
                }
            }
        }

        /// <summary>
        /// Перемножает два матрицы
        /// </summary>
        /// <param name="matrixA">Первая матрица</param>
        /// <param name="matrixB">Вторая матрица</param>
        /// <returns>Матрицу произведения</returns>
        static int[,] Multiplication(int[,] matrixA, int[,] matrixB)
        {            
            int col = matrixA.GetLength(1);

            int row = matrixB.GetLength(0);

            if(col != row)
            {
                Console.WriteLine("Данные матрицы нельзя перемножить!");
                return null;
            }

            var rowM1 = matrixA.GetLength(0);

            var colM2 = matrixB.GetLength(1);

            var rowM2 = matrixB.GetLength(0);

            var res = new int[rowM1, colM2];

            //TODO
            for(int i = 0; i < rowM1; i++)
            {
                for(int j = 0; j < colM2; j++)
                {
                    var sum = 0;
                    for(int s = 0; s < rowM2; s++)
                    {
                        sum += matrixA[i, s] * matrixB[s, j];
                    }
                    res[i, j] = sum;
                }
            }

            return res;
        }    
    }
}
