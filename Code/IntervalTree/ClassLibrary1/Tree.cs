using System;
namespace IntervalTree
{
    public class Node
    {
        public Interval range;
        public Node left, right;
        public double max;
        public static string msg = "";
        public Node(Interval range, double max)
        {
            this.range = range;
            this.max = max;
        }
        public override string ToString() => $"[{this.range.low}, {this.range.high}] max = {this.max}";
        public Node Insert(Interval x)
        {
            if (this == null)
                return new Node(x, x.high);
            else
            {
                this._Insert(this, x);
                return this;
            }
        }
        Node _Insert(Node root, Interval x)
        {
            if (root.range.Equals(x))
            {
                return null;
            }
            else
            {
                if (root.max < x.high)
                    root.max = x.high;
                if (root.range.low >= x.low)
                {
                    if (root.left == null)
                    {
                        root.left = new Node(x, x.high);
                        return root;
                    }
                    else
                        this._Insert(root.left, x);
                }
                else
                {
                    if (root.right == null)
                    {
                        root.right = new Node(x, x.high);
                        return root;
                    }
                    else
                        this._Insert(root.right, x);
                }
                return root;
            }
        }
        public Node Delete(Interval x)
        {

            if (this.range.Equals(x))
            {
                this.root_replace(this, x);
            }
            return this;
        }
        public Node root_replace(Node root, Interval x)
        {
            root = this;
            root = null;
            return root;
        }
        void Max(Node root)
        {
            if (root != null && root.left != null)
                if (root.max != root.left.max && root.range.high != root.max && root.right == null)
                {
                    root.max = root.left.max;
                    Max(root.left);
                }
            if (root != null && root.right != null)
                if (root.max != root.right.max && root.range.high != root.max && root.left == null)
                {
                    root.max = root.right.max;
                    Max(root.right);
                }
        }

        public string Search(Interval x)
        {
             
            if (this.range.low >= x.low && this.range.high <= x.high)
            {
                msg += $"{x} полностью перекрывает {this.range}\n";


            }
            else if (this.range.low > x.high || this.range.high < x.low)
            {
                msg += $"{x}  перекрывает {this.range}\n";

            }
            else
            {
                msg += $"{x} не перекрывает {this.range}\n";

            }

            if (this.left != null)
            {
                this.left.Search(x);
            }
            if (this.right != null)
            {
                this.right.Search(x);
            }
            return msg;

        }
        public Node Print()
        {
            Node root = this;
            if (root == null)
            {
                return root;
            }
            if (root.left != null)
                root.left.Print();

            Console.WriteLine(root);

            if (root.right != null)
                root.right.Print();

            return root;
        }
    }
    public struct Interval
    {
        public double low, high;
        public Interval(double low, double high)
        {
            if (low > high)
            {
                double temp = high;
                high = low;
                low = temp;
            }
            this.low = low;
            this.high = high;
        }
        public override string ToString() => $"[{this.low}, {this.high}]";
    }
}