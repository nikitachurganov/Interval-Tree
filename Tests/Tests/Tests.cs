using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using IntervalTree;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;
using static System.Net.WebRequestMethods;

namespace LounchTests
{
    public class Tests
    {
        static string in1 = "";
        static string in2 = "";
        static bool space = false;
        static double num1;
        static double num2;
        static string output_ans = "";
        static string correnct_ans = "";
        public static void lounch() {
            Stopwatch time = new Stopwatch();
            time.Start();
            valid_lounch();
            lounch_rnd_test();
            time.Stop();
            Console.WriteLine(time.Elapsed);
            void valid_lounch()
            {
                Console.Clear();
                Console.WriteLine("Тесты на корректность");
                int ok = 0;
                int wa = 0;
                for (int i = 1; i <= Directory.GetDirectories("../тесты").Length; i++)
                {
                    Tree tree = new Tree();
                    int ins_iter = 0;
                    List<string> list = new List<string>();
                    List<string> operations = new List<string>();
                    List<Interval> intervals = new List<Interval>();
                    using (StreamReader sr = new StreamReader($"../тесты/{i}/{i}.in.txt"))
                    {
                        string oper = sr.ReadLine();
                        string input = sr.ReadToEnd();
                        operations = oper.Split(' ').ToList();
                        list = input.Split('\n').ToList();
                    }
                    for (int j = 0; j < list.Count; j++)
                    {
                        for (int k = 0; k < list[j].Length; k++)
                        {
                            if (list[j][k] == ' ')
                                space = true;
                            if (Char.IsDigit(list[j][k]) || list[j][k] == '-' || list[j][k] == ',' || list[j][k] == 'E')
                            {
                                if (space == false)
                                    in1 += list[j][k];
                                else if (space == true)
                                    in2 += list[j][k];
                            }
                        }
                        if (in1 == "")
                            in1 = in2;
                        if (in2 == "")
                            in2 = in1;
                        double.TryParse(in1, out num1);
                        double.TryParse(in2, out num2);

                        Interval x = new Interval(num1, num2);
                        intervals.Add(x);

                        in1 = "";
                        in2 = "";
                        space = false;
                    }
                    for (int k = 0; k < operations.Count; k ++)
                    {
                        
                        if (operations[k] == "insert")
                        {
                            int.TryParse(operations[k + 1], out int n);

                            for(int g = ins_iter; g < n; g++)
                            {
                                tree.Insert(intervals[g]);
                            }
                            ins_iter = n - 1;
                            using (StreamWriter sw = new StreamWriter($"../тесты/{i}/{i}.output.txt"))
                            {
                                sw.Write(tree.Draw());
                            }
                        }
                        if (operations[k] == "delete")
                        {
                            int.TryParse(operations[k + 1], out int n);
                            tree.Delete(intervals[n]);
                            using (StreamWriter sw = new StreamWriter($"../тесты/{i}/{i}.output.txt"))
                            {
                                sw.Write(tree.Draw());
                            }
                        }
                        if (operations[k] == "search")
                        {
                            double.TryParse(operations[k + 1], out double n);
                            double.TryParse(operations[k + 2], out double m);
                            Interval x =  new Interval(n, m);
                            using (StreamWriter sw = new StreamWriter($"../тесты/{i}/{i}.output.txt"))
                            {
                                sw.Write(tree.Search(x));
                            }
                        }
                        
                    }
                    using (StreamReader correct = new StreamReader($"../тесты/{i}/{i}.result.txt"))
                    {
                        correnct_ans = correct.ReadToEnd();
                    }
                    using (StreamReader outfile = new StreamReader($"../тесты/{i}/{i}.output.txt"))
                    {
                        output_ans = outfile.ReadToEnd();
                    }
                    if (output_ans == correnct_ans)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{i}. OK");
                        Console.ForegroundColor = ConsoleColor.White;
                        ok++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{i}. WA");
                        Console.ForegroundColor = ConsoleColor.White;
                        wa++;
                        
                    }
                }
                Console.WriteLine($"\nOK: {ok}\nWA: {wa}\n");
            }
            void lounch_rnd_test()
            {
                Console.WriteLine("Тесты на производительность\n");
                Console.WriteLine("Целые числа\n");
                time_tests(100);
                time_tests(500);
                time_tests(1000);
                time_tests(10000);
                time_tests(50000);
                time_tests(100000);
                time_tests(200000);
                time_tests(250000);
                time_tests(350000);
                time_tests(500000);
                time_tests(750000);
                time_tests(1000000);
                time_tests(1500000);
                time_tests(2500000);
                time_tests(3500000);
                time_tests(5000000);
                time_tests(7000000);
                Console.WriteLine("Вещественные числа\n");
                time_double_tests(100);
                time_double_tests(500);
                time_double_tests(1000);
                time_double_tests(10000);
                time_double_tests(50000);
                time_double_tests(100000);
                time_double_tests(200000);
                time_double_tests(250000);
                time_double_tests(350000);
                time_double_tests(500000);
                time_double_tests(750000);
                time_double_tests(1000000);
                time_double_tests(1500000);
                time_double_tests(2500000);
                time_double_tests(3500000);
                time_double_tests(5000000);
                time_double_tests(7000000);
                Console.WriteLine("Конец");
            }
            void time_tests(int nodes = 100)
            {
                Tree tree = new Tree();
                Stopwatch time_insert = new Stopwatch();
                Stopwatch time_delete = new Stopwatch();
                Stopwatch time_search = new Stopwatch();
                Random rnd = new Random();
                List<Interval> intervals = new List<Interval>();
                for (int i = 0; i < nodes; i++)
                {
                    double l = rnd.Next();
                    double h = rnd.Next();
                    Interval interval = new Interval(l, h);
                    intervals.Add(interval);
                }
                for (int i = 0; i < nodes; i++)
                {
                    time_insert.Start();
                    tree.Insert(intervals[i]);
                    time_insert.Stop();
                }
                Console.WriteLine($"Вставка            {nodes}    {time_insert.Elapsed.TotalMilliseconds / nodes}");
                Interval x = intervals[intervals.Count/2];
                time_delete.Start();
                tree.Delete(x);
                time_delete.Stop();
                Console.WriteLine($"Удаление 1 узла    {nodes}    {time_delete.Elapsed.TotalMilliseconds}");
                time_search.Start();
                tree.Search(x);
                time_search.Stop();
                Console.WriteLine($"Поиск              {nodes}    {time_search.Elapsed.TotalMilliseconds}\n");
            }

            void time_double_tests(int nodes = 100)
            {
                Tree tree = new Tree();
                Stopwatch time_insert = new Stopwatch();
                Stopwatch time_delete = new Stopwatch();
                Stopwatch time_search = new Stopwatch();
                Random rnd = new Random();
                List<Interval> intervals = new List<Interval>();
                for (int i = 0; i < nodes; i++)
                {
                    double l = rnd.NextDouble();
                    double h = rnd.NextDouble();
                    Interval interval = new Interval(l, h);
                    intervals.Add(interval);
                }
                for (int i = 0; i < nodes; i++)
                {
                    time_insert.Start();
                    tree.Insert(intervals[i]);
                    time_insert.Stop();
                }
                Console.WriteLine($"Вставка            {nodes}    {time_insert.Elapsed.TotalMilliseconds/nodes}");
                Interval x = intervals[intervals.Count / 2];
                time_delete.Start();
                tree.Delete(x);
                time_delete.Stop();
                Console.WriteLine($"Удаление 1 узла    {nodes}    {time_delete.Elapsed.TotalMilliseconds}");

                time_search.Start();
                tree.Search(x);
                time_search.Stop();
                Console.WriteLine($"Поиск              {nodes}    {time_search.Elapsed.TotalMilliseconds}\n");
            }
            
        }
    }
}