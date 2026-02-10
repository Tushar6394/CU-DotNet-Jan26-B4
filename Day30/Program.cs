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
using System.Data;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace Week6Learning
{
    delegate void MyDelegate();
    internal class Demo02Delegates
    {
        static void MyMethod1()
        {
            Console.WriteLine("MyMethod1");
        }
        static void MyMethod2()
        {
            Console.WriteLine("MyMethod2");
        }
        static void Main (string [] args)
        {
            MyDelegate del1 = MyMethod1;
            del1();
        }
    }
}
