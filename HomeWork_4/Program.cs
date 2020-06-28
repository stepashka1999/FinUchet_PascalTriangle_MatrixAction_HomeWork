using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var month = 12;

            Random rnd = new Random();

            var pattern = $"{"Месяц",8} {"Доходы, тыс. руб.",20} {"Расходы, тыс. руб",20} {"Прибыль, тыс. руб.",20}";

            var rashodi = new int[month];
            var dohodi = new int[month];
            var pribil = new int[month];

            var minValues = new int[3];

            //Заполняем массив
            for (int i = 0; i < month; i++)
            {
                dohodi[i] = rnd.Next(7, 20) * 10_000;
                rashodi[i] = rnd.Next(7, 15) * 10_000;

                pribil[i] = dohodi[i] - rashodi[i];
            }



            Console.WriteLine(pattern);

            //Выводим массив на экран
            for (int i = 0; i < month; i++)
            {
                Console.WriteLine($"{i+1, 6}{dohodi[i],19}{rashodi[i],19}{pribil[i],19}");
            }

            //заполнение максимальными значениями
            for(int i = 0; i < minValues.Length; i++)
            {
                minValues[i] = pribil.Max();
            }

            //Поиск 3х уникальных минимальных значений
            minValues[0] = pribil.Min();
            minValues[1] = pribil.Max();
            minValues[2] = pribil.Max();

            for(int i = 1; i < minValues.Length; i++)
            {
                for(int j = 0; j < pribil.Length; j++)
                {
                    if (pribil[j] > minValues[i - 1] && minValues[i] > pribil[j])
                    {
                        minValues[i] = pribil[j];
                    }
                }
            }

            //поиск месяцев с худшим доходом
            int[] badMonth = new int[12];

            for(int i = 0; i < pribil.Length; i++)
            {
                badMonth[i] = 0;
                for (int j = 0; j < minValues.Length; j++)
                {
                    if(pribil[i] == minValues[j]) badMonth[i] = 1;
                }
            }

            //Вывод месяцев с худшим доходом
            Console.WriteLine();
            Console.Write("Худшая прибыль в месяцах: ");
            for(int i = 0; i < badMonth.Length; i++)
            {
                if (badMonth[i] == 1) Console.Write(i+1 + ", ");
            }
            Console.CursorLeft-=2;
            Console.Write(" ");
            Console.WriteLine();


            //Поиск и вывод месяцев с положительнывм доходом
            var countOfGoodMonth = 0;
            Console.Write("Полижительная прибыль в месяцах: ");
            for (int i = 0; i < pribil.Length; i++)
            {
                if (pribil[i] > 0)
                {
                    Console.Write(i + 1 + ", ");
                    countOfGoodMonth++;
                }
            }
            Console.CursorLeft -= 2;
            Console.Write($" : {countOfGoodMonth} мес.");
            Console.WriteLine();

        }
    }
}
