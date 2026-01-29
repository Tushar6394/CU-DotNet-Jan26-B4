//Non-Generic Comparable Example
// namespace DAY20
// {
//     class Laptop : IComparable
//     {
//         public int LaptopID { get; set; }
//         public string Company { get; set; }
//         public string ModelName { get; set; }
//         public int Price { get; set; }
        
//         public int CompareTo(object? obj)
//         {
//             Laptop Other = (Laptop)obj;
//             return this.LaptopID.CompareTo(Other.LaptopID);
//         }
//         public override string ToString()
//         {
//             return $"LaptopID: {LaptopID}, Company: {Company}, ModelName: {ModelName}, Price: {Price}";
//         }

//         // METHOD 1
//         //public Laptop(int laptopID, string Company, string ModelName, int Price)
//         //{
//         //    LaptopID = laptopID;
//         //    Company = Company;
//         //    ModelName = ModelName;
//         //    Price = Price;
//         //}
//     }

//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             // METHOD 1
//             //List<Laptop> laptops = new List<Laptop>
//             //{
//             //    new Laptop (101,"jhdb","wdjn",100000),
//             //    new Laptop (101,"jhdb","wdjn",100000),
//             //    new Laptop (101,"jhdb","wdjn",100000)
//             //};

//             // METHOD 2
//             //List<Laptop> laptops = new List<Laptop>();
//             ////Laptop l1 = new Laptop(101,"Dell", "Abc11", 100000);
//             //Laptop l1 = new Laptop()
//             //{
//             //    LaptopID = 101,
//             //    Company = "abc",
//             //    ModelName = "abc",
//             //    Price = 100000
//             //};
//             //Laptop l2 = new Laptop()
//             //{
//             //    LaptopID = 102,
//             //    Company = "abc",
//             //    ModelName = "abc",
//             //    Price = 20000000
//             //};
//             //laptops.Add(l1);
//             //laptops.Add(l2);

//             // METHOD 3
//             Laptop[] laptops = new Laptop[]
//             {
//                 new Laptop()
//                 {
//                     LaptopID = 102,
//                     Company = "ABC",
//                     ModelName = "ABCD",
//                     Price = 100,
//                 },
//                 new Laptop()
//                 {
//                     LaptopID = 99,
//                     Company = "AB",
//                     ModelName = "ABCS",
//                     Price = 1000,
//                 },
//                 new Laptop()
//                 {
//                     LaptopID = 45,
//                     Company = "ABC",
//                     ModelName = "ABCD",
//                     Price = 10000,
//                 }
//             };
//             Array.Sort(laptops);
//             foreach(var laptop in laptops)
//             {
//                 Console.WriteLine(laptop); 
//             }
//             Console.WriteLine("Done");
//         }
//     }
// }



//Generic Comparable Example give me same code for generic comparable like above
namespace DAY20
{
    class Laptop : IComparable<Laptop>
    {
        public int LaptopID { get; set; }
        public string Company { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
        
        //Generic Collection
        public int CompareTo(Laptop? other)
        {
            return this.LaptopID.CompareTo(other.LaptopID);
        }
        //Non-Generic Collection
        // public int CompareTo(object? obj)
        // {
        //     Laptop other = (Laptop)obj;
        //     return this.LaptopID.CompareTo(other.LaptopID);
        // }}
        public override string ToString()
        {
            return $"LaptopID: {LaptopID}, Company: {Company}, ModelName: {ModelName}, Price: {Price}";
        }

        class LaptopPriceSorter : IComparer<Laptop>
        {
            public int Compare(Laptop? x, Laptop? y)
            {
                return x.Price.CompareTo(y.Price);
            }
        }
         class LaptopCompanySorter : IComparer<Laptop>
        {
            public int Compare(Laptop? x, Laptop? y)
            {
                return x.Company.CompareTo(y.Company);
            }
        }

        // METHOD 1
        //public Laptop(int laptopID, string Company, string ModelName, int Price)
        //{
        //    LaptopID = laptopID;
        //    Company = Company;
        //    ModelName = ModelName;
        //    Price = Price;
        //}
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // METHOD 1
            //List<Laptop> laptops = new List<Laptop>
            //{
            //    new Laptop (101,"jhdb","wdjn",100000),
            //    new Laptop (101,"jhdb","wdjn",100000),
            //    new Laptop (101,"jhdb","wdjn",100000)
            //};

            // METHOD 2
            List<Laptop> laptops = new List<Laptop>();
            //Laptop l1 = new Laptop(101,"Dell", "Abc11", 100000);
            Laptop l1 = new Laptop()
            {
               LaptopID = 105,
               Company = "abc",
               ModelName = "abc",
               Price = 100000
            };
            Laptop l2 = new Laptop()
            {
               LaptopID = 102,
               Company = "abc",
               ModelName = "abc",
               Price = 20000000
            };
            laptops.Add(l1);
            laptops.Add(l2);

            // METHOD 3
            // Laptop[] laptops = new Laptop[]
            // {
            //     new Laptop()
            //     {
            //         LaptopID = 102,
            //         Company = "ABC",
            //         ModelName = "ABCD",
            //         Price = 100,
            //     },
            //     new Laptop()
            //     {
            //         LaptopID = 99,
            //         Company = "AB",
            //         ModelName = "ABCS",
            //         Price = 1000,
            //     },
            //     new Laptop()
            //     {
            //         LaptopID = 45,
            //         Company = "ABC",
            //         ModelName = "ABCD",
            //         Price = 10000,
            //     }
            // };
            //Array.Sort(laptops);
            // IComparer priceSorter = new Laptop.LaptopPriceSorter();
            // laptops.Sort(priceSorter);
            laptops.Sort(new Laptop.LaptopPriceSorter());
            foreach(var laptop in laptops)
            {
                Console.WriteLine(laptop); 
            }
            Console.WriteLine("Done");
        }
    }
}