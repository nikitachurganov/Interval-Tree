using IntervalTree;


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

                    if (h < l)
                    {
                        double temp = h;
                        h = l;
                        l = temp;
                    }

                    var k = new Interval(l, h);

                    if (root == null)
                       root = new Node(k, k.high);
                    else 
                       root.Insert(k);
                    root.Print();
                    Console.WriteLine("Для продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 3: //проверка на перекрытие
                    Console.Clear();
                    if (root == null)
                    {
                        Console.WriteLine("Дерево не заполено.");
                    }
                    else
                    {
                        l = Convert.ToDouble(Console.ReadLine());
                        h = Convert.ToDouble(Console.ReadLine());

                        Interval x = new Interval(l, h);

                        Console.WriteLine(root.Search(x));

                    }
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 2://удаление всего дерева
                    Console.Clear();

                    Console.WriteLine("Введите нижнюю границу интервала");
                    l = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите верхнюю границу интервала");
                    h = Convert.ToDouble(Console.ReadLine());
                    if (h < l)
                    {
                        double temp = h;
                        h = l;
                        l = temp;
                    }
                    Interval rem = new Interval(l, h);
                   
                    root.Delete(rem);
                    root.Print();
                    
                    Console.WriteLine("Операция выполнена.\nДля продолжения нажмите ENTER.\nДля выхода нажмите ESC.");
                    break;
                case 0:
                    //Tests.tests_lounch();
                    break;
            }
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
}