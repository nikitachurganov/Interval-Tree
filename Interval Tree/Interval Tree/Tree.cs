using System;

public class Tree
{
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