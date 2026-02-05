// //code of numerical formatting
// using System;
// using System.Globalization;
// namespace numericalformatting
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             double number = 1234567.89;
//             Console.WriteLine(number.ToString("C", CultureInfo.CurrentCulture));
//             Console.WriteLine(number.ToString("F2"));
//             Console.WriteLine(number.ToString("E2"));
//             Console.WriteLine((number / 10000000).ToString("P2"));
//             Console.WriteLine(number.ToString("#,##0.00"));
//         }
//     }
// }

//Quest-flaten a 5*5 2D array to 1D array by using a row first approach
using System;
namespace twoDto1D{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D =
            {
                {1,2,3,4,5},
                {6,7,8,9,10},
                {11,12,13,14,15},
                {16,17,18,19,20},
                {21,22,23,24,25}
            };
            int rows = array2D.GetLength(0);
            int cols = array2D.GetLength(1);
            int[] array1D = new int[rows * cols];
            int index = 0;
            for(int i = 0; i<rows; i++)
            {
                for(int j=0; j<cols; j++)
                {
                    array1D[index++] = array2D[i,j];
                }
            }
            Console.WriteLine("1D Array:");
            foreach(var item in array1D)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        
    }
}