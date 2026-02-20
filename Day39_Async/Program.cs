//Demo-01: Synchronous Calls
// namespace AdvCSConsole{
//     internal class Demo01AsyncCalls{
//         static void Main(string[] args){
//             Console.WriteLine("Program Started...");
//             DoSomethingSync();
//             Console.WriteLine("Doing something else...");
//             Console.WriteLine("Program Completed...");
//         }
//         static void DoSomethingSync(){
//             Console.WriteLine("Time taking task...");
//             Thread.Sleep(2000);
//             //Task.Delay(2000);
//         }
//     }
// }

//Demo-02: Asynchronous Calls

// namespace AdvCSConsole{
//     internal class Demo01AsyncCalls{
//         static async Task Main(string[] args){
//             Console.WriteLine("Program Started...");
//             var result = DoSomethingAsync();
//             Console.WriteLine("Doing something else...");
//             for(int i=0; i<100; i++){
//                 Console.WriteLine(i);
//             }
//             await result;
//             Console.WriteLine("Program Completed...");
//         }
//         static async Task DoSomethingAsync(){
//             Console.WriteLine("Time taking task...");
//             await Task.Delay(2000);
//             Console.WriteLine("Task Completed...");

//         }
//     }
// }

//Demo-03: Asynchronous Calls with Return Task
namespace AdvCSConsole{
    internal class Demo01AsyncCalls{
        static async Task Main(string[] args){
            Console.WriteLine("Program Started...");
            var task = DoSomethingAsync();
            Console.WriteLine("Doing something else...");
            for(int i=0; i<1500000; i++){
                if(task.IsCompleted){
                    Console.WriteLine("***Task Completed here***");
                    break;
                }
                Console.Write(i);
            }
            string value = await task;
            Console.WriteLine(value);
            Console.WriteLine("Program Completed...");
        }
        static async Task<string> DoSomethingAsync(){
            Console.WriteLine("Time taking task...");
            await Task.Delay(2000);
            Console.WriteLine("Task Completed...");
            return "***Task Result***";
        }
    }
}


//Demo-04 : Async Breakfast
// using System.Diagnostics;
// namespace AdvCSConsole{
//     internal class Demo04AsyncBreakfast{
//         static async Task Main(string[] args){
//             Stopwatch watch = new Stopwatch();
//             watch.Start();
//             Console.WriteLine("Preparing Breakfast...");
//             var toast = MakeToastAsync();
//             var coffee = MakeCoffeeAsync();
//             var omlette = MakeOmletteAsync();

//             Console.WriteLine("Utilizing waiting time to do something else...");
//             Console.WriteLine("Taking some short calls");
//             Console.WriteLine("Making my breakfast table ready...");

//             string[] breakfast = await Task.WhenAll(toast, coffee, omlette);

//             watch.Stop();
//             Console.WriteLine(watch.ElapsedMilliseconds);

//             foreach(var item in breakfast){
//                 Console.WriteLine(item);
//             }
//             Console.WriteLine("Completed all tasks, Breakfast is ready!");

//         }

//         static async Task<string> MakeToastAsync(){
//             await Task.Delay(3000);
//             return "Toast is ready!";
//         }

//         static async Task<string> MakeCoffeeAsync(){
//             await Task.Delay(2000);
//             return "Coffee is ready!";
//         }

//         static async Task<string> MakeOmletteAsync(){
//             await Task.Delay(4000);
//             return "Omlette is ready!";
//         }
//     }
// }
