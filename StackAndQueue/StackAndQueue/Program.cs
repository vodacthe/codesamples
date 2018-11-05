using System;
using System.Collections.Generic;
using System.Text;

namespace StackAndQueue
{
    class Program
    {
        /// <summary>
        /// Stack & Queue is not a data structure but it is an enforcement of policy
        /// Stack 
        /// - First in Last Out
        /// - Push (new data on top of the stack)
        /// - Pop (remove data from the top of stack)
        /// - Peak (view a copy of the top data on the stack)
        /// 
        /// Queue (enforce fairness)
        ///  - First in First Out
        ///  - Enqueue (new data on top of the stack) 
        ///  - Dequeue (remove data at the bottom of the stack)
        ///  - Peak
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // STACK
            string data = Generate(7); //Generate a string of int data
            Stack<int> stack = new Stack<int>(); 
            StackPush(data,stack); 
            PrintStack(stack);
            StackPop(stack);
            StackPeak(stack);
            Console.WriteLine("\n\nPress Enter to proceed to Queue");
            Console.ReadLine();
            Console.Clear();
            // QUEUE
            data = Generate(7); //Generate a new string of int data
            Queue<int> queue = new Queue<int>();
            EnQueue(data, queue);
            DeQueue(queue);
            PeakQueue(queue);
            Console.WriteLine("\n\nPress Enter to exit");
            Console.ReadLine();
        }
        #region Others
        private static string Generate(int lenght)
        {
            string res = "";
            Random ran = new Random();
            for (int i = 0; i < lenght; i++)
            {
                res += ran.Next(-20, 20) + " ";
            }
            return res.TrimEnd();
        }
        private static void PrintStack(Stack<int> myStack)
        {
            Console.WriteLine("=============== STACK ===============");
            foreach (int i in myStack)
                Console.WriteLine(i);
            Console.WriteLine("=====================================");
        }
        private static void PrintQueue(Queue<int> myQueue)
        {
            Console.WriteLine("=============== QUEUE ===============");
            foreach (int i in myQueue)
                Console.WriteLine(i);
            Console.WriteLine("=====================================");
        }
        #endregion

        #region Stacks
        private static void StackPush(string data, Stack<int> myStack)
        {
            Console.WriteLine("DATA: " + data);
            Console.WriteLine("*Note: you can see that the print out value is in reverse order");
            string[] values = data.Split(' ');
            foreach(string val in values)
            {
                // Insert new value on top of the Stack
                myStack.Push(int.Parse(val));
            }
            
        }
        private static void StackPop(Stack<int> myStack)
        {
            Console.Write("Please enter how many value to pop: ");
            int n = int.Parse(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                // Remove value on TOP of the Stack
                myStack.Pop();
            }
            Console.WriteLine("// POP " + n + " data from STACK");
            PrintStack(myStack);
        }
        private static void StackPeak(Stack<int> myStack)
        {
            Console.WriteLine("// PEAK from STACK " + myStack.Peek());
            PrintStack(myStack);
        }
        #endregion

        #region Queue
        private static void EnQueue(string data, Queue<int> myQ)
        {
            Console.WriteLine("DATA: " + data);
            Console.WriteLine("*Note: you can see that the print out value is in correct order");
            string[] values = data.Split(' ');
            foreach(string val in values)
            {
                // Insert new value on top of the Queue
                myQ.Enqueue(int.Parse(val));
            }
            PrintQueue(myQ);
        }
        private static void DeQueue(Queue<int> myQ)
        {
            Console.Write("Please enter how many value to DeQueue: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                // Remove value from the bottom of the Queue
                myQ.Dequeue();
            }
            Console.WriteLine("// DeQ " + n + " data from QUEUE");
            PrintQueue(myQ);
        }
        private static void PeakQueue(Queue<int> myQ)
        {
            Console.WriteLine("// PEAK from QUEUE " + myQ.Peek());
            PrintQueue(myQ);
        }
        #endregion
        
    }
}
