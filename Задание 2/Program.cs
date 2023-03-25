using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Задание_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[1000];
            int[] ii = new int[ints.Length];
            Random random = new Random();
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = random.Next(100);
            }

            AllSort(ints, ii);

            string path = "Save.txt";
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                foreach (var item in ints)
                    binaryWriter.Write(item);
            }
            Console.WriteLine("\nФайл сохранен: " + path);

            int[] file = new int[ints.Length];
            //string path = "Save.txt";
            Console.WriteLine("\nПроверка + Сортировка в порядке воз");
            using (BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                for (int i = 0; i < file.Length; i++)
                    file[i] = binaryReader.ReadInt32();
            }
            SortSelection(file);
            SortInsertion(file);
            SortBub(file);
            SortSheiker(file);
            SortSheiker(file);

            Console.WriteLine("\nСортировка в порядке уб");

            for (int i = 0; i < file.Length; i++)
            {
                    ints[i] = file[file.Length - 1 - i];
            }

            AllSort(ints, ii);
        }
        static void AllSort(int[] ints, int[] ii)
        {
            ints.CopyTo(ii, 0);

            ii.CopyTo(ints, 0);
            SortSelection(ints);
            ii.CopyTo(ints, 0);
            SortInsertion(ints);
            ii.CopyTo(ints, 0);
            SortBub(ints);
            ii.CopyTo(ints, 0);
            SortSheiker(ints);
            ii.CopyTo(ints, 0);
            SortShell(ints);
        }
    
        static int[] SortSelection(int[] ints)
        {
            int permutations = 0;
            int comparisons = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int indMin;
            for (int i = 0; i < ints.Length; i++)
            {
                indMin = i;
                for (int j = i; j < ints.Length; j++)
                {
                    if (ints[j] < ints[indMin])
                    {
                        indMin = j;
                    }
                }
                comparisons++;
                if (ints[indMin] == ints[i])
                    continue;
                int temp = ints[i];
                ints[i] = ints[indMin];
                ints[indMin] = temp;
                permutations++;
            }

            stopwatch.Stop();
            if(permutations == 0)
                Console.WriteLine("Массив уже отсортирован");
            Console.WriteLine(@"{0,-10}|{1,-1}/{2,-1}|{3,-1}|{4,-10}|", "Сортировка выбором (ms)", stopwatch.ElapsedMilliseconds/1000, stopwatch.ElapsedMilliseconds, "Колисечтво перестановок " + permutations, "Количество сравнений " + comparisons);
            return ints;
        }
        static int[] SortInsertion(int[] ints)
        {
            int permutations = 0;
            int comparisons = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 1; i < ints.Length; i++)
            {
                int k = ints[i];
                int tmp = ints[i];
                int j = i - 1;
                while (j >= 0 && ints[j] > k)
                {
                    ints[j + 1] = ints[j];
                    ints[j] = tmp;
                    j--;
                    permutations++;
                }
                comparisons++;
            }
            stopwatch.Stop(); 
            if (permutations == 0)
                Console.WriteLine("Массив уже отсортирован");
            Console.WriteLine(@"{0,-10}|{1,-1}/{2,-1}|{3,-1}|{4,-10}|", "Сортировка вставками (ms)", stopwatch.ElapsedMilliseconds / 1000, stopwatch.ElapsedMilliseconds, "Колисечтво перестановок " + permutations, "Количество сравнений " + comparisons);
            return ints;
        }
        static int[] SortBub(int[] ints )
        {
            int permutations = 0;
            int comparisons = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int temp = 0;
            for (int write = 0; write < ints.Length; write++)
            {
                for (int sort = 0; sort < ints.Length - 1; sort++)
                {
                    if (ints[sort] > ints[sort + 1])
                    {
                        temp = ints[sort + 1];
                        ints[sort + 1] = ints[sort];
                        ints[sort] = temp;
                        permutations++;
                    }
                    comparisons++;
                }
            }
            stopwatch.Stop();
            if (permutations == 0)
                Console.WriteLine("Массив уже отсортирован");
            Console.WriteLine(@"{0,-10}|{1,-1}/{2,-1}|{3,-1}|{4,-10}|", "Сортировка buubl (ms)", stopwatch.ElapsedMilliseconds / 1000, stopwatch.ElapsedMilliseconds, "Колисечтво перестановок " + permutations, "Количество сравнений " + comparisons);
            return ints;
        }
        static int[] SortSheiker(int[] ints)
        {
            int permutations = 0;
            int comparisons = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < ints.Length / 2; i++)
            {
                for (int j = i; j < ints.Length - i - 1; j++)
                {
                    if (ints[j] > ints[j+1])
                    {
                        int tmp = ints[j + 1];
                        ints[j+1] = ints[j];
                        ints[j] = tmp;
                        permutations++;
                    }
                    comparisons++;
                }

                for (int j = ints.Length - 2 - i; j > i; j--)
                {
                    if (ints[j-1] > ints[j])
                    {
                        int tmp = ints[j - 1];
                        ints[j - 1] = ints[j];
                        ints[j] = tmp;
                        permutations++;
                    }
                    comparisons++;
                }
            }
            stopwatch.Stop();
            if (permutations == 0)
                Console.WriteLine("Массив уже отсортирован");
            Console.WriteLine(@"{0,-10}|{1,-1}/{2,-1}|{3,-1}|{4,-10}|", "Сортировка шейкером (ms)", stopwatch.ElapsedMilliseconds / 1000, stopwatch.ElapsedMilliseconds, "Колисечтво перестановок " + permutations, "Количество сравнений " + comparisons);
            return ints;
        }
        static int[] SortShell(int[] ints)
        {
            int permutations = 0;
            int comparisons = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int h = ints.Length / 2;
            while ( h>=1)
            {
                for (int i = h; i < ints.Length; i++)
                {
                    int j = i;
                    while (j>=h && ints[j-h] > ints[j])
                    {
                        int tmp = ints[j - h];
                        ints[j - h] = ints[j];
                        ints[j] = tmp;
                        j -= h;
                        permutations++;
                    }
                    comparisons++;
                }
                h /= 2;
            }
            stopwatch.Stop();
            if (permutations == 0)
                Console.WriteLine("Массив уже отсортирован");
            Console.WriteLine(@"{0,-10}|{1,-1}/{2,-1}|{3,-1}|{4,-10}|", "Сортировка Шелла (ms)", stopwatch.ElapsedMilliseconds / 1000, stopwatch.ElapsedMilliseconds, "Колисечтво перестановок " + permutations, "Количество сравнений " + comparisons);
            return ints;
        }
    }
}
