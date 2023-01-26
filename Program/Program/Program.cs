using IntervalTree;
using LounchTests;
using System.Diagnostics;
public class Program
{
    static void Main(string[] args)
    {
        double l;
        double h;
        int act;
        Tree tree = new Tree();
        do
        {
            Console.Clear();
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1 - Добавить узел;");
            Console.WriteLine("2 - Удалить узел;");//не работает надо написать
            Console.WriteLine("3 - Проверить на перекрытие;");
            Console.WriteLine("4 - Тестирование;");//не работают надо переписать 

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

                    tree.Insert(k);
                    Console.WriteLine(tree.Draw());
                    Console.WriteLine("Для продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 3: //проверка на перекрытие
                    Console.Clear();

                    l = Convert.ToDouble(Console.ReadLine());
                    h = Convert.ToDouble(Console.ReadLine());

                    var x = new Interval(l, h);

                    Console.WriteLine(tree.Search(x));
                   
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 2://удаление всего дерева
                    Console.Clear();

                    Console.WriteLine("Введите нижнюю границу интервала");
                    l = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите верхнюю границу интервала");
                    h = Convert.ToDouble(Console.ReadLine());
                    
                    var rem = new Interval(l, h);

                    tree.Delete(rem);
                    Console.WriteLine(tree.Draw());
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 4:
                    Tests.lounch();
                    break;
            }
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}