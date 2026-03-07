// // using System.Runtime.CompilerServices;

// // namespace Day19Demo
// // {
// //     class DoPayment
// //     {

// //     }
// //     internal interface IProcessPayment
// //     {
// //         void ProcessPayment();
// //     }
// //     internal interface IConfirmPayment
// //     {
// //         void ConfirmPayment();
// //     }
// //     class Payments : DoPayment, IProcessPayment, IConfirmPayment
// //     {
// //         public void ConfirmPayment()
// //         {
// //             Console.WriteLine("Payment Confirmed");
// //         }
// //         public void ProcessPayment()
// //         {
// //             throw new NotImplementedException();
// //         }
// //     }
// // }

// //Collections Demo
// using System.Collections;

// namespace Collections
// {
//     internal class DemoCollections
//     {
//         static int GetFactorial(int num)
//         {
//             int fact =1;
//             for(int i=2; i<=num; i++)
//             {
//                 fact *= i;
//             }
//             return fact;
//         }
//         static void Main(string[] args)
//         {
//             Console.WriteLine(GetFactorial(5));
//             // int[] arr = {2,7,8,3,4};
//             // for(int j=0; j< arr.Length; j++)
//             // {
//             //     arr[j] += 1; 
//             //     Console.WriteLine(arr[j]);
//             // }
//             // foreach(var item in arr)
//             // {
//             //     item++;
//             //     Console.WriteLine(item);
//             // }

//         ArrayList arrayList = new ArrayList();
//         List.Add(10);
        


//             // foreach(var item in GetFactorial(5))
//             // {
//             //     Console.WriteLine(item);
//             // }
//         }
//     }
// }

// //         static void Main(string[] args)
// //         {
// //             Console.WriteLine(GetFactorial(5));
// //             foreach(var item in GetFactorial(5))
// //             {
// //                 Console.WriteLine(item);
// //             }

// //             List<int> marks = new List<int>
// //             {
                
// //                 78, 89, 56, 90, 67
// //             };
// //             marks.Add(85);
// //             marks.Insert(2, 95);
// //             Console.WriteLine(marks.Count());
// //             Console.WriteLine(string.Join(", ", marks));
// //         }
// //     }
// // }

internal class DemoCollection
    {
        public IEnumerable<int> GetFactorial(int n)
        {
            int fact =1;
            for(int i =1; i<= n ; i++)
            {
                fact *= i;
            }
            Console.WriteLine($"Factorial of {n} is {fact}");
            yield return fact;

            // Generic Collection - List
            List<int> factors = new List<int>()
            {
                44,55,66,77,88
            };
            factors.Add(99);
            factors.Remove(66);
            factors.Sort();
            factors.Reverse();
            factors.Insert(2, 100);
            factors.RemoveAt(4);
            factors.Clear();
            factors.Count();
            Console.WriteLine(string.Join(", ", factors)); 
            // what is join and why used?
            // Join is used to convert list to string with specified separator
            // here we are using ", " as separator


            // Non Generic Collection - ArrayList
            ArrayList List = new ArrayList();
            List.Add(10);
            List.Add("Hello");
            List.Add(20.5);
            List.Add(true);

            foreach(var item in List)
            {
                Console.WriteLine(item); 
            }
            List<int> intList = new List<int>()
            {
                1,2,3,4,5
            };
            foreach(var item in intList)
            {
                Console.WriteLine(item);
        }
    }
}