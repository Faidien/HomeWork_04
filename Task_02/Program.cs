using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isEven = false;
            int n, col, row;
            string name = "* * * * * * Треугольник Паскаля * * * * * *";
            Console.SetCursorPosition(Console.WindowWidth / 2 - name.Length, 0);
            Console.WriteLine(name);
            Console.Write("Введите количество строк : ");
            int.TryParse(Console.ReadLine(), out n);
            col = n * 2 - 1;
            row = n;
            isEven = row % 2 == 0 ? true : false;


            int[][] trianglePascale = new int[n][];
            // ввод первой строки
            trianglePascale[0] = new int[] { 1 };

            for (int i = 1; i < trianglePascale.Length; i++)
            {
                trianglePascale[i] = new int[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                        trianglePascale[i][j] = 1;
                    else
                    {
                        trianglePascale[i][j] = trianglePascale[i - 1][j - 1] + trianglePascale[i - 1][j];
                    }
                }
            }

            // вывод треугольника
            for (int i = 1; i < row + 1; i++)
            {
                int colCount = 0;
                for (int j = 1; j < col + 1; j++)
                {
                    if ((i % 2 == 0) == isEven)//нечетные строки
                    {
                        if ((j < (row + 1) - i || j > col - (row - i)))
                        {
                            Console.Write("-\t");
                        }
                        else
                        {
                            if (j % 2 == 1)
                            {
                                Console.Write(trianglePascale[i - 1][colCount++] + "\t");
                            }
                            else
                            {
                                Console.Write("-\t");
                            }
                        }
                    }
                    else//четные строки
                    {
                        if ((j < (row + 1) - i || j > col - (row - i)))
                        {
                            Console.Write("-\t");
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                Console.Write(trianglePascale[i - 1][colCount++] + "\t");
                            }
                            else
                            {
                                Console.Write("-\t");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }


    }


}