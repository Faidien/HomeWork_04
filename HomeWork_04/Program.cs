using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int countMonth = 12, countMin = 0, countPositiveMonth = 0;
            int minValue = 1_000;
            int maxValue = 100_000;
            string listBadEarningList = "";
            string[] badEarn;
            char[] charSep =new char[] { ',' };
            Random random = new Random();
            int[,] financeTable = new int[countMonth, 4];
            int[] earnings = new int[countMonth];

            //заполнение таблицы финансов данными
            for (int i = 0; i < financeTable.GetLength(0); i++)
            {
                financeTable[i, 0] = i + 1; // заполнение месяцев
                financeTable[i, 1] = random.Next(minValue, maxValue); // заполнение доходов
                financeTable[i, 2] = random.Next(minValue, maxValue); // заполнение расходов
                financeTable[i, 3] = financeTable[i, 1] - financeTable[i, 2]; // заполнение прибыли
                earnings[i] = financeTable[i, 1] - financeTable[i, 2]; // заполнение прибыли в отдельный массив
            }

            // вывод таблицы в консоль
            Console.WriteLine("Месяц\t|Доход\t|Расход\t|Прибыль");
            Console.WriteLine("________|_______|_______|_______");
            for (int i = 0; i < financeTable.GetLength(0); i++)
            {
                for (int j = 0; j < financeTable.GetLength(1); j++)
                {
                    if (j != financeTable.GetLength(1) - 1)
                        Console.Write(financeTable[i, j] + "\t|");
                    else
                        Console.Write(financeTable[i, j] + "\t");
                }
                Console.WriteLine();
            }
            //сортировка по возрастанию прибыли. 
            Array.Sort(earnings);

            //мин прибыль
            countMonth = 0;
            int temp = 0, prevTemp = 0;
            foreach (var item in earnings)
            {
                ++countMonth;
                if (item < 1)// пропуск отрицательной прибыли
                {
                    continue;
                }
                else
                {
                    countPositiveMonth++;
                    if (countMin == 3)
                    {
                        continue;
                    }
                    else
                    {
                        countMin++;
                        if (countMin > 1)
                        {
                            prevTemp = temp;
                            temp = item;
                            if (temp == prevTemp)
                            {
                                countMin--;
                                continue;
                            }
                        }
                        else
                        {
                            temp = item;
                        }
                        listBadEarningList += temp + ",";
                    }

                }
            }
            badEarn = listBadEarningList.Split(charSep, StringSplitOptions.RemoveEmptyEntries);
            listBadEarningList = "";
            // месяца по мин прибылям
            for (int i = 0; i < badEarn.GetLength(0); i++)
            {
                for (int j = 0; j < financeTable.GetLength(0); j++)
                {
                    if (financeTable[j, 3] == int.Parse(badEarn[i]))
                    {
                        listBadEarningList += financeTable[j, 0] + ",";
                        break;
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine($"Худшие месяца: {listBadEarningList.Trim(',')}");
            Console.WriteLine($"Количество месяцев с положительной прибылью: {countPositiveMonth}");
            Console.ReadLine();
        }
    }
}