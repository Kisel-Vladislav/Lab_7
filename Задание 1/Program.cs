using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Program
    {
        struct TableEntry
        {
            public string film;
            public string director;
            public string year;
            public string genre;

            public void Print()
            {
                Console.WriteLine("|{0,-20}|{1,-20}|{2,-15}|{3,-5}|", film, director, year, genre);
            }
            public void Change()
            {
                Console.Write("Фильм: ");
                film = Console.ReadLine();
                Console.Write("Режиссер: ");
                director = Console.ReadLine();
                Console.Write("Год выпуска: ");
                year = Console.ReadLine();
                Console.Write("Жанр: ");
                genre = Console.ReadLine();
            }
            public void Filter(int filter)
            {
                int result1;
                if (Int32.TryParse(year, out result1) && result1 > filter)
                    Print();
            }
            static public void Save(TableEntry[] tables)
            {
                StreamWriter file = new StreamWriter("C:/Users/vladk/OneDrive/Рабочий стол/C#/Lab_6/lab.dat");
                for (int i = 0; i < tables.Length; i++)
                {
                    file.Write(@"{0}|{1}|{2}|{3}", tables[i].film, tables[i].director, tables[i].year, tables[i].genre);
                    file.WriteLine();
                }
                file.Close();
            }
            static public TableEntry[] Load()
            {
                string[] lines = File.ReadAllLines("C:/Users/vladk/OneDrive/Рабочий стол/C#/Lab_6/lab.dat");
                TableEntry[] tables = new TableEntry[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] linesFiltr;
                    char[] ch = { '|' };
                    linesFiltr = lines[i].Split(ch, StringSplitOptions.RemoveEmptyEntries);
                    tables[i].film = linesFiltr[0];
                    tables[i].director = linesFiltr[1];
                    tables[i].year = linesFiltr[2];
                    tables[i].genre = linesFiltr[3];
                }
                return tables;
            }
            static public void Backup()
            {
                string path = "C:/Users/vladk/OneDrive/Рабочий стол/C#/Lab_6";
                if (!Directory.Exists(path + "/Lab6_Temp"))
                {
                    Directory.CreateDirectory(path + "/Lab6_Temp");
                }
                if (!File.Exists(path + "/lab.dat"))
                {
                    File.Copy(path + "/lab.dat", path + "/Lab6_Temp/lab.dat");
                }
                using (BinaryReader reader = new BinaryReader(File.Open(path + "/Lab6_Temp/lab.dat", FileMode.OpenOrCreate)))
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(path + "/Lab6_Temp/lab_bakup.dat", FileMode.OpenOrCreate)))
                    {
                        while (reader.PeekChar() != -1)
                        {
                            writer.Write(reader.ReadByte());
                        }
                    }
                }

            }
            struct Log
            {
                public string _nameEvent;
                public DateTime _time;

            }
            static Log[] NewLog(Log[] logs, in TableEntry[] table1, ref byte nomLogs)
            {
                logs[nomLogs]._nameEvent = "Добавлена запись: " + table1[table1.Length - 1].film;
                logs[nomLogs]._time = DateTime.Now;
                nomLogs++;
                return logs;
            }

            static Log[] NewLog(Log[] logs, in TableEntry[] table1, ref byte nomLogs, byte nomEntry)
            {
                logs[nomLogs]._nameEvent = "Удалена запись: " + table1[nomEntry].film;
                logs[nomLogs]._time = DateTime.Now;
                nomLogs++;
                return logs;
            }

            static TableEntry[] AddEntry(TableEntry[] table, int index)
            {
                TableEntry[] result = new TableEntry[table.Length + 1];
                for (int i = 0; i < table.Length; i++)
                {
                    result[i] = table[i];
                }
                result[index].film = "Driver";
                result[index].director = "Pipos Dr.";
                result[index].year = "1949";
                result[index].genre = "Х";

                result[index].Change();
                return result;
            }

            static TableEntry[] DeleteEnty(TableEntry[] table, int index)
            {
                TableEntry[] result = new TableEntry[table.Length - 1];

                for (int i = 0; i < index; i++)
                    result[i] = table[i];

                for (int i = index + 1; i <= result.Length; i++)
                    result[i - 1] = table[i];

                return result;
            }

            static void SortTable(TableEntry[] table)
            {
                for (int i = 1; i < table.Length; i++)
                {
                    int k = int.Parse(table[i].year);
                    TableEntry tmp = table[i];
                    int j = i - 1;
                    while (j > 0 && int.Parse(table[j].year) > k)
                    {
                        table[j + 1] = table[j];
                        table[j] = tmp;
                        j--;
                    }
                }
            }
            static void Main(string[] args)
            {
                Backup();
                Log[] logs = new Log[50];
                byte nomLogs = 0;
                //TableEntry[] table1 = new TableEntry[1];
                TableEntry[] table1 = TableEntry.Load();
                table1[0].film = "Фильм";
                table1[0].director = "Режиссер";
                table1[0].year = "Год выпуска";
                table1[0].genre = "Тип";
                bool close = false;


                while (!close)
                {
                    Console.WriteLine("1 – Просмотр таблицы\r\n" +
                                      "2 – Добавить запись\r\n" +
                                      "3 – Удалить запись\r\n" +
                                      "4 – Обновить запись\r\n" +
                                      "5 – Поиск записей\r\n" +
                                      "6 – Просмотреть лог\r\n" +
                                      "7 - Выход\n" +
                                      "i - info lab.dat\n"+
                                      "0 - Сортировка и просмотр таблицы\n");
                    ConsoleKey key = Console.ReadKey().Key;
                    Console.WriteLine();

                    switch (key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:    // Просмотр таблицы
                            {
                                Console.WriteLine("\nКинопродукция");

                                foreach (var item in table1)
                                {
                                    item.Print();
                                }
                                Console.WriteLine(" Перечисляемый тип: Д - драма, К – комедия, М – мелодрама, Б – боевик, А – мультфильм");
                                Console.WriteLine();
                                break;
                            }
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:    // Добавить запись 
                            {
                                Console.WriteLine();
                                table1 = AddEntry(table1, table1.Length);
                                logs = NewLog(logs, table1, ref nomLogs);
                                break;
                            }
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:    // Удалить запись 
                            {
                                Console.WriteLine();
                                Console.Write("Удалить запись №: ");
                                byte nomEntry = Byte.Parse(Console.ReadLine());
                                logs = NewLog(logs, table1, ref nomLogs, nomEntry);
                                table1 = DeleteEnty(table1, nomEntry);
                                break;
                            }
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4:    // Обновить запись
                            {
                                Console.WriteLine();
                                byte i = 0;
                                foreach (var item in table1)
                                {
                                    Console.WriteLine("Запись № " + i++);
                                    item.Print();
                                }
                                byte nomEntry = Byte.Parse(Console.ReadLine());
                                NewLog(logs, table1, ref nomLogs, nomEntry);
                                table1[nomEntry].Change();
                                NewLog(logs, table1, ref nomLogs);
                            }
                            break;
                        case ConsoleKey.D5:
                        case ConsoleKey.NumPad5:    // Поиск записей
                            {
                                Console.WriteLine();
                                Console.Write("Ввывести все фильмы с годом выпуска больше: ");
                                int filter;
                                Int32.TryParse(Console.ReadLine(), out filter);
                                table1[0].Print();
                                for (int i = 1; i < table1.Length; i++)
                                {
                                    table1[i].Filter(filter);
                                }
                                break;
                            }
                        case ConsoleKey.D6:
                        case ConsoleKey.NumPad6:    // Просмотреть лог 
                            {
                                Console.WriteLine();
                                TimeSpan timeSpan = TimeSpan.Zero;
                                for (int j = 0; logs[j]._nameEvent != null; j++)
                                {
                                    TimeSpan timeSpan1 = logs[j + 1]._time - logs[j]._time;
                                    if (timeSpan <= timeSpan1)
                                        timeSpan = timeSpan1;
                                    Console.WriteLine($"{logs[j]._nameEvent} - {logs[j]._time:T}");
                                }
                                Console.WriteLine($"{timeSpan.ToString(@"hh\:mm\:ss")} - Самый долгий период бездействия");
                            }
                            break;
                        case ConsoleKey.D7:
                        case ConsoleKey.NumPad7:    // Выход
                            {
                                close = true;
                                TableEntry.Save(table1);
                            }
                            break;
                        case ConsoleKey.I:
                            {
                                if (File.Exists("C:/Users/vladk/OneDrive/Рабочий стол/C#/Lab_6/Lab6_Temp/lab.dat"))
                                {
                                    FileInfo file = new FileInfo("C:/Users/vladk/OneDrive/Рабочий стол/C#/Lab_6/Lab6_Temp/lab.dat");
                                    Console.WriteLine(@"{0,-10} | {1,-10} | {2,-10}", "Размер: " + file.Length + " bytes", "Доступ " + file.LastAccessTime, "Изменение " + file.LastWriteTime);
                                }
                            }
                            break;
                        case ConsoleKey.D0:
                        case ConsoleKey.NumPad0:
                            {
                                SortTable(table1);

                                Console.WriteLine("\nКинопродукция");

                                foreach (var item in table1)
                                {
                                    item.Print();
                                }
                                Console.WriteLine(" Перечисляемый тип: Д - драма, К – комедия, М – мелодрама, Б – боевик, А – мультфильм");
                                Console.WriteLine();
                            }
                            break;
                        default:
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }

}
