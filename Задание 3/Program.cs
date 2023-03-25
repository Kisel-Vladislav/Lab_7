using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }




        static void Lab2_Task1()
        {
            /*_______________________________________________<Сложность O(1)>_______________________________________________*/

            while (true)
            {
                double a, b, c, D, x_1, x_2;
                Console.WriteLine("Введите значения: a, b, c");
                a = Convert.ToDouble(Console.ReadLine());
                b = Convert.ToDouble(Console.ReadLine());
                c = Convert.ToDouble(Console.ReadLine());
                D = Math.Pow(b, 2) - 4 * a * c;

                if (D > 0)
                {
                    x_1 = (-b + Math.Sqrt(D)) / (2 * a);
                    x_2 = (-b - Math.Sqrt(D)) / (2 * a);
                    Console.WriteLine($" {x_1}  и  {x_2} ");
                }
                else if (D == 0)
                {
                    x_1 = -b / 2 * a;
                    Console.WriteLine($"Уравнение имеет один корень: {x_1} ");
                }
                else if (D < 0)
                {
                    Console.WriteLine(-b / 2 + " + " + Math.Sqrt(D * -1) / 2 + "i");
                    Console.WriteLine(-b / 2 + " - " + Math.Sqrt(D * -1) / 2 + "i");
                }
            }
        }
        static void Lab2_Task2()
        {
            /*_______________________________________________<Сложность O(1)>_______________________________________________*/
            while (true)
            {
                Console.Write("Введите кординаты А(x_1;y_1) \n x_1 = ");
                int x_1 = int.Parse(Console.ReadLine());
                Console.Write("y_1 = ");
                int y_1 = int.Parse(Console.ReadLine());
                Console.Write("Введите кординаты B(x_2;y_2) \n x_2 = ");
                int x_2 = int.Parse(Console.ReadLine());
                Console.Write("y_2 = ");
                int y_2 = int.Parse(Console.ReadLine());
                if (x_1 < 0 && x_2 < 0 && y_1 > 0 && y_2 > 0 ||
                    x_1 > 0 && x_2 > 0 && y_1 < 0 && y_2 < 0 ||
                    x_1 < 0 && x_2 < 0 && y_1 < 0 && y_2 < 0 ||
                    x_1 > 0 && x_2 > 0 && y_1 > 0 && y_2 > 0)
                    Console.WriteLine(true);
                else if (x_1 == 0 || x_2 == 0 || y_1 == 0 || y_2 == 0)
                    Console.WriteLine("Zero coord");

                else
                    Console.WriteLine(false);
            }
        }
        static void Lab2_Task3()
        {
            /*_______________________________________________<Сложность O(n)>_______________________________________________*/
            while (true)
            {
                int i, f_0 = 1, f_1 = 1, f, four_digit = 0;
                Console.Write("fi = fi-1 + fi-2 , i = 2,3,4...\n i = ");
                i = int.Parse(Console.ReadLine());
                for (int Iteration = 1; Iteration < i; Iteration++)
                {
                    f = f_0 + f_1;
                    if (Iteration % 2 == 0)
                        f_0 = f;
                    else
                        f_1 = f;

                    if (f >= 1000)
                        four_digit = i - Iteration;
                    if (four_digit != 0)
                        break;
                    //Console.WriteLine(f);

                }
                Console.WriteLine("Количество четырехзначных чисел в ряде Фибоначчи: " + four_digit);
                Console.WriteLine();
            }

        }
        static void Lab2_Task4()
        {
            /*_______________________________________________<Сложность O(n)>_______________________________________________*/
            while (true)
            {
                int iteration = 0;
                double x, q, cos = 1, n = 2;
                double factorial, factorial_temp = 1;
                Console.Write("x =  ");
                x = double.Parse(Console.ReadLine());
                Console.Write("q = ");
                q = double.Parse(Console.ReadLine());
                x = (Math.PI / 180 * x);
                while (n <= 100)
                {
                    double cos_temp = 0;
                    factorial = n;
                    factorial_temp = n;


                    for (int i = 1; i < factorial; i++)
                    {
                        factorial_temp *= i;
                    }
                    factorial = factorial_temp;


                    if (iteration % 2 == 0)
                    {
                        cos_temp -= Math.Pow(x, n) / factorial;
                    }
                    else if (iteration % 2 != 0)
                    {
                        cos_temp += Math.Pow(x, n) / factorial;
                    }

                    if (Math.Abs(cos_temp) < q)
                        break;
                    cos += cos_temp;
                    n += 2;
                    iteration++;
                }
                Console.WriteLine("Количество учтенных слагаемых: " + iteration);
                Console.WriteLine("Cos(x) = " + cos);

            }
        }
        static void Lab2_Task5()
        {
            /*_______________________________________________<Сложность O(n/3)>_______________________________________________*/
            while (true)
            {
                int i = 3;
                Console.Write("N = ");
                int x = int.Parse(Console.ReadLine());
                while (i <= x)
                {
                    if (i == x)
                        Console.WriteLine(true);
                    i *= 3;

                }
                if (i / 3 != x || x == 1)
                    Console.WriteLine(false);
            }


        }
        static void Lab2_Task6()
        {
            /*_______________________________________________<Сложность O(1)>_______________________________________________*/
            Console.Write(" N от 1 до 100\n N =  ");
            int n = int.Parse(Console.ReadLine());
            if (n <= 20 || n == 100)
                switch (n)
                {
                    case 1:
                        Console.WriteLine(n + " год");
                        break;
                    case 2:
                    case 3:
                    case 4:
                        Console.WriteLine(n + " года");
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 100:
                        Console.WriteLine(n + " лет");
                        break;
                }
            else if (n % 10 == 1)
                Console.WriteLine(n + " год");
            else if (n % 10 <= 4)
                Console.WriteLine(n + " года");
            else
                Console.WriteLine(n + " лет");
        }
        static void Lab2_Task1_IND()
        {
            /*_______________________________________________<Сложность O(n)>_______________________________________________*/

            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            int x = 1, y = 1, z = 1, sym = 0;

            while (sym < N)
            {
                x++;

                Math.Pow(x, 3);
                Math.Pow(y, 3);
                Math.Pow(z, 3);
                sym = x + y + z;
                if (sym == N)
                    Console.WriteLine(N);

                y++;

                Math.Pow(x, 3);
                Math.Pow(y, 3);
                Math.Pow(z, 3);
                sym = x + y + z;
                if (sym == N)
                    Console.WriteLine(N);

                z++;

                Math.Pow(x, 3);
                Math.Pow(y, 3);
                Math.Pow(z, 3);
                sym = x + y + z;
                if (sym == N)
                    Console.WriteLine();
                else if (sym > N)
                    Console.WriteLine("«No such combinations!».");
            }
        }
        static void Lab2_Task2_IND()
        {
            /*_______________________________________________<Сложность O(n)>_______________________________________________*/

            while (true)
            {
                double pi = 0, tonumberTerms = 3, numerator = 1;
                int denominator, numberTerms;
                Console.Write("Kоличество слагаемых: ");
                numberTerms = int.Parse(Console.ReadLine());

                for (int i = 1; i < numberTerms; i++)
                {
                    if (i == 1)
                        pi = numerator - numerator / tonumberTerms;
                    else if (i % 2 != 0)
                        pi -= numerator / tonumberTerms;
                    else
                        pi += numerator / tonumberTerms;
                    tonumberTerms += 2;
                }
                Console.WriteLine(pi * 4);
            }
        }
        static void Lab3()
        {
            /*_______________________________________________<Сложность O(n^2)> <Сложность O(n^4)>_______________________________________________*/
            // Там лаба вся про работу с массивами(в основонм двумерными O(n^2) и иногда сразу с двумя двумерными O(n^4)). 
        }

        static void Lab4()
        {
            /*_______________________________________________<Сложность O(n^2)> <Сложность O(n)>_______________________________________________*/
            // O(n^2) - перебор строки как массива символов 
            // O(n) - поиск подстроки в строке с помошью Regex
        }

    }
}
