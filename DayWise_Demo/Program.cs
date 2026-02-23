////Create a method to return the number is palindrome or not
// namespace DayWiseDemo{
//     class Program
//     {
//         static bool IsPalindrome(string word)
//         {
//             string reverse = "";
//             for(int i=word.Length-1; i>=0; i--)
//             {
//                 reverse += word[i];
//             }
//             return word == reverse;
//         }
//         static void Main()
//         {
//             Console.Write("Enter string: ");
//             string input = Console.ReadLine();
//             if (IsPalindrome(input))
//             {
//                 Console.WriteLine("It is Palindrome");
//             }
//             else
//             {
//                 Console.WriteLine("Not a Palindrome");
//             }
//         }
//     }
// }

//Using While Loop 
// namespace DayWiseDemo
// {
//     class Program
//     {
//         static bool IsPalindrome(string word)
//         {
//             string reverse = "";
//             int i = word.Length - 1;
//             while (i >= 0)
//             {
//                 reverse += word[i];
//                 i--;
//             }

//             return word == reverse;
//         }

//         static void Main()
//         {
//             Console.Write("Enter string: ");
//             string input = Console.ReadLine();

//             if (IsPalindrome(input))
//             {
//                 Console.WriteLine("It is Palindrome");
//             }
//             else
//             {
//                 Console.WriteLine("Not a Palindrome");
//             }
//         }
//     }
// }



//Fibonacci Series
// using System;

// class Program1
// {
//     // Method to print Fibonacci series
//     static void Fibonacci(int n)
//     {
//         int a = 0, b = 1, c;

//         Console.Write("Fibonacci Series: ");

//         for (int i = 1; i <= n; i++)
//         {
//             Console.Write(a + " ");

//             c = a + b;
//             a = b;
//             b = c;
//         }
//     }

//     static void Main()
//     {
//         Console.Write("Enter number of terms: ");
//         int n = Convert.ToInt32(Console.ReadLine());

//         Fibonacci(n);
//     }
// }

//Pattern Printing
// class Program2
// {
//     static void PrintPattern(int n)
//     {
//         for (int i = 1; i <= n; i++)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(j + " ");
//             }
//             Console.WriteLine();
//         }
//     }

//     static void Main()
//     {
//         Console.Write("Enter the number of rows: ");
//         int n = Convert.ToInt32(Console.ReadLine());

//         PrintPattern(n);
//     }
// }

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         for (char i = '1'; i <= '5'; i++)
//         {
//             for (char j = '1'; j <= i; j++)
//             {
//                 Console.Write(j);
//             }
//             Console.WriteLine();
//         }
//     }
// }

// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         int totalRows = 5;
//         for (int i = 1; i <= totalRows; i++)
//         {
//             for (int space = totalRows - i; space >= 1; space--)
//             {
//                 Console.Write(" ");
//             }
//             for (char j = 'A'; j < 'A' + i; j++)
//             {
//                 Console.Write(j);
//             }
//             Console.WriteLine();
//         }
//     }
// }


// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         int totalRows = 5;
//         for (int i = 1; i <= totalRows; i++)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(j);
//             }
//             Console.WriteLine();
//         }
//         for (int i = totalRows - 1; i >= 1; i--)
//         {
//             for (int j = 1; j <= i; j++)
//             {
//                 Console.Write(j);
//             }
//             Console.WriteLine();
//         }
//     }
// }

//  internal class Program
// {
//     private static void Main(string[] args)
//     {
//         for (int i = 1; i <= 5; i++, Console.WriteLine()) for (int j = 1; j <= i; j++) Console.Write(j);
//         for (int i = 4; i >= 1; i--, Console.WriteLine()) for (int j = 1; j <= i; j++) Console.Write(j);
//     }
// }

// pattern printing 1's and 0's( 1's in diagonals and 0's in other places)
// internal class Program
// {
//     private static void Main(string[] args)
//     {
//         int n = 5;
//         for (int i = 1; i <= n; i++)
//         {
//             for (int j = 1; j <= n; j++)
//             {
//                 if (i == j || j == (n - i + 1))
//                 {
//                     Console.Write("1 ");
//                 }
//                 else
//                 {
//                     Console.Write("0 ");
//                 }
//             }
//             Console.WriteLine();
//         }
//     }
// }

// Write a simple factorial program using recursion and also print all the numbers and print the values of n also in the output
//print in this format like 
//5
////3
/////2
//////1
//////2
/////6
////24
//120 
// using System;

// class Program
// {
//     static int Fact(int n, int space)
//     {
//         for (int i = 0; i < space; i++)
//             Console.Write("  ");

//         Console.WriteLine(n);

//         if (n == 1)
//             return 1;

//         int result = n * Fact(n - 1, space + 1);
//         for (int i = 0; i < space; i++)
//             Console.Write("  ");

//         Console.WriteLine(result);

//         return result;
//     }

//     static void Main()
//     {
//         int n = 5;
//         Fact(n, 0);
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.Xml;

// namespace ClassPractice
// {
//     interface IDevice
//     {
//         void Print();
//     }
//     class Printer: IDevice 
//     {
//         public void Print()
//         {
//             Console.WriteLine("Printing");
//         }
//     }
//     class InkjetPrinter: IDevice
//     {
//         public void Print()
//         {
//             Console.WriteLine("InkjetPrinter");
//         }
//     }
//     class Computer
//     {
//         private IDevice device;

//         //private Printer p = new Printer();
//         public Computer(IDevice d)
//         {
//             device = d;
//         }

//         public void StartPrinting()
//         {
//             device.Print();
//             //p.Print();
//         }
//     }
//     internal class DIP
//     {
//         static void Main(string[] args)
//         {
//             IDevice device = new InkjetPrinter();
//             IDevice device1 = new Printer();
//             Computer c = new Computer(device);
//             Computer c1 = new Computer(device1);
//             //Computer c = new Computer();
//             c.StartPrinting();
//             c1.StartPrinting();
//         }
//     }
// }


///////////////Interface Segregation Principle Example //////////////////////////
// using System;
// interface IPrinter
// {
//     void Print();
// }
// interface IScanner
// {
//     void Scan();
// }
// class SimplePrinter : IPrinter
// {
//     public void Print()
//     {
//         Console.WriteLine("Simple Printer: Printing...");
//     }
// }

// class MultiFunctionPrinter : IPrinter, IScanner
// {
//     public void Print()
//     {
//         Console.WriteLine("MultiFunction Printer: Printing...");
//     }

//     public void Scan()
//     {
//         Console.WriteLine("MultiFunction Printer: Scanning...");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         SimplePrinter sp = new SimplePrinter();
//         sp.Print();

//         Console.WriteLine();

//         MultiFunctionPrinter mp = new MultiFunctionPrinter();
//         mp.Print();
//         mp.Scan();
//     }
// }



// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// namespace CommonInsertion_Sort
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Create an array of integers for sorting
//             int[] numbers = new int[10] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

//             // Display original array elements
//             Console.WriteLine("\nOriginal Array Elements :");
//             PrintIntegerArray(numbers);

//             // Perform Insertion Sort and display the sorted array elements
//             Console.WriteLine("\nSorted Array Elements :");
//             PrintIntegerArray(InsertionSort(numbers));
//             Console.WriteLine("\n");
//         }

//         // Method implementing Insertion Sort algorithm
//         static int[] InsertionSort(int[] inputArray)
//         {
//             for (int i = 0; i < inputArray.Length - 1; i++)
//             {
//                 for (int j = i + 1; j > 0; j--)
//                 {
//                     // Swap if the element at j - 1 position is greater than the element at j position
//                     if (inputArray[j - 1] > inputArray[j])
//                     {
//                         int temp = inputArray[j - 1];
//                         inputArray[j - 1] = inputArray[j];
//                         inputArray[j] = temp;
//                     }
//                 }
//             }
//             return inputArray; // Return the sorted array
//         }

//         // Method to print integer array elements
//         public static void PrintIntegerArray(int[] array)
//         {
//             foreach (int i in array)
//             {
//                 Console.Write(i.ToString() + "  "); // Display each element followed by a space
//             }
//         }
//     }
// }


// class Loan
// {
//     public string LoanNumber { get; set; }
//     public string CustomerName { get; set; }
//     public decimal PrincipalAmount { get; set; }
//     public int TenureInYears { get; set; }

//     public Loan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
//     {
//         LoanNumber = loanNumber;
//         CustomerName = customerName;
//         PrincipalAmount = principalAmount;
//         TenureInYears = tenureInYears;
//     }

//     public decimal CalculateEMI()
//     {
//         decimal interestRate = 0.10m;
//         decimal totalAmount = PrincipalAmount + (PrincipalAmount * interestRate * TenureInYears);
//         decimal emi = totalAmount / (TenureInYears * 12);
//         return emi;
//     }
// }

// class HomeLoan : Loan
// {
//     public HomeLoan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
//         : base(loanNumber, customerName, principalAmount, tenureInYears)
//     {
//     }

//     public new decimal CalculateEMI()
//     {
//         decimal interestRate = 0.08m;
//         decimal processingFee = PrincipalAmount * 0.01m;
//         decimal totalAmount = PrincipalAmount + processingFee + (PrincipalAmount * interestRate * TenureInYears);
//         decimal emi = totalAmount / (TenureInYears * 12);
//         return emi;
//     }
// }

// class CarLoan : Loan
// {
//     public CarLoan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
//         : base(loanNumber, customerName, principalAmount, tenureInYears)
//     {
//     }

//     public new decimal CalculateEMI()
//     {
//         decimal interestRate = 0.09m;
//         decimal insuranceCharge = 15000m;
//         decimal totalAmount = PrincipalAmount + insuranceCharge + (PrincipalAmount * interestRate * TenureInYears);
//         decimal emi = totalAmount / (TenureInYears * 12);
//         return emi;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         HomeLoan h1 = new HomeLoan("H01", "A", 500000m, 20);
//         HomeLoan h2 = new HomeLoan("H02", "B", 300000m, 15);
//         CarLoan c1 = new CarLoan("C01", "C", 80000m, 5);
//         CarLoan c2 = new CarLoan("C02", "D", 60000m, 4);

//         Console.WriteLine($"Home Loan EMI: {h1.CalculateEMI():C}");
//         Console.WriteLine($"Home Loan EMI: {h2.CalculateEMI():C}");
//         Console.WriteLine($"Car Loan EMI: {c1.CalculateEMI():C}");
//         Console.WriteLine($"Car Loan EMI: {c2.CalculateEMI():C}");
//     }
// }


// using System;

// abstract class Vehicle
// {
//     public string ModelName { get; set; }

//     public abstract void Move();
//     public virtual string GetFuelStatus() => "Fuel level is stable.";
// }

// class ElectricCar : Vehicle
// {
//     public override void Move() =>
//         Console.WriteLine($"{ModelName} is running.");

//     public override string GetFuelStatus() =>
//         $"{ModelName} battery is at 80%.";
// }

// class HeavyTruck : Vehicle
// {
//     public override void Move() =>
//         Console.WriteLine($"{ModelName} is hauling cargo.");
// }

// class CargoPlane : Vehicle
// {
//     public override void Move() =>
//         Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");

//     public override string GetFuelStatus() =>
//         base.GetFuelStatus() + " Checking jet fuel reserves...";
// }

// class Program
// {
//     static void Main()
//     {
//         Vehicle[] fleet =
//         {
//             new ElectricCar { ModelName = "Tesla Model B" },
//             new HeavyTruck  { ModelName = "VolvoA "   },
//             new CargoPlane  { ModelName = "BoeingC"  }
//         };

//         foreach (Vehicle vehicle in fleet)
//         {
//             vehicle.Move();
//             Console.WriteLine(vehicle.GetFuelStatus());
//             Console.WriteLine();
//         }
//     }
// }


// using System;

// internal class BankAccount
// {
//     public string AccountHolder = "Tushar";
//     private double Balance = 5000;
//     protected string AccountType = "Savings";

//     public void ShowBalance()
//     {
//         Console.WriteLine("Balance: " + Balance);
//     }
// } 
// using System;
// class Student
// {
//     public string Name;
//     public int Age;
//     public Student()
//     {
//         Name = "Unknown";
//         Age = 0;
//         Console.WriteLine("Default Constructor Called");
//     }
//     public Student(string name, int age)
//     {
//         Name = name;
//         Age = age;
//         Console.WriteLine("Parameterized Constructor Called");
//     }
//     private Student(string name)
//     {
//         Name = name;
//         Console.WriteLine("Private Constructor Called");
//     }

//     public void Display()
//     {
//         Console.WriteLine("Name: " + Name + ", Age: " + Age);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Student s1 = new Student();
//         s1.Display();

//         Console.WriteLine();

//         Student s2 = new Student("Tushar", 21);
//         s2.Display();

//     }
// }




// using System;

// class Student
// {
//     public string Name;

//     // Constructor
//     public Student(string name)
//     {
//         Name = name;
//         PrintMessage();  
//     }

//     public void PrintMessage()
//     {
//         Console.WriteLine("Student Created: " + Name);
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Student s = new Student("Tushar");
//     }
// }



using System;

class Calculator
{
    public void CalculateArea()
    {
        const int Length = 10;
        const int Width = 5;

        int area = Length * Width;

        Console.WriteLine("Area: " + area);
    }
}

class Program
{
    static void Main()
    {
        Calculator c = new Calculator();
        c.CalculateArea();
    }
}