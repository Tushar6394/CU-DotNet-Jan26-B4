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
using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    public string Name;
    private List<Person> friends = new List<Person>();

    public Person(string name)
    {
        Name = name;
    }

    // Getter method to access friends
    public List<Person> GetFriends()
    {
        return friends;
    }

    // Add friend (undirected graph logic)
    public void AddFriend(Person friend)
    {
        // Prevent null or self-friendship
        if (friend == null || friend == this)
            return;

        // Prevent duplicate friendship
        if (!friends.Contains(friend))
        {
            friends.Add(friend);
            friend.friends.Add(this);
        }
    }
}

class SocialNetwork
{
    private List<Person> members = new List<Person>();

    public void AddMember(Person person)
    {
        members.Add(person);
    }

    public void ShowNetwork()
    {
        foreach (var person in members)
        {
            string friendNames = string.Join(", ",
                person.GetFriends().Select(f => f.Name));

            Console.WriteLine(person.Name + "-> " + friendNames);
        }
    }
}

class Program
{
    static void Main()
    {
        Person tushar = new Person("Tushar");
        Person sahil = new Person("Sahil");
        Person aman = new Person("Aman");

        SocialNetwork network = new SocialNetwork();

        network.AddMember(tushar);
        network.AddMember(sahil);
        network.AddMember(aman);

        tushar.AddFriend(sahil);
        sahil.AddFriend(aman);

        network.ShowNetwork();
    }
}
