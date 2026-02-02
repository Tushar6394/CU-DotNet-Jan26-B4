// //create a 5x5 array and fill it with random numbers from 1 to 100 using r.Next() and also use dictionary list
// // using System;
// // using System.Data;
// // using System.Globalization;
// // namespace Day23RandomArray
// // {
// //     class Program
// //     {
// //         static void Main(string[] args)
// //         {
// //             int[,] array = new int[5,5];
// //             List<int> list = new List<int>();
// //             for(int i=1; i<26; i++)
// //             {
// //                 list.Add(i);
// //             }

// //             for(int i=0; i<list.Count; i++)
// //             {
// //                 int randomIndex = new Random().Next(i, list.Count);
// //                 int temp = list[i];
// //                 list[i]=list[randomIndex];
// //                 list[randomIndex]=temp;
// //             }
// //             int index=0;
// //             for(int row=0; row<5; row++)
// //             {
// //                 for(int col=0; col<5; col++)
// //                 {
// //                     array[row, col] = list[index];
// //                     index++;
// //                 }
// //             }
// //             for(int row=0; row<5; row++)
// //             {
// //                 for(int col=0; col<5; col++)
// //                 {
// //                     Console.Write(array[row, col].ToString()+"\t");
// //                 }
// //                 Console.WriteLine();
// //             }
// //          }
// //     } 
// // }
// //create a 5x5 array and fill it with random numbers from 1 to 100 using r.Next() dont repeat the numbers

// using System;
// namespace Day23RandomArray
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             int[,] array = new int[5, 5];
//             Random r = new Random();
//             HashSet<int> usedNumbers = new HashSet<int>();

//             for (int i = 0; i < 5; i++)
//             {
//                 for (int j = 0; j < 5; j++)
//                 {
//                     int num;
//                     do
//                     {
//                         num = r.Next(1, 26);
//                     } while (usedNumbers.Contains(num));
//                     usedNumbers.Add(num);
//                     array[i, j] = num;
//                 }
//             }

//             for (int i = 0; i < 5; i++)
//             {
//                 for (int j = 0; j < 5; j++)
//                 {
//                     Console.Write(array[i, j] + "\t");
//                 }
//                 Console.WriteLine();
//             }
//         }
//     }
// }


//Day23-->. Try, Catch 

namespace OOPSLearning
{

    class SalaryOutOfRangeException : Exception
    {
        public SalaryOutOfRangeException(string message):base(message)
        {
            
        }
    }
    internal class Demo15Exceptions
    {
        static void CheckException()
        {
            try
            {
                Console.WriteLine("Trying to use finally");
                throw new DivideByZeroException("You tried to divide by zero");
                // return;

            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Handle most generic exception");
            }
            catch
            {
                Console.WriteLine("Exception");
            }
            finally
            {
                Console.WriteLine("Inside CheckException Finally");
            }
            Console.WriteLine("After Finally in CheckException");
        }
        static int GetDiv(int x, int y)
        {            
            int[] arr = {2,3,4 };
            try
            {
                return arr[5]; // x/y;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("DivideByZeroException");
            }
            finally
            {
                Console.WriteLine("finally of Method");
            }
            
            return x/y;            
        }
        static void Main(string[] args)
        {
            try
            {
                //int salary = 123456;

                //if(salary > 100000)
                //{
                //    throw new SalaryOutOfRangeException(
                //        "Salary is too high...");
                //}

                CheckException();
                //int result = GetDiv(15, 0);
                //int[] arr = { 1, 2, 3 };
                //return;
                //Console.WriteLine(arr[5]);
            }            
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZeroException - "
                        + ex.Message);
            }
            catch(SalaryOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message + " - " 
                    + ex.StackTrace);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Handling Generic Exception in Main - "
                            + ex.Message + " - "
                    + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Inside Finally");
            }
            Console.WriteLine("Done");
        }
    }
}