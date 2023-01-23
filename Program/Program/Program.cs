using IntervalTree;
using LounchTests;
public class Program
{
    static void Main(string[] args)
    {
        double l;
        double h;
        int act;
        Node root = null;
        do
        {
            Console.Clear();
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1 - Добавить узел;");
            Console.WriteLine("2 - Удалить узел;");//не работает надо написать
            Console.WriteLine("3 - Проверить на перекрытие;");
            Console.WriteLine("4 - Тесты;");//не работают надо переписать 

            int.TryParse(Console.ReadLine(), out act);
            switch (act)
            {
                case 1://добавление узла
                    Console.Clear();

                    Console.WriteLine("Введите нижнюю границу интервала");
                    l = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите верхнюю границу интервала");
                    h = Convert.ToDouble(Console.ReadLine());

                    var k = new Interval(l, h);

                    if(root != null)
                    {
                        root.Insert(k);
                    } else
                    {
                        root = new Node(k, k.high);
                    }

                    Console.WriteLine(root.Draw(root));
                    Console.WriteLine("Для продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 3: //проверка на перекрытие
                    Console.Clear();

                    l = Convert.ToDouble(Console.ReadLine());
                    h = Convert.ToDouble(Console.ReadLine());

                    Interval x = new Interval(l, h);

                    Console.WriteLine(root.Search(x));

                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 2://удаление всего дерева
                    Console.Clear();

                    Console.WriteLine("Введите нижнюю границу интервала");
                    l = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите верхнюю границу интервала");
                    h = Convert.ToDouble(Console.ReadLine());
                    
                    Interval rem = new Interval(l, h);

                    if (root!=null) {
                        if (root.left != null || root.right != null)
                        {
                            root.Delete(rem);
                            Console.WriteLine(root.Draw(root));
                        } else
                        {
                            root = null;
                            Console.WriteLine(root);
                            Console.WriteLine("Узел удален");
                        }
                    } else 
                    {
                        Console.WriteLine("Дерево пустое");
                    }

                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 4:
                    Tests.tests_lounch();
                    break;
            }
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}