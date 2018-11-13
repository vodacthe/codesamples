using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Generate(15);
            Print(array);
            Console.WriteLine("PRESS ENTER TO DO BUBBLE SORT");
            Console.ReadLine();
            BubbleSort(array);
            Console.WriteLine("SORT COMPLETED");
            Print(array);
            Console.WriteLine("PRESS ENTER TO QUIT");
            Console.ReadLine();
        }

        #region Sort
        static void BubbleSort (int[] input)
        {
            /// Check for each item in array and compare to the next item
            /// if the current item has a smaller value than the next item
            /// swap them
            for(int i=0;i < input.Length;i++)
                for(int j=i;j<input.Length;j++)
                    if(input[i] > input[j])
                        Swap(ref input[i],ref input[j]);
        }
        #endregion

        #region Others
        private static int[] Generate(int lenght)
        {
            int[] res = new int[lenght];
            Random ran = new Random();
            for (int i = 0; i < lenght; i++)
            {
                res[i] = ran.Next(-20, 20);
            }
            return res;
        }
        private static void Swap(ref int A, ref int B)
        {
            //E.g.: Swap A"10" and B"4" -> B=4+10=14 -> A=14-10=4 -> B=14-4=10 => A and B swapped
            B = A + B;
            A = B - A;
            B = B - A;
        }
        private static void Print(int[] input)
        {
            string message = "Array: ";
            foreach (int i in input)
                message += i + " ";
            Console.WriteLine(message);
        }
        #endregion
    }
}
