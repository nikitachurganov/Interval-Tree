using System;
using System.IO;
using System.Diagnostics;
public class Program
{
    public static int f = 1;
    public static List<string> list = new List<string>();
    public static string result = "";
    public static string output = "";
    static void Main(string[] args)
    {
        double l;
        double h;
        int b;
        Tree.Node root = null;
        Tree.Node test = null;

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
                case 1://добавление узла
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

                    Tree.Interval k = new Tree.Interval(l, h);

                    test = Tree.insert(test, k);
                    
                    Console.WriteLine("Для продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 2: //вывод дерево
                    Console.Clear();
                    if (test == null)
                    {
                        Console.WriteLine("0");
                    }
                    else
                    {
                        Tree.inOrder(test);
                    }
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 3: //проверка на перекрытие
                    Console.Clear();
                    if (test == null)
                    {
                        Console.WriteLine("Дерево не заполено.");
                    }
                    else
                    {
                        l = Convert.ToDouble(Console.ReadLine());
                        h = Convert.ToDouble(Console.ReadLine());

                        Tree.Interval x = new Tree.Interval(l, h);

                        Tree.isOverlapping(test, x);
                    }
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 4://удаление всего дерева
                    Console.Clear();
                    if (test != null)
                    {
                        test = null;
                    }
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 5://удаление левого поддерева
                    Console.Clear();
                    Tree.remove_left(test);
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");

                    break;
                case 6://удаление правого поддерева
                    Console.Clear();
                    Tree.remove_right(test);
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");

                    break;
                case 7: //удаление узла из дерева
                    Console.Clear();
                    l = Convert.ToDouble(Console.ReadLine());
                    h = Convert.ToDouble(Console.ReadLine());

                    Tree.Interval rem_node = new Tree.Interval(l, h);

                    Tree.remove(test, rem_node);
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 8: //тесты на добавление
                    Console.Clear();
                    Tests.test_insert(root);
                    break;
                case 9://тесты на перекрытие
                    Console.Clear();
                    Tests.test_overlapping(root);
                    break;
                case 0://тесты на удаление
                    Console.Clear();
                    Tests.test_delete(root);
                    break;
            }
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}