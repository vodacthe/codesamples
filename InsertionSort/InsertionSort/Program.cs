using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Generate(15);
            Print(array);
            Console.WriteLine("PRESS ENTER TO DO INSERTION SORT");
            Console.ReadLine();
            InsertionSort(array);
            Console.WriteLine("SORT COMPLETED");
            Print(array);
            Console.WriteLine("PRESS ENTER TO QUIT");
            Console.ReadLine();
        }

        #region Sort
        private static void InsertionSort(int[] input)
        {
            for(int i = 1; i < input.Length;i++)
            {
                int key = input[i];
                int j = i - 1;
                while(j >= 0 && key < input[j])
                {
                    input[j + 1] = input[j];
                    j--;
                }
                input[j + 1] = key;
            }
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
