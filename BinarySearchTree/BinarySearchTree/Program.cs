using System;

namespace BinarySearchTree
{
    class Program
    {
        static Node tree;

        static string Generator(int length)
        {
            string res = "";
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                res += rd.Next(100)+ " ";
            }
            //Console.WriteLine("Auto Generated: " + res);
            return res;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CreateNewTree();
        }

        static void CreateNewTree()
        {
            Console.Clear();
            string data = Generator(15); //Auto generate input data
            Tree.CreateTree(ref tree, data); //Populate the tree using input data
            Menu();
        }

        static void SearchNode()
        {
            Console.Clear();
            ShowTheTree();
            Console.Write("\nENTER VALUE TO SEARCH: ");
            Node result = Tree.SearchNode(tree, int.Parse(Console.ReadLine()));
            if (result != null)
            {
                Console.WriteLine("FOUND!!!");
            }
            else
            {
                Console.WriteLine("NOT FOUND!!!");
            }
            Console.WriteLine("Press Enter to return to the Menu");
            Console.ReadLine();
            Console.Clear();
            Menu();
        }

        static void TraverseAllTree()
        {
            Console.Clear();
            Console.WriteLine("BINARY TREE");
            Tree.TraverseAll(tree);
            Console.WriteLine("\nPress Enter to return to the Menu");
            Console.Read();
            Console.Clear();
            Menu();
        }

        static void ShowTheTree()
        {
            Console.Write("TREE: ");
            Tree.Traverse_LNR(tree);
            Console.WriteLine();
        }

        public delegate void Action();

        static void Check(Action action)
        {
            ShowTheTree();
            action();
            Console.WriteLine();
            Console.WriteLine("\nPress Enter to return to the Menu");
            Console.Read();
            Console.Clear();
            Menu();
        }

        static void DeleteFromTree()
        {
            Console.Write("ORIGINAL ");
            ShowTheTree();
            Console.WriteLine("IN PUT VALUE TO DELETE");
            int val = int.Parse(Console.ReadLine());
            Tree.RemoveWithValue(ref tree, val);
            Console.Write("AFTER DELETION ");
            ShowTheTree();
            Console.WriteLine();
            Console.WriteLine("\nPress Enter to return to the Menu");
            Console.Read();
            Console.Clear();
            Menu();
        }

        static void Menu()
        {
            ShowTheTree();
            Console.WriteLine("========================= PLEASE SELECT =========================");
            Console.WriteLine("1. Traverse Binary Tree");
            Console.WriteLine("2. Search for Node in Binary Tree");
            Console.WriteLine("3. Search for Node with 2 children in Binary Tree");
            Console.WriteLine("4. Search for Node with 1 child in Binary Tree");
            Console.WriteLine("5. Search for Node with NO children in Binary Tree");
            Console.WriteLine("6. Search for Node with MAX value in Binary Tree");
            Console.WriteLine("7. Search for Node with MIN value in Binary Tree");
            Console.WriteLine("8. Delete a Node Binary Tree");
            Console.WriteLine("9. Create a new Binary Tree");
            Console.WriteLine("========================= PLEASE SELECT =========================");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    TraverseAllTree();
                    break;
                case "2":
                    SearchNode();
                    break;
                case "3":
                    Check(() => Tree.NodeHas2(tree));
                    break;
                case "4":
                    Check(() => Tree.NodeHas1(tree));
                    break;
                case "5":
                    Check(() => Tree.NodeHas0(tree));
                    break;
                case "6":
                    Check(() => {
                        Console.WriteLine("MAX is: " + Tree.FindMax(tree));
                    });
                    break;
                case "7":
                    Check(() => {
                        Console.WriteLine("MIN is: " + Tree.FindMin(tree));
                    });
                    break;
                case "8":
                    DeleteFromTree();
                    break;
                case "9":
                    CreateNewTree();
                    break;
                case "0":
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
    }
}
