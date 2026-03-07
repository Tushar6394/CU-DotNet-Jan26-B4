// using System.Diagnostics;
// namespace Week6Learning
// {
//     internal class Tracing
//     {
//         static int GetSum (params int[] arr)
//         {
//             if(arr.Length == 0){
//                 Trace.TraceInformation("No value passed");
//                 Trace.TraceWarning("No value passed");
//                 Trace.TraceError("No value passed");
//             }
//             else{
//                 Trace.TraceInformation($"{arr.Length} numbers passed");
//             }

//             int sum = 0;
//             for(int i = 0; i < arr.Length; i++)
//             {
//                 sum += arr[i];
//             }
//             return sum;
//         }
//         static void show()
//         {
//             Trace.WriteLine("Show method is called..");
//             Console.WriteLine("Inside Show method");
//         }
//         static void display()
//         {
//             Trace.WriteLine("Display method is called..");
//             Console.WriteLine("Inside Display method");
//         }
//         static void Main(string[] args)
//         {


//             string traceFile = @"..\..\..\trace.log";
//             var listener = new TextWriterTraceListener(traceFile);
//             Trace.Listeners.Add(listener);
//             Trace.AutoFlush = true; 

//             Trace.WriteLine(DateTime.Now);
//             Trace.WriteLine("Main is started..");


//             int[] arr = {4,5,6,7};
//             int result = GetSum(arr);
//             int result2 = GetSum(1, 2, 3, 4, 5);
//             int result3 = GetSum();

//             Console.WriteLine(result);
//             Console.WriteLine(result2);
//             Console.WriteLine(result3);

//             Trace.Listeners.Remove(listener);

//             show();
//             display(); 
//             for(int i = 0; i<10; i++)
//             {
//                 Console.WriteLine(i);
//             }
//             Trace.WriteLine("Main is completed..");

//         }
//     }
// }

///////////////Delegate////////////////////
// namespace Week6Learning
// {
//     delegate void MyDelegate();
//     internal class Demo02Delegates
//     {
//         static void MyMethod1()
//         {
//             Console.WriteLine("MyMethod1");
//         }
//         static void MyMethod2()
//         {
//             Console.WriteLine("MyMethod2");
//         }
//         static void Main (string [] args)
//         {
//             MyDelegate del1 = MyMethod1;
//             del1 += MyMethod2;
//             del1();
//             Console.WriteLine("---------");
//             del1 -= MyMethod1;
//             del1();
//         }
//     }
// }


// namespace Week6Learning
// {
//     delegate void MyDelegate();//because we want refer to an anonymous method, we need to create a delegate type
//     internal class Demo03DelegateLambda
//     {
//         static void MyMethod1()
//         {
//             Console.WriteLine("MyMethod1");
//         }
//         static void MyMethod2()
//         {
//             Console.WriteLine("MyMethod2");
//         }
//         static void Main(string[] args)
//         {
//             MyDelegate del1 = delegate ()
//             {
//                 Console.WriteLine("Anonymous method referred..");
//             };
//             del1();
//             //Lambda expression is a replacement for delegate and anonymous method.
//             MyDelegate del2 = () => Console.WriteLine("Lambda expression referred..");

//             Action act1 = () => Console.WriteLine("Action working...");

//             Action<int> act2 = (x) => Console.WriteLine("Action Working - " + x);

//             act2(10);

//             Action<int, string> act3 = (num, name) => Console.WriteLine($"Action Working - {num} {name}");

//             act3(20, "Hello");

//             Action<int, string> act4 = (num, name) => 
//             {
//                 Console.WriteLine($"Action Working - {num}");
//                 Console.WriteLine($"Action Working - {name}");
//             };
//             act4(30, "World");

//             Func<int,int> GetDouble = (x) => x * 2;

//             int result1 = GetDouble(5);
//             Console.WriteLine(result1);

//             Func<int,int, int> Getsum = (x, y) => x + y;
//         }

//     }
// }


using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Markup;
using Microsoft.VisualBasic;

///Action and Func Used.
namespace Week6Learning
{
    internal class Demo04LINQ
    {
        static void Main(string[] args)
        {
            List<int> values = new List<int>
            {
                12,13,45,46,67,68,58,59
            };
            Console.WriteLine(values.Count());

            var abovefifty = values.Where(x => x > 50).OrderByDescending(x => x);

            Console.WriteLine(string.Join(", ", abovefifty));

            List<int> abovefiftyList = values.Where(x => x > 50).ToList();

            Console.WriteLine(string.Join(", ", abovefiftyList));
        }
    }
}
