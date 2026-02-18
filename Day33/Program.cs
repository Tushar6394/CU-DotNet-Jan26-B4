//modify in this code like we have to check if the person exists in the network before adding them as a friend and also handle the case of trying to add a friend who is not a member of the network.

// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Person
// {
//     public string Name;
//     private List<Person> friends = new List<Person>();

//     public Person(string name)
//     {
//         Name = name;
//     }
//     // Getter method to access friends
//     public List<Person> GetFriends()
//     {
//         return friends;
//     }
//     // Add friend (undirected graph logic)
//     public void AddFriend(Person friend)
//     {
//         // Prevent null or self-friendship
//         if (friend == null || friend == this)
//             return;

//         // Prevent duplicate friendship
//         if (!friends.Contains(friend))
//         {
//             friends.Add(friend);
//             friend.friends.Add(this);
//         }
//     }
// }
// class SocialNetwork
// {
//     private List<Person> members = new List<Person>();

//     public void AddMember(Person person)
//     {
//         members.Add(person);
//     }
//     public void ShowNetwork()
//     {
//         foreach (var person in members)
//         {
//             string friendNames = string.Join(", ",
//                 person.GetFriends().Select(f => f.Name));

//             Console.WriteLine(person.Name + "-> " + friendNames);
//         }
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Person tushar = new Person("Tushar");
//         Person sahil = new Person("Sahil");
//         Person aman = new Person("Aman");

//         SocialNetwork network = new SocialNetwork();

//         network.AddMember(tushar);
//         network.AddMember(sahil);
//         network.AddMember(aman);

//         tushar.AddFriend(sahil);
//         sahil.AddFriend(aman);

//         network.ShowNetwork();
//     }
// }

// using System;
// using System.Collections.Generic;
// using System.Linq;
// namespace SocialNetworkApp
// {
//     class Person
//     {
//         public string Name;
//         private List<Person> friends = new List<Person>();

//         public Person(string name)
//         {
//             Name = name;
//         }
//         public List<Person> GetFriends()
//         {
//             return friends;
//         }
//         public void AddFriend(Person friend, SocialNetwork network)
//         {
//             if (!network.IsMember(friend))
//             {
//                 Console.WriteLine($"{friend.Name} is not a member of the network. Cannot add as a friend.");
//                 return;
//             }

//             if (friend == null || friend == this)
//                 return;
//             if (!friends.Contains(friend))
//             {
//                 friends.Add(friend);
//                 friend.friends.Add(this);
//             }
//         }
//     }
//     class SocialNetwork
//     {
//         private List<Person> members = new List<Person>();

//         public void AddMember(Person person)
//         {
//             members.Add(person);
//         }

//         public bool IsMember(Person person)
//         {
//             return members.Contains(person);
//         }

//         public void ShowNetwork()
//         {
//             foreach (var person in members)
//             {
//                 string friendNames = string.Join(", ",
//                     person.GetFriends().Select(f => f.Name));

//                 Console.WriteLine(person.Name + " -> " + friendNames);
//             }
//         }
//     }
//     class Program
//     {
//         static void Main()
//         {
//             Person tushar = new Person("Tushar");
//             Person sahil = new Person("Sahil");
//             Person aman = new Person("Aman");
//             Person sam = new Person("Sam");

//             SocialNetwork network = new SocialNetwork();

//             network.AddMember(tushar);
//             network.AddMember(sahil);
//             network.AddMember(aman);
//             network.AddMember(sam);
//             tushar.AddFriend(sahil, network); 
//             sahil.AddFriend(aman, network);  
//             tushar.AddFriend(sam, network); 

//             network.ShowNetwork();
//         }
//     }
// }

//explain me about the Insertion sort algorithm and its time complextity in C# in hinglish
//Insertion Sort ek simple sorting algorithm hai jo ki array ko sort karne ke liye use hota hai. Is algorithm mein, hum array ke elements ko ek ek karke lete hain aur unhe sahi position par insert karte hain.
//Insertion Sort ka time complexity O(n^2) hota hai, kyunki worst case mein hume har element ko compare karna padta hai aur insert karna padta hai. Best case mein, jab array already sorted hota hai, to time complexity O(n) hota hai. Average case mein bhi time complexity O(n^2) hota hai.
//Insertion Sort ka use tab hota hai jab array chhota hota hai ya phir jab array already partially sorted hota hai. Is algorithm ka advantage ye hai ki ye in-place sorting algorithm hai, matlab extra space ki zarurat nahi hoti. Lekin agar array bada hai to Insertion Sort efficient nahi hota, isliye uske jagah Quick Sort ya Merge Sort jaise algorithms use kiye jate hain.
//Example of Insertion Sort in C#
using System;
class InsertionSort
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            // Move elements of arr[0..i-1], that are greater than key,
            // to one position ahead of their current position
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

    public static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6 };
        Sort(arr);
        Console.WriteLine("Sorted array: " + string.Join(", ", arr));
    }
}

