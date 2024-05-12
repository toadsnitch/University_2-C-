using System;

namespace BinTree3
{
    public class BinaryTree //класс, реализующий АТД «дерево бинарного поиска»
    {
        //вложенный класс, отвечающий за узлы и операции допустимы для дерева бинарного
        //поиска
        private class Node
        {
            public int inf; //информационное поле
            public int counter;
            public Node left; //ссылка на левое поддерево
            public Node rigth; //ссылка на правое поддерево

            public Node(int nodeInf)
            {
                inf = nodeInf;
                counter = 1;
                left = null;
                rigth = null;
            }

            public static void Add(ref Node currentNode, int nodeInf)
            {
                if (currentNode == null)
                {
                    currentNode = new Node(nodeInf);
                }
                else
                {
                    if (((IComparable)(currentNode.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref currentNode.left, nodeInf);
                    }
                    else
                    {
                        Add(ref currentNode.rigth, nodeInf);
                    }
                }
            }

            public static void Preorder(Node currentNode)
            {
                if (currentNode != null)
                {
                    Console.Write("({0}) ", currentNode.inf);
                    Preorder(currentNode.left);
                    Preorder(currentNode.rigth);
                }
            }
            public static void Part(ref Node currentNode, int targetPosition) //Метод, который ищет узел, что должен стать корнем дерева
            {
                int x = (currentNode.left == null) ? 0 : currentNode.left.counter;
                if (x > targetPosition)
                {
                    Part(ref currentNode.left, targetPosition);
                    RotationRigth(ref currentNode);
                    //Console.WriteLine("Ротация вправо");
                }
                if (x < targetPosition)
                {
                    Part(ref currentNode.rigth, targetPosition - x - 1);
                    //Console.WriteLine("Ротация влево");
                    RotationLeft(ref currentNode);
                }                 
            }
            public static void Balancer(ref Node currentNode)
            {
                if (currentNode == null || currentNode.counter == 1) return;
                Part(ref currentNode, currentNode.counter / 2);
                Balancer(ref currentNode.left);
                Balancer(ref currentNode.rigth);

            }

            public static void RotationRigth(ref Node currentNode)
            {
                Node x = currentNode.left;
                currentNode.left = x.rigth;
                x.rigth = currentNode;

                Count(ref currentNode);
                Count(ref x);

                currentNode = x;
            }

            public static void RotationLeft(ref Node currentNode)
            {
                Node x = currentNode.rigth;
                currentNode.rigth = x.left;
                x.left = currentNode;

                Count(ref currentNode);
                Count(ref x);

                currentNode = x;
            }

            public static void InsertToRoot(ref Node currentNode, int item)
            {
                if (currentNode == null)
                {
                    currentNode = new Node(item);
                }
                else
                {
                    currentNode.counter++;
                    if (((IComparable)(currentNode.inf)).CompareTo(item) > 0)
                    {
                        InsertToRoot(ref currentNode.left, item);
                        RotationRigth(ref currentNode);
                    }
                    else
                    {
                        InsertToRoot(ref currentNode.rigth, item);
                        RotationLeft(ref currentNode);
                    }
                }
            }

            public static void Count(ref Node currentNode)
            {
                currentNode.counter = 1;
                if (currentNode.left != null) currentNode.counter += currentNode.left.counter;
                if (currentNode.rigth != null) currentNode.counter += currentNode.rigth.counter;
            }

        }

        Node tree;

        public BinaryTree()
        {
            tree = null;
        }

        public void Add(int nodeInf)
        {
            Node.Add(ref tree, nodeInf);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }

        public void Balancer()
        {
            Node.Balancer(ref tree);
        }

        public bool IsBalanced()
        {
            return IsBalanced(tree);
        }

        private bool IsBalanced(Node node)
        {
            if (node == null)
                return true;

            int leftHeight = Height(node.left);
            int rightHeight = Height(node.rigth);

            return (Math.Abs(leftHeight - rightHeight) <= 1) && IsBalanced(node.left) && IsBalanced(node.rigth);
        }

        private int Height(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(Height(node.left), Height(node.rigth));
        }

    }
}
