using System;
using GreetingLibrary;

Console.Write("Enter your name: ");
string name = Console.ReadLine();

string message = GreetingHelper.GetGreeting(name);

Console.WriteLine(message);
