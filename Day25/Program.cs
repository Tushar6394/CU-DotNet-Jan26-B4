// using System;
// using System.Collections.Generic;
// using System.Text.RegularExpressions;

// namespace HangManGame
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Welcome to Hangman!");

//             // Random word selection
//             string[] Words = { "om", "shivam", "sahil", "het" };
//             Random random = new Random();
//             string selectedWord = Words[random.Next(Words.Length)].ToLower();

//             int lifeLine = 6;

//             // Display word setup: _ _ _
//             char[] displayWord = new char[selectedWord.Length];
//             for (int i = 0; i < displayWord.Length; i++)
//                 displayWord[i] = '_';

//             // Store guessed letters
//             HashSet<char> guessedLetters = new HashSet<char>();

//             while (lifeLine > 0 && new string(displayWord) != selectedWord)
//             {
//                 Console.WriteLine("\nWord: " + string.Join(" ", displayWord));
//                 Console.WriteLine("Lives left: " + lifeLine);
//                 Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));

//                 Console.Write("Guess a letter: ");
//                 string tempWord = Console.ReadLine().ToLower();

//                 // Validation → only single alphabet allowed
//                 bool isLetter = Regex.IsMatch(tempWord, @"^[a-z]{1}$");
//                 if (!isLetter)
//                 {
//                     Console.WriteLine("Enter a valid single letter!");
//                     continue;
//                 }

//                 char guess = tempWord[0];

//                 // Repeated letter check
//                 if (guessedLetters.Contains(guess))
//                 {
//                     Console.WriteLine($"You already guessed '{guess}'. Try again.");
//                     continue;
//                 }

//                 // Add letter to guessed list
//                 guessedLetters.Add(guess);

//                 // Check if letter exists in word
//                 bool found = false;
//                 for (int i = 0; i < selectedWord.Length; i++)
//                 {
//                     if (selectedWord[i] == guess)
//                     {
//                         displayWord[i] = guess;
//                         found = true;
//                     }
//                 }

//                 if (found)
//                     Console.WriteLine("Correct guess!");
//                 else
//                 {
//                     Console.WriteLine("Wrong guess!");
//                     lifeLine--;
//                 }
//             }

//             Console.WriteLine("\nFinal Word: " + string.Join(" ", displayWord));

//             if (new string(displayWord) == selectedWord)
//                 Console.WriteLine($"You WON! The word was '{selectedWord}'");
//             else
//                 Console.WriteLine($"Game Over! The word was '{selectedWord}'");

//             Console.ReadKey();
//         }
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace C__Learning.Week5
// {
//     internal class Demo_FileStream
//     {
//         static void Main(string[] args)
//         {
//             try
//             {
//                 string filepath = @"C:\\Users\\Aaroh Gaur\\source\\repos\\ConsoleApp1\\C#_Learning\\Week5\\filess.txt";
//                 using FileStream fs = new FileStream(filepath, FileMode.Create);
//                 for (char c = 'A'; c <= 'Z'; c++)
//                 {
//                     fs.WriteByte((byte)c);
//                 }
//             }
//             catch(Exception e) 
//             {
//                 Console.WriteLine(e.Message);
//             }

//             try
//             {
//                 string filepath = @"C:\\Users\\Aaroh Gaur\\source\\repos\\ConsoleApp1\\C#_Learning\\Week5\\filess.txt";
//                 FileStream fs = new FileStream(filepath, FileMode.Open);
//                 bool check = true;
//                 while(check)
//                 {
//                     int a = fs.ReadByte();
//                     if(a<0) check = false;
//                     else Console.Write((char)a);
//                 }
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//             }



//         }
//     }
// }

// 

// using System;
// using System.IO;

// namespace TwentyNine
// {
//     class P
//     {
//         public static void S()
//         {
//             string filename = @"..\..\..\Week5\file.txt";

//             if (File.Exists(filename))
//             {
//                 Console.WriteLine("File already exists.");
//             }
//             else
//             {
//                 Console.WriteLine("File does not exist. Creating file...");
//                 File.Create(filename).Close(); // Close to release file lock
//             }
//         }
//     }
// }


// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace C__Learning.Week5
// {
//     internal class Demo_IO
//     {
//         static void Maina(string[] args)
//         {

//             //char c = (char)Console.Read();
//             //Console.WriteLine(c);

//             //Console.ReadLine();

//             //string s = Console.ReadLine();
//             //Console.WriteLine(s);

//             //var c = Console.ReadKey();
//             //Console.WriteLine($"{c.Modifiers} {c.Key}");

//             //byte b1 = 255;
//             //byte b2 = 2;
//             //byte b3 = (byte)(b1 & b2);
//             //Console.WriteLine(Convert.ToString(b3,2));

//             string filename = @"..\..\..\Week5\file.txt";
//             if(!File.Exists(filename)) File.Create(filename);

//             FileStream file = File.Open(filename, FileMode.Open);

//         }
//     }
// }


using System;
using System.IO;

namespace TwentyNine
{
    class P
    {
        public static void S()
        {
            string directory = @"..\..\..\Week5";
            string fileName = "file.txt";

            // Combine directory and file
            string fullPath = Path.Combine(directory, fileName);

            // Create directory if it doesn't exist
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Check if file exists
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("File not found. Creating file...");
                File.WriteAllText(fullPath, "Line 1\nLine 2\nLine 3");
            }

            // Read file using do-while loop
            using (StreamReader reader = new StreamReader(fullPath))
            {
                string line = reader.ReadLine();

                do
                {
                    if (line != null)
                    {
                        Console.WriteLine(line);
                        line = reader.ReadLine();
                    }

                } while (line != null);
            }
        }
    }
}




