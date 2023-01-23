using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using IntervalTree;

namespace LounchTests
{
    public class Tests
    {
        static string in1 = "";
        static string in2 = "";
        static bool space = false;
        static double num1;
        static double num2;
        static string ans = "";
        static string output = "";
        public static void tests_lounch()
        {
            for (int i = 1; i <= Directory.GetDirectories("../тесты").Length; i++)
            {
                Node root = null;
                List<string> list = new List<string>();
                List<Interval> intervals = new List<Interval>();
                using (StreamReader sr = new StreamReader($"../тесты/{i}/{i}.in.txt"))
                {
                    string input = sr.ReadToEnd();
                    list = input.Split('\n').ToList();
                }
                for (int j = 1; j < list.Count; j++)
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
                    double.TryParse(in1, out num1);
                    double.TryParse(in2, out num2);

                    Interval x = new Interval(num1, num2);
                    intervals.Add(x);

                    in1 = "";
                    in2 = "";
                    space = false;
                }
               
                if (list[0] == "insert\r")
                {
                    foreach (var interval in intervals)
                    {
                        if (root == null)
                            root = new Node(interval, interval.high);
                        else
                            root.Insert(interval);
                    }
                    ans = root.Draw(root);
                }
                else if (list[0] == "search\r")
                {
                    for (int j = 0; j < intervals.Count - 1; j++)
                    {
                        if (root == null)
                            root = new Node(intervals[j], intervals[j].high);
                        else
                            root.Insert(intervals[j]);
                    }
                    ans = root.Search(intervals[intervals.Count - 1]);
                }
                else if (list[0] == "delete\r")
                {
                    for (int j = 0; j < intervals.Count - 1; j++)
                    {
                        if (root == null)
                            root = new Node(intervals[j], intervals[j].high);
                        else
                            root.Insert(intervals[j]);
                    }
                    if (root != null)
                    {
                        if (root.left != null || root.right != null)
                        {
                            root.Delete(intervals[intervals.Count - 1]);
                        }
                        ans = root.Draw(root);
                    }
                }
                using (StreamWriter wr  = new StreamWriter($"../тесты/{i}/{i}.output.txt"))
                {
                    wr.WriteLine(ans);
                }
                using (StreamReader sr = new StreamReader($"../тесты/{i}/{i}.output.txt"))
                {
                    ans = sr.ReadToEnd();
                }
                using (StreamReader sr = new StreamReader($"../тесты/{i}/{i}.result.txt"))
                {
                    output = sr.ReadToEnd();
                }
                if (output.Equals(ans))
                {
                    Console.WriteLine($"{i} Ok");
                }
                else
                {
                    Console.WriteLine($"{i} WA");
                }
            }
        }
    }
}