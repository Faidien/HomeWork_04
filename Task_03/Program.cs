using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            byte userAnswer = 0;
            string separator = "______________________________________";
            bool isExit = false;
            int[,] matrix = new int[5, 5];
            int[,] matrix2 = new int[5, 5];
            int[,] multiplicationResult = new int[5, 5];
            int[,] additionResult = new int[5, 5];
            int[,] subtractionResult = new int[5, 5];
            Random random = new Random();


            // Приветствие
            string name = "* * * * * * Операции с матрицами * * * * * *";
            Console.SetCursorPosition(Console.WindowWidth / 2 - name.Length, 0);
            Console.WriteLine(name);

            Console.WriteLine("Первая матрица до преобразования.");
            // Заполнение массива случайными числами, вывод в консоль
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(10, 100);
                    Console.Write(matrix[i, j] + "\t");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Вторая матрица до преобразования.");
            // Заполнение массива случайными числами, вывод в консоль
            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    matrix2[i, j] = random.Next(10, 100);
                    Console.Write(matrix2[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine(separator);
            Console.WriteLine();

            while (!isExit)
            {
                Console.WriteLine("Сделайте выбор функции преобразования:");
                Console.WriteLine("1. Умножение матрицы на число\n2. Сложение и вычитание матриц\n3. Умножение двух матриц\n4. Выход из программы");
                byte.TryParse(Console.ReadLine(), out userAnswer);
                Console.WriteLine();
                switch (userAnswer)
                {
                    case 1:
                        int num = 0;
                        Console.Write("Введите число для умножения: ");
                        int.TryParse(Console.ReadLine(), out num);
                        Console.WriteLine("Первая матрица после преобразования.");
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                matrix[i, j] *= num;
                                Console.Write(matrix[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();

                        Console.WriteLine("Вторая матрица после преобразования.");
                        for (int i = 0; i < matrix2.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix2.GetLength(1); j++)
                            {
                                matrix2[i, j] *= num;
                                Console.Write(matrix2[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine(separator);
                        break;

                    case 2:
                        Console.WriteLine("Сложение матриц:");
                        for (int i = 0; i < additionResult.GetLength(0); i++)
                        {
                            for (int j = 0; j < additionResult.GetLength(1); j++)
                            {
                                additionResult[i, j] = matrix[i, j] + matrix2[i, j];
                                Console.Write(additionResult[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();

                        Console.WriteLine("Вычитание матриц:");
                        for (int i = 0; i < subtractionResult.GetLength(0); i++)
                        {
                            for (int j = 0; j < subtractionResult.GetLength(1); j++)
                            {
                                subtractionResult[i, j] = matrix[i, j] - matrix2[i, j];
                                Console.Write(subtractionResult[i, j] + "\t");
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine(separator);
                        break;

                    case 3:
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                for (int k = 0; k < matrix2.GetLength(1); k++)
                                {
                                    multiplicationResult[i, j] += matrix[i, k] * matrix2[k, j];
                                    
                                }
                                Console.Write(multiplicationResult[i, j] + "\t");
                                
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine(separator);
                        break;

                    case 4:
                        isExit = true;
                        break;

                    default:
                        break;
                }

            }
        }

    }
}