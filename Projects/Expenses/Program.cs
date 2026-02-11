// //Implementing the expense splitter using Queue.


using System;
using System.Reflection.Metadata.Ecma335;
namespace BillingProject
{
    internal class ExpenseSplitter
    {
        static List<string> SettleExpenseShare(Dictionary<string, double> expenses)
        {
            List<string> settlement = new List<string>();

            //Creditors and Debitors
            Queue<KeyValuePair<string, double>> receivers = new Queue<KeyValuePair<string, double>>();
            Queue<KeyValuePair<string, double>> payers = new Queue<KeyValuePair<string, double>>();


            //total expense, share per person
            var totalExpense = expenses.Values.Sum();
            var persons = expenses.Count;
            var share = totalExpense / persons;

            //polpulate payers and receivers queues

            foreach(var person in expenses)
            {
                if(person.Value > share)
                {
                    receivers.Enqueue(
                        new KeyValuePair<string, double>(person.Key, person.Value - share)
                    );
                }
                else if (person.Value < share)
                {
                    payers.Enqueue(
                        new KeyValuePair<string, double>(person.Key, Math.Abs(person.Value - share))
                    );
                }
            }

            //settlement expenses
            while(receivers.Count > 0 && payers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();

                var amount = Math.Min(payer.Value, receiver.Value);

                settlement.Add($"{payer.Key}, {receiver.Key}, {amount}"); 

                if(payer.Value > amount)
                    payers.Enqueue(new KeyValuePair<string, double>(payer.Key, Math.Abs(payer.Value - amount)));

                if(receiver.Value > amount)
                    receivers.Enqueue(new KeyValuePair<string, double>(receiver.Key, Math.Abs(amount - receiver.Value)));

            }


            return settlement;
        }

        static void Main(string[] args)
        {
            Dictionary<string, double> expenses = new Dictionary<string, double>()
            {
                {"Aman", 900},
                {"Sunil", 0},
                {"Kartik", 1290}
            };
            List<string> settlement = SettleExpenseShare(expenses);
            foreach(var payment in settlement)
            {
                Console.WriteLine(payment);
            }
            // settlement item - from, to, amount
        }
    }
}


//Bubble Sort Logic in C#
// namespace Week6Learning
// {
//     internal class Demo01BubbleSort
//     {
//         static void Main(string[] args)
//         {

//             int[] arr = { 5, 2, 9, 1, 5, 6 };

//             for (int i = 0; i < arr.Length - 1; i++)
//             {
//                 for (int j = 0; j < arr.Length - i - 1; j++)
//                 {
//                     if (arr[j] > arr[j + 1])
//                     {
//                         // Swap arr[j] and arr[j+1]
//                         int temp = arr[j];
//                         arr[j] = arr[j + 1];
//                         arr[j + 1] = temp;
//                     }
//                 }
//             }

//             Console.WriteLine("Sorted array:");
//             foreach (int num in arr)
//             {
//                 Console.Write(num + " ");
//             }
//         }
//     }
// }

//Insertion Sort Logic in C#
// using System;

// class Program
// {
//     static void Main()
//     {
//         int[] arr = { 5, 3, 8, 4, 2 };

//         // Insertion Sort
//         for (int i = 1; i < arr.Length; i++)
//         {
//             int key = arr[i];
//             int j = i - 1;

//             while (j >= 0 && arr[j] > key)
//             {
//                 arr[j + 1] = arr[j];
//                 j--;
//             }

//             arr[j + 1] = key;
//         }

//         // Print sorted array
//         foreach (int num in arr)
//         {
//             Console.Write(num + " ");
//         }
//     }
// }

