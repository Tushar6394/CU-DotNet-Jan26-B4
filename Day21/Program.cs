//Quest- Count the frequency of each character in a given string and display the results.
using System;
using System.Collections.Concurrent;
namespace Day21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentence = "My name is Tushar Singh and I am Learning Dot Net";
            sentence = sentence.ToLower();
            int[] counts = new int[26];

            foreach (char c in sentence)
            {
                if (c >= 'a' && c <= 'z')
                {
                    counts[c - 'a']++;
                }
            }
            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] > 0)
                {
                    Console.WriteLine($"{(char)(i + 'a')} - {counts[i]}");
                }
            }
        }
    }
}