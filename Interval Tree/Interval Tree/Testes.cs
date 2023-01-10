using System;
using System.Diagnostics;
public class Testes
{
    static int a = Directory.GetFiles("../тесты/in").Length + 1;
    public static void test_insert(Tree.Node root)//тесты на добавление
    {
        Program.f = 1;
        while (Program.f != 13)
        {
            FileInfo file_in = new FileInfo($"../тесты/in/{ Program.f }.txt");
            FileInfo file_res = new FileInfo($"../result/{ Program.f }.txt");

            if (file_in.Length == 0)
            {
                using (StreamWriter sw = new StreamWriter($"../тесты/out/{Program.f}.txt"))
                {
                    sw.WriteLine("Файл с входными данными пуст");
                }
            }

            if (file_in.Length != 0)
            {
                using (StreamReader sr = new StreamReader($"../тесты/in/{Program.f}.txt"))
                {
                    string asd = sr.ReadToEnd();
                    Program.list = asd.Split('\n').ToList();
                }
                string num1 = "";
                double low_num = 0;
                string num2 = "";
                double high_num = 0;
                List<Tree.Interval> intervals = new List<Tree.Interval>();
                for (int i = 0; i < Program.list.Count; i++)
                {
                    int j = 0;
                    string number = Program.list[i];
                    while (number[j] != ' ')
                    {
                        if (number[0] != ' ')
                        {
                            num1 += number[j];
                            j++;
                        }
                        else
                        {
                            num1 = " ";
                        }
                    }

                    if (number[j] == ' ')
                    {
                        j++;
                        while (j < number.Length)
                        {
                            num2 += number[j];
                            j++;
                        }
                    }
                    if (num1 == " ")
                        num1 = num2;
                    if (num2 == " ")
                        num2 = num1;

                    if (number[number.Length - 1] == ' ')
                        num2 = num1;
                    if (number[0] == ' ')
                        num1 = num2;
                    if (num1 != " " && num2 != " ")
                    {
                        low_num = double.Parse(num1);
                        num1 = "";
                        high_num = double.Parse(num2);
                        num2 = "";
                    }

                    Tree.Interval inter = new Tree.Interval(low_num, high_num);
                    intervals.Add(inter);
                }

                foreach (var interval in intervals)
                {
                    if (root == null)
                    {
                        root = Tree.insert(null, interval);
                    }
                    else
                    {
                        if (root.range.low != low_num || root.range.high != high_num)
                            root = Tree.insert(root, interval);
                    }
                }

                using (StreamWriter sw = new StreamWriter($"../тесты/out/{Program.f}.txt"))
                {
                    void inOrder(Tree.Node root)
                    {
                        if (root == null)
                        {
                            return;
                        }
                        inOrder(root.left);
                        sw.WriteLine(root);
                        inOrder(root.right);
                    }
                    inOrder(root);
                }

            }

            using (StreamReader sr = new StreamReader($"../тесты/result/{Program.f}.txt"))
            {
                string asd = sr.ReadToEnd();
                Program.result = asd;
            }

            using (StreamReader sr = new StreamReader($"../тесты/out/{Program.f}.txt"))
            {
                string asd = sr.ReadToEnd();
                Program.output = asd;
            }

            if (Program.output == Program.result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Program.f} OK");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Результат теста\n{Program.output}\nПравильный ответ\n{Program.result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Program.f} WA");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Результат теста\n{Program.output}\nПравильный ответ\n{Program.result}");
            }

            Program.f++;
            root = null;
        }
    }
    public static void test_overlapping(Tree.Node root)
    {
        
        Program.f = 13;
        while (Program.f != 28)
        {
            FileInfo file_in = new FileInfo($"../тесты/in/{ Program.f }.txt");
            FileInfo file_res = new FileInfo($"../тесты/result/{ Program.f }.txt");

            if (file_in.Length == 0)
            {
                using (StreamWriter sw = new StreamWriter($"../тесты/out/{Program.f}.txt"))
                {
                    sw.WriteLine("Файл с входными данными пуст");
                }
            }

            if (file_in.Length != 0)
            {
                using (StreamReader sr = new StreamReader($"../тесты/in/{Program.f}.txt"))
                {
                    string asd = sr.ReadToEnd();
                    Program.list = asd.Split('\n').ToList();
                }
                string num1 = "";
                double low_num = 0;
                string num2 = "";
                double high_num = 0;
                List<Tree.Interval> intervals = new List<Tree.Interval>();
                for (int i = 0; i < Program.list.Count; i++)
                {
                    int j = 0;
                    string number = Program.list[i];
                    while (number[j] != ' ')
                    {
                        if (number[0] != ' ')
                        {
                            num1 += number[j];
                            j++;
                        }
                        else
                        {
                            num1 = " ";
                        }
                    }

                    if (number[j] == ' ')
                    {
                        j++;
                        while (j < number.Length)
                        {
                            num2 += number[j];
                            j++;
                        }
                    }
                    if (num1 == " ")
                        num1 = num2;
                    if (num2 == " ")
                        num2 = num1;

                    if (number[number.Length - 1] == ' ')
                        num2 = num1;
                    if (number[0] == ' ')
                        num1 = num2;
                    if (num1 != " " && num2 != " ")
                    {
                        low_num = double.Parse(num1);
                        num1 = "";
                        high_num = double.Parse(num2);
                        num2 = "";
                    }

                    Tree.Interval inter = new Tree.Interval(low_num, high_num);
                    intervals.Add(inter);
                }
                for (int i = 0; i < intervals.Count - 1; i++)
                {
                    if (root == null)
                    {
                        root = Tree.insert(null, intervals[i]);
                    }
                    else
                    {
                        if (root.range.low != low_num || root.range.high != high_num)
                            root = Tree.insert(root, intervals[i]);
                    }
                }

                using (StreamWriter sw = new StreamWriter($"../тесты/out/{Program.f}.txt"))
                {
                    void isOverlapping(Tree.Node root, Tree.Interval x)
                    {
                        if ((x.low > root.range.low && x.high > root.range.high && x.low < root.range.high) || (x.low < root.range.low && x.high < root.range.high && x.high > root.range.low))
                        {
                            sw.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
                        }
                        if (x.low > root.range.low && x.low < root.range.high && x.high < root.range.high && x.high > root.range.low)
                        {
                            sw.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
                        }
                        if (x.low == root.range.low && x.high < root.range.high)
                        {
                            sw.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
                        }
                        if (x.high == root.range.high && x.low > root.range.low)
                        {
                            sw.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
                        }
                        if (x.high == root.range.low && x.low < root.range.low)
                        {
                            sw.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
                        }
                        if (x.low == root.range.high && x.high > root.range.high)
                        {
                            sw.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
                        }
                        if (x.low < root.range.low && x.high < root.range.low)
                        {
                            sw.WriteLine($"Интервал {x} не перекрывает интервал {root.range}");
                        }
                        if (x.low > root.range.high && x.high > root.range.high)
                        {
                            sw.WriteLine($"Интервал {x} не перекрывает интервал {root.range}");
                        }
                        if (x.low <= root.range.low && x.high >= root.range.high)
                        {
                            sw.WriteLine($"Интервал {x} полностью перекрывает интервал {root.range}");
                        }

                        if (root.left != null)
                        {
                            isOverlapping(root.left, x);
                        }
                        if (root.right != null)
                        {
                            isOverlapping(root.right, x);
                        }
                    }
                    isOverlapping(root, intervals[intervals.Count - 1]);
                }
            }

            using (StreamReader sr = new StreamReader($"../тесты/result/{Program.f}.txt"))
            {
                string asd = sr.ReadToEnd();
                Program.result = asd;
            }

            using (StreamReader sr = new StreamReader($"../тесты/out/{Program.f}.txt"))
            {
                string asd = sr.ReadToEnd();
                Program.output = asd;

            }

            if (Program.output == Program.result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Program.f} OK");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Результат теста\n{Program.output}\nПравильный ответ\n{Program.result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Program.f} WA");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Результат теста\n{Program.output}\nПравильный ответ\n{Program.result}");
            }
            Program.f++;
            root = null;
        }
    }

    public static void test_delete(Tree.Node root)
    {
        Program.f = 28;
        while (Program.f != a)
        {
            FileInfo file_in = new FileInfo($"../тесты/in/{ Program.f }.txt");
            FileInfo file_res = new FileInfo($"../тесты/result/{ Program.f }.txt");

            if (file_in.Length == 0)
            {
                using (StreamWriter sw = new StreamWriter($"../тесты/out/{Program.f}.txt"))
                {
                    sw.WriteLine("Файл с входными данными пуст");
                }
            }

            if (file_in.Length != 0)
            {
                using (StreamReader sr = new StreamReader($"../тесты/in/{Program.f}.txt"))
                {
                    string asd = sr.ReadToEnd();
                    Program.list = asd.Split('\n').ToList();
                }
                string num1 = "";
                double low_num = 0;
                string num2 = "";
                double high_num = 0;
                List<Tree.Interval> intervals = new List<Tree.Interval>();
                for (int i = 0; i < Program.list.Count; i++)
                {
                    int j = 0;
                    string number = Program.list[i];
                    while (number[j] != ' ')
                    {
                        if (number[0] != ' ')
                        {
                            num1 += number[j];
                            j++;
                        }
                        else
                        {
                            num1 = " ";
                        }
                    }

                    if (number[j] == ' ')
                    {
                        j++;
                        while (j < number.Length)
                        {
                            num2 += number[j];
                            j++;
                        }
                    }
                    if (num1 == " ")
                        num1 = num2;
                    if (num2 == " ")
                        num2 = num1;

                    if (number[number.Length - 1] == ' ')
                        num2 = num1;
                    if (number[0] == ' ')
                        num1 = num2;
                    if (num1 != " " && num2 != " ")
                    {
                        low_num = double.Parse(num1);
                        num1 = "";
                        high_num = double.Parse(num2);
                        num2 = "";
                    }

                    Tree.Interval inter = new Tree.Interval(low_num, high_num);
                    intervals.Add(inter);
                }
                if (Program.f > 34)
                {
                    foreach (var interval in intervals)
                    {
                        if (root == null)
                        {
                            root = Tree.insert(null, interval);
                        }
                        else
                        {
                            if (root.range.low != low_num || root.range.high != high_num)
                                root = Tree.insert(root, interval);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < intervals.Count - 1; i++)
                    {
                        if (root == null)
                        {
                            root = Tree.insert(null, intervals[i]);
                        }
                        else
                        {
                            if (root.range.low != low_num || root.range.high != high_num)
                                root = Tree.insert(root, intervals[i]);
                        }
                    }
                }
                Tree.Interval rem_node = intervals[intervals.Count - 1];

                using (StreamWriter sw = new StreamWriter($"../тесты/out/{Program.f}.txt"))
                {
                    void inOrder(Tree.Node root)
                    {
                        if (root == null)
                        {
                            return;
                        }
                        inOrder(root.left);
                        sw.WriteLine(root);
                        inOrder(root.right);
                    }
                    void remove(Tree.Node root, Tree.Interval x)
                    {
                        if (root == null)
                        {
                            sw.WriteLine("Список интервалов пуст");
                            return;
                        }
                        if (root.range.low == x.low && root.range.high == x.high)
                        {
                            Tree.root_replace(root);
                            return;
                        }
                        if (root.range.low >= x.low && root.left != null)
                        {
                            remove(root.left, x);
                        }
                        else if (root.range.low <= x.low && root.right != null)
                        {
                            remove(root.right, x);
                        }
                        else
                            sw.WriteLine("Такого узла нет в дереве.");
                        return;
                    }
                    void remove_tree(Tree.Node root)
                    {
                        if (root == null)
                            sw.WriteLine("Список интервалов пуст");
                        else
                        {
                            root = null;
                            sw.WriteLine("Дерево удалено");
                        }
                    }
                    void remove_left(Tree.Node root)
                    {
                        if (root.left != null)
                        {
                            root.left = null;
                            Tree.max(root);
                        }
                    }
                    void remove_right(Tree.Node root)
                    {
                        if (root.right != null)
                        {
                            root.right = null;
                            Tree.max(root);
                        }
                    }
                    if (Program.f >= 28 && Program.f < 35)
                    {
                        remove(root, rem_node);
                        inOrder(root);
                    }
                    if (Program.f == 35)
                    {
                        remove_tree(root);
                    }
                    if (Program.f == 36)
                    {
                        remove_left(root);
                        inOrder(root);
                    }
                    if (Program.f == 37)
                    {

                        remove_right(root);
                        inOrder(root);
                    }
                }
            }

            using (StreamReader sr = new StreamReader($"../тесты/result/{Program.f}.txt"))
            {
                string asd = sr.ReadToEnd();
                Program.result = asd;
            }

            using (StreamReader sr = new StreamReader($"../тесты/out/{Program.f}.txt"))
            {
                string asd = sr.ReadToEnd();
                Program.output = asd;

            }

            if (Program.output == Program.result)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{Program.f} OK");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Результат теста\n{Program.output}\nПравильный ответ\n{Program.result}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{Program.f} WA");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Результат теста\n{Program.output}\nПравильный ответ\n{Program.result}");
            }
            Program.f++;
            root = null;
        }
    }
}