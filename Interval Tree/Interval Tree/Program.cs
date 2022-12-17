using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string nums = "1234567890";
        double l = 0;
        double h = 0;
        
        int b;

        Node root = null;
        Node test = null;



        do
        {
            Console.Clear();
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1 - Добавить интервал;");
            Console.WriteLine("2 - Показать порядок обхода;");
            Console.WriteLine("3 - Проверить на перекрытие;");
            Console.WriteLine("4 - Удалить всё дерево;");
            Console.WriteLine("5 - Удалить левое поддерево");
            Console.WriteLine("6 - Удалить правое поддерево");
            Console.WriteLine("7 - Удалить узел");
            Console.WriteLine("8 - Тесты на добавление;");
            Console.WriteLine("9 - Тесты на перекрытие;");
            Console.WriteLine("0 - Тесты на удаление;");
            int.TryParse(Console.ReadLine(), out b);
            switch (b)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Введите нижнюю границу интервала");


                    l = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите верхнюю границу интервала");

                    h = Convert.ToDouble(Console.ReadLine());

                    if (h < l)
                    {
                        double m = h;
                        h = l;
                        l = m;
                    }

                    Interval k = new Interval(l, h);


                    if (test == null)
                    {
                        test = insert(null, k);

                    }
                    else
                    {
                        if (test.range == k)
                            return;
                        else
                            test = insert(test, k);

                    }

                    Console.WriteLine("Для продолжения нажмите ENTER.\nДля выхода нажмите ESC.");

                    break;



                case 2:
                    Console.Clear();
                    if (test == null)
                    {
                        Console.WriteLine("0");
                    }
                    else
                    {
                        inOrder(test);
                    }
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;

                case 3:
                    Console.Clear();
                    if (test == null)
                    {
                        Console.WriteLine("Дерево не заполено.");
                    }
                    else
                    {
                        l = Convert.ToDouble(Console.ReadLine());
                        h = Convert.ToDouble(Console.ReadLine());

                        Interval ol = new Interval(l, h);

                        isOverlapping(test, ol);

                    }
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");

                    break;
                case 4:
                    Console.Clear();
                    if (test != null)
                    {
                        test = null;
                    }
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");

                    break;
                case 5:
                    Console.Clear();
                    remove_left(test);
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");

                    break;
                case 6:
                    Console.Clear();
                    remove_right(test);
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");

                    break;
                case 7:
                    Console.Clear();
                    l = Convert.ToDouble(Console.ReadLine());
                    h = Convert.ToDouble(Console.ReadLine());

                    Interval rem_node = new Interval(l, h);

                    remove(test, rem_node);
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");

                    break;
                case 8:
                    Console.Clear();
                    int a = Directory.GetFiles("C:\\Users\\Nikit\\Desktop\\тесты\\in").Length + 1;

                    List<string> list = new List<string>();

                    string result = "";
                    string output = "";
                    int f = 1;
                    Stopwatch stopWatch = new Stopwatch();

                    while (f != 13)
                    {
                        
                        
                        FileInfo file_in = new FileInfo($"C:\\Users\\Nikit\\Desktop\\тесты\\in\\{ f }.txt");
                        FileInfo file_res = new FileInfo($"C:\\Users\\Nikit\\Desktop\\тесты\\result\\{ f }.txt");

                        if (file_in.Length == 0)
                        {
                            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                            {
                                sw.WriteLine("Файл с входными данными пуст");
                            }
                        }

                        if (file_in.Length != 0)
                        {
                            
                            using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\in\\{f}.txt"))
                            {
                                string asd = sr.ReadToEnd();
                                list = asd.Split('\n').ToList();
                            }
                            string num1 = "";
                            double low_num = 0;
                            string num2 = "";
                            double high_num = 0;
                            List<Interval> intervals = new List<Interval>();
                            for (int i = 0; i < list.Count; i++)
                            {
                                int j = 0;
                                string number = list[i];
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

                                Interval inter = new Interval(low_num, high_num);
                                intervals.Add(inter);
                            }
                            stopWatch.Start();
                            foreach (var interval in intervals)
                            {
                                
                                if (root == null)
                                {
                                    root = insert(null, interval);
                                }
                                else
                                {
                                    if (root.range.low != low_num || root.range.high != high_num)
                                        root = insert(root, interval);
                                }
                                
                            }
                            
                            stopWatch.Stop();

                            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                            {
                                void inOrder(Node root)
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
                            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Nikit\\Desktop\\тесты\\Time\\{f}.txt"))
                            {

                                sw.WriteLine(stopWatch.ElapsedMilliseconds);


                            }
                        }
                        

                        
                        using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\result\\{f}.txt"))
                        {
                            string asd = sr.ReadToEnd();
                            result = asd;
                        }

                        using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                        {
                            string asd = sr.ReadToEnd();
                            output = asd;

                        }



                        if (output == result)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{f} OK");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Результат теста\n{output}\nПравильный ответ\n{result}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{f} WA");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Результат теста\n{output}\nПравильный ответ\n{result}");
                        }

                        f++;
                        root = null; 
                        

                    }


                    break;
                case 9:
                    root = null;
                    Console.Clear();
                    a = Directory.GetFiles("C:\\Users\\Nikit\\Desktop\\тесты\\in").Length + 1;



                    result = "";
                    output = "";
                    f = 13;
                    while (f != 28)
                    {
                        FileInfo file_in = new FileInfo($"C:\\Users\\Nikit\\Desktop\\тесты\\in\\{ f }.txt");
                        FileInfo file_res = new FileInfo($"C:\\Users\\Nikit\\Desktop\\тесты\\result\\{ f }.txt");

                        if (file_in.Length == 0)
                        {
                            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                            {
                                sw.WriteLine("Файл с входными данными пуст");
                            }
                        }

                        if (file_in.Length != 0)
                        {
                            using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\in\\{f}.txt"))
                            {
                                string asd = sr.ReadToEnd();
                                list = asd.Split('\n').ToList();
                            }
                            string num1 = "";
                            double low_num = 0;
                            string num2 = "";
                            double high_num = 0;
                            List<Interval> intervals = new List<Interval>();
                            for (int i = 0; i < list.Count; i++)
                            {
                                int j = 0;
                                string number = list[i];
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

                                Interval inter = new Interval(low_num, high_num);
                                intervals.Add(inter);
                            }
                            for (int i = 0; i < intervals.Count - 1; i++)
                            {
                                if (root == null)
                                {
                                    root = insert(null, intervals[i]);
                                }
                                else
                                {
                                    if (root.range.low != low_num || root.range.high != high_num)
                                        root = insert(root, intervals[i]);
                                }
                            }



                            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                            {
                                void isOverlapping(Node root, Interval x)
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

                        using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\result\\{f}.txt"))
                        {
                            string asd = sr.ReadToEnd();
                            result = asd;
                        }

                        using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                        {
                            string asd = sr.ReadToEnd();
                            output = asd;

                        }



                        if (output == result)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{f} OK");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Результат теста\n{output}\nПравильный ответ\n{result}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{f} WA");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Результат теста\n{output}\nПравильный ответ\n{result}");
                        }

                        f++;
                        root = null;

                    }


                    break;

                case 0:
                    Console.Clear();
                    a = Directory.GetFiles("C:\\Users\\Nikit\\Desktop\\тесты\\in").Length + 1;



                    result = "";
                    output = "";
                    f = 28;
                    while (f != a)
                    {
                        FileInfo file_in = new FileInfo($"C:\\Users\\Nikit\\Desktop\\тесты\\in\\{ f }.txt");
                        FileInfo file_res = new FileInfo($"C:\\Users\\Nikit\\Desktop\\тесты\\result\\{ f }.txt");

                        if (file_in.Length == 0)
                        {
                            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                            {
                                sw.WriteLine("Файл с входными данными пуст");
                            }
                        }

                        if (file_in.Length != 0)
                        {
                            using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\in\\{f}.txt"))
                            {
                                string asd = sr.ReadToEnd();
                                list = asd.Split('\n').ToList();
                            }
                            string num1 = "";
                            double low_num = 0;
                            string num2 = "";
                            double high_num = 0;
                            List<Interval> intervals = new List<Interval>();
                            for (int i = 0; i < list.Count; i++)
                            {
                                int j = 0;
                                string number = list[i];
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

                                Interval inter = new Interval(low_num, high_num);
                                intervals.Add(inter);
                            }
                            if (f > 34)
                            {
                                foreach (var interval in intervals)
                                {
                                    if (root == null)
                                    {
                                        root = insert(null, interval);
                                    }
                                    else
                                    {
                                        if (root.range.low != low_num || root.range.high != high_num)
                                            root = insert(root, interval);
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < intervals.Count - 1; i++)
                                {
                                    if (root == null)
                                    {
                                        root = insert(null, intervals[i]);
                                    }
                                    else
                                    {
                                        if (root.range.low != low_num || root.range.high != high_num)
                                            root = insert(root, intervals[i]);
                                    }
                                }

                            }
                            rem_node = intervals[intervals.Count - 1];



                            using (StreamWriter sw = new StreamWriter($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                            {
                                void inOrder(Node root)
                                {
                                    if (root == null)
                                    {
                                        return;
                                    }
                                    inOrder(root.left);
                                    sw.WriteLine(root);
                                    inOrder(root.right);
                                }
                                void remove(Node root, Interval x)
                                {
                                    if (root == null)
                                    {
                                        sw.WriteLine("Список интервалов пуст");
                                        return;
                                    }
                                    if (root.range.low == x.low && root.range.high == x.high)
                                    {
                                        root_replace(root);
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
                                void remove_tree(Node root)
                                {
                                    if (root == null)
                                        sw.WriteLine("Список интервалов пуст");
                                    else
                                    {
                                        root = null;
                                        sw.WriteLine("Дерево удалено");
                                    }
                                }
                                void remove_left(Node root)
                                {
                                    if (root.left != null)
                                    {
                                        root.left = null;
                                        max(root);
                                    }
                                }
                                void remove_right(Node root)
                                {
                                    if (root.right != null)
                                    {
                                        root.right = null;
                                        max(root);
                                    }
                                }
                                if (f >= 28 && f < 35)
                                {
                                    remove(root, rem_node);
                                    inOrder(root);
                                }
                                if (f == 35)
                                {
                                    remove_tree(root);
                                }
                                if (f == 36)
                                {

                                    remove_left(root);
                                    inOrder(root);
                                }
                                if (f == 37)
                                {

                                    remove_right(root);

                                    inOrder(root);
                                }
                            }
                        }

                        using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\result\\{f}.txt"))
                        {
                            string asd = sr.ReadToEnd();
                            result = asd;
                        }

                        using (StreamReader sr = new StreamReader($"C:\\Users\\Nikit\\Desktop\\тесты\\out\\{f}.txt"))
                        {
                            string asd = sr.ReadToEnd();
                            output = asd;

                        }



                        if (output == result)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{f} OK");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Результат теста\n{output}\nПравильный ответ\n{result}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{f} WA");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine($"Результат теста\n{output}\nПравильный ответ\n{result}");
                        }

                        f++;
                        root = null;


                    }
                    break;
            }
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);


    }
    public class Node
    {
        public Interval range;
        public Node left, right;
        public double max;
        public Node(Interval range, double max)
        {
            this.range = range;
            this.max = max;
        }

        public override string ToString()
        {
            return "[" + this.range.low + ", "
                + this.range.high + "] "
                + "max = " + this.max;
        }
    }
    public class Interval
    {

        public double low, high;

        public Interval(double low, double high)
        {
            double temp;
            if (low > high)
            {
                temp = high;
                high = low;
                low = temp;
            }
            this.low = low;
            this.high = high;
        }
        public override string ToString()
        {
            return "[" + this.low + "," + this.high + "]";
        }
    }
    public static Node insert(Node root, Interval x)
    {
        if (root == null)
        {
            return new Node(x, x.high);
        }

        if (x.low < root.range.low)
        {
            root.left = insert(root.left, x);
        }
        else
        {
            root.right = insert(root.right, x);
        }
        if (root.max < x.high)
        {
            root.max = x.high;
        }

        return root;
    }
    public static void remove(Node root, Interval x)
    {
        if (root == null)
        {
            Console.WriteLine("Список интервалов пуст");
            return;
        }
        if (root.range.low == x.low && root.range.high == x.high)
        {


            if (root.left == null && root.right == null)
            {

                root.range.low = 0;
                root.range.high = 0;
                root.max = 0;

                return;
            }
            if (root.left != null || root.right != null)
            {
                root_replace(root);

                return;
            }

            Console.WriteLine("Узел в дереве");
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
            Console.WriteLine("Такого узла нет в дереве");


    }

    public static void inOrder(Node root)
    {
        if (root == null)
        {
            return;
        }
        max(root);
        inOrder(root.left);
        
        Console.WriteLine(root);
        
        inOrder(root.right);
    }
    public static void drawer(int x, int y)
    {
        
    }
    public static void isOverlapping(Node root, Interval x)
    {
        if ((x.low > root.range.low && x.high > root.range.high && x.low < root.range.high) || (x.low < root.range.low && x.high < root.range.high && x.high > root.range.low))
        {

            Console.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
        }
        if (x.low > root.range.low && x.low < root.range.high && x.high < root.range.high && x.high > root.range.low)
        {

            Console.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
        }
        if (x.low == root.range.low && x.high < root.range.high)
        {

            Console.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
        }
        if (x.high == root.range.high && x.low > root.range.low)
        {

            Console.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
        }
        if (x.high == root.range.low)
        {

            Console.WriteLine($"Интервал {x} частично перекрывает интервал {root.range}");
        }
        if (x.low <= root.range.low && x.high >= root.range.high)
        {
            Console.WriteLine($"Интервал {x} полностью перекрывает интервал {root.range}");
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
    public static void max(Node root)
    {

        if (root != null && root.left != null)
            if (root.max != root.left.max && root.range.high != root.max && root.right == null)
            {
                root.max = root.left.max;
                max(root.left);

            }
        if (root != null && root.right != null)
            if (root.max != root.right.max && root.range.high != root.max && root.left == null)
            {
                root.max = root.right.max;
                max(root.right);
            }

    }
    public static void root_replace(Node root)
    {
        if (root.right != null)
        {
            root.range = root.right.range;
            max(root);
            if (root.range == root.right.range && root.right.right == null && root.right.left == null)
            {

                root.right = null;

                return;
            }
            else if (root.range == root.right.range && root.right.right == null && root.right.left != null)
            {
                root.right = root.right.left;
            }
            root_replace(root.right);

        }
        else if (root.left != null && root.right == null)
        {
            root.range = root.left.range;
            max(root);
            if (root.range == root.left.range && root.left.right == null && root.left.left == null)
            {
                root.left = null;

                return;
            }
            else if (root.range == root.left.range && root.left.right == null && root.left.left != null)
            {
                root.left = root.left.left;
            }
            root_replace(root.left);
        }
        else
        {
            root = null;
            return;
        }



    }
    public static void remove_tree(Node root)
    {
        if (root == null)
            Console.WriteLine("Список интервалов пуст");
        else
        {
            root = null;
            Console.WriteLine("Дерево удалено");
        }
    }
    public static void remove_left(Node root)
    {
        if (root.left != null)
        {
            root.left = null;
            max(root);
        }
    }
    public static void remove_right(Node root)
    {
        if (root.right != null)
        {
            root.right = null;
            max(root);
        }
    }
}

