// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// //////OOPs - Object Oriented Programming System in C#
namespace OOPs_Learning
{
    class Person  //object is always their
    {
        //data members
        string personName = string.Empty;

        //methods
        public void SetName(string name)
        {
            personName = name;
        }
         public void GetName()
        {
            Console.WriteLine($"{personName}");
        }
        //properties
        private int age;
        public int Age
        {
            get { return age; }
            set { 
                if(value >0 && value < 100)
                age = value; 
                }
        }
        //create one more property name City
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }
//        public int MyProperty { get; set; } //auto-implemented property
// # PROJECT → Create a class Employee -
// int id // PUBLIC DATA MEMBERS WITH EXPLICIT METHODS
// string name // AUTO PROPERTY
// string department // FULL PROPERTY AND CAN ASSIGN ONLY ACCOUNTS, SALES, IT
// int salary // FULL PROPERTY RANGE 5000 TO 9000 with methods
// Display() to display all properties
// do changes in previous code accordingly to test Employee class
     private string department;
        public string Department
        {
            get { return department; }
            set
            {
                if (value == "ACCOUNTS" || value == "SALES" || value == "IT")
                    department = value;
            }
        }   
        private int salary;
        public int Salary
        {
            get { return salary; }
            set
            {
                if (value >= 5000 && value <= 9000)
                    salary = value;
            }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name { get; set; } //auto-implemented property



        public void Display1()
        {
            Console.WriteLine(("Display1"));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OOPs Learning!");
            Person person1 = new Person();
            person1.SetName("Person 1"); 
            person1.GetName();  
            person1.Age = -23;
            Console.WriteLine(person1.Age);
            person1.City = "Mohali";
            Console.WriteLine(person1.City);
            //Employee class object
            Person emp1 = new Person();
            emp1.Id = 101;
            emp1.Name = "Tushar";
            emp1.Department = "CSE";
            emp1.Salary = 7500;
            Console.WriteLine($"Employee Details: ID={emp1.Id}, Name={emp1.Name}, Department={emp1.Department}, Salary={emp1.Salary}");

        }
    }
}
