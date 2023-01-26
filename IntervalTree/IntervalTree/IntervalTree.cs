using System.IO;
using System;
using System.Collections.Generic;
using System.Data;

namespace IntervalTree
{
    public class Tree
    {
        Node root = null;
        public Node Insert(Interval x)
        {
            if (root == null)
            {
                root = new Node(x, x.high);
                return root;
            }
            else
            {
                this._Insert(root, x);
                return root;
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
            root = Delete_(x, root);
            Max(root);
            return root;
        }
        Node Delete_(Interval x, Node root)
        {
            
            if (root != null)
            {
                if (root.range.Equals(x))
                {
                    root = root_replace(root);
                }
                else if (root.right != null && root.right.range.Equals(x) && root.right.right == null && root.right.left == null)
                {
                    root.right = null;
                }
                else if (root.left != null && root.left.range.Equals(x) && root.left.right == null && root.left.left == null)
                {
                    root.left = null;
                }
                else if (root.range.low <= x.low && root.right != null)
                {
                    Delete_(x, root.right);
                }
                else if (root.range.low > x.low && root.left != null)
                {
                    Delete_(x, root.left);
                }
            }
            return root;
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
            }
            else if (root.left != null)
            {
                if (root.left.right != null)
                {
                    root_replace(root.left.right);
                    
                    return root;
                }
                else
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
        Node Max(Node root)
        {
            if (root != null)
            {
                if (root.left != null)
                    Max(root.left);
                if (root.right != null)
                    Max(root.right);

                root.max = root.range.high;

                if (root.right != null && root.left != null)
                {
                    if (root.range.high < root.left.range.high && root.left.range.high > root.right.range.high)
                    {
                        root.max = root.left.max;
                    }else if(root.range.high < root.right.range.high && root.left.range.high < root.right.range.high)
                    {
                        root.max = root.right.max;
                    } else
                    {
                        root.max = root.range.high;
                    }
                } else if(root.right == null && root.left != null)
                {
                    if (root.range.high < root.left.max)
                    {
                        root.max = root.left.max;
                    }
                    else
                    {
                        root.max = root.range.high;
                    }
                } else if (root.right != null && root.left == null)
                {
                    if (root.range.high < root.right.range.high)
                    {
                        root.max = root.right.max;
                    }
                    else
                    {
                        root.max = root.range.high;
                    }
                }
            }
            return root;
        }
        public string Search(Interval x)
        {
            string msg = "";
            return Search_(x, root, msg);

        }
        string Search_(Interval x, Node root, string msg)
        {

            if (root.range.low >= x.low && root.range.high <= x.high)
            {
                msg += ($"{x} полностью перекрывает {root.range}\n");
            }
            else if (root.range.low > x.high || root.range.high < x.low)
            {
                msg += ($"{x} не перекрывает {root.range}\n");
            }
            else
            {
                msg += ($"{x} частично перекрывает {root.range}\n");
            }
            if (root.left != null)
            {
                msg = Search_(x, root.left, msg);
            }
            if (root.right != null)
            {
                msg = Search_(x, root.right, msg);
            }
            return (msg);
        }
        public string Draw()
        {
            if (root != null)
                return root.Draw();
            else
                return "Дерево пустое";
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
        public override string ToString() => $"[{this.range.low}, {this.range.high}] max = {this.max}";
        public string Draw(string lvl = "", string type = "[+]", string side = "", string tree = "")
        {
            if (this != null)
            {
                tree += ($"{lvl}{type} {this} {side}\n");
                lvl += new string(' ', 3);
                if (left != null)
                    tree = left.Draw(lvl, "[-]", "L", tree);
                if (right != null)
                    tree = right.Draw(lvl, "[-]", "R", tree);
            }
            return tree;
        }
    }
}