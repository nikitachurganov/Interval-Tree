using System;
namespace IntervalTree
{
    public class Node
    {
        public Interval range;
        public Node left, right;
        double max;
        static string msg = "";
        static string tree = "";
        static string temp = "";
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
            Node root = this;
            if (root.range.Equals(x))
            {
                root_replace(root);
                return Max(root);
            }
            else if (root.range.low <= x.low && root.right != null)
            {
                root.right.Delete(x);
                return root;
            }
            else if (root.range.low > x.low && root.left != null)
            {
                root.left.Delete(x);
                return root;
            } else
            {
                return root;
            }
        }
        Node root_replace(Node root)
        {
            if (root.right != null)
            {
                root.range = root.right.range;
                
                root.max = root.right.max;
                
                if (root.right.right != null)
                    root_replace(root.right);
                else
                    root.right = null;
                return root;
            } else if (root.left != null)
            {
                if (root.left.right != null)
                {
                    root_replace(root.left.right);
                    return root;
                } else
                {
                    root.range = root.left.range;
                    root.max = root.left.max;
                    if (root.left.left != null)
                        root_replace(root.left);
                    else
                        root.left = null;
                    return root;
                }
            }
            else if (root.right == null && root.left == null)
            {
                root = null;
                return root;
            }
 
            return root;
        }
        public Node Max(Node root)
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
            return root;
        }
        public string Search(Interval x )
        {
            temp = "";
            if (this.range.low >= x.low && this.range.high <= x.high)
            {
                msg += $"{x} полностью перекрывает {this.range}\n";
                //Console.WriteLine($"{x} полностью перекрывает {this.range}");
            }
            else if (this.range.low > x.high || this.range.high < x.low)
            {
                msg += $"{x} не перекрывает {this.range}\n";
                //Console.WriteLine($"{x} не перекрывает {this.range}");
            }
            else
            {
                msg += $"{x} частично перекрывает {this.range}\n";
                //Console.WriteLine($"{x} частично перекрывает {this.range}");
            }
            if (this.left != null)
            {
                this.left.Search(x);
            }
            if (this.right != null)
            {
                this.right.Search(x);
            }
            temp += msg;
            msg = "";
            return temp;
        }
        public string Draw(Node root, string intend = "", string type = "[+]", string side = "")
        {
            if (root != null)
            {
                Console.WriteLine($"{intend} {type} {root} {side}");
                
                intend += new string(' ', 3);
                Draw (root.left, intend, "[-]", "L");
                Draw (root.right, intend, "[-]", "R");
            }
            return tree;
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