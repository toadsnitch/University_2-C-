using System;

namespace BinTree2_2
{
    public class BinaryTree //класс, реализующий АТД «дерево бинарного поиска»
    {
        //вложенный класс, отвечающий за узлы и операции допустимы для дерева бинарного
        //поиска
        private class Node
        {
            public int inf; //информационное поле
            public Node left; //ссылка на левое поддерево
            public Node rigth; //ссылка на правое поддерево
                               //конструктор вложенного класса, создает узел дерева
            public Node(int nodeInf)
            {
                inf = nodeInf;
                left = null;
                rigth = null;
            }
            //добавляет узел в дерево так, чтобы дерево оставалось деревом бинарного поиска
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
            public static int Preorder(Node currentNode, int nodeValue, int depth) //прямой обход дерева
            {
                if (currentNode != null)
                {
                    if (currentNode.inf == nodeValue)
                    {
                        return depth;
                    }
                    int leftDepth = Preorder(currentNode.left, nodeValue, depth + 1);
                    if (leftDepth != -1)
                    {
                        return leftDepth;
                    }
                    int targetDepth = Preorder(currentNode.rigth, nodeValue, depth + 1);
                    if (targetDepth != -1)
                    {
                        return targetDepth;
                    }
                }
                return -1;
            }
        } //конец вложенного класса
        Node tree; //ссылка на корень дерева
                   //свойство позволяет получить доступ к значению информационного поля корня дерева
        public int Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }
        public BinaryTree() //открытый конструктор
        {
            tree = null;
        }
        private BinaryTree(Node currentNode) //закрытый конструктор
        {
            tree = currentNode;
        }
        public void Add(int nodeInf) //добавление узла в дерево
        {
            Node.Add(ref tree, nodeInf);
        }
        //организация различных способов обхода дерева
        public int Preorder(int nodeValue)
        {
            return Node.Preorder(tree, nodeValue, 0);
        }
    }
}
