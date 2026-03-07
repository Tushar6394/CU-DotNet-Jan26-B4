class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get { return $"{FirstName} {LastName}"; } }
    public string Department { get; set; }
    public int Salary { get; set; }

    public Employee()
    {
        EmployeeID = 1000;
        //FullName = "Rahul Prasad"; //read only prop
        FirstName = "New";
        LastName = "Employee";
        Department = "IT";
        Salary = 25000;
    }

    //public void DisplayEmployee()
    //{
    //    Console.WriteLine($"ID - {EmployeeID}  Name - {FullName}  Department - {Department}");
    //}

    public bool IsMyCompareSalary(Employee emp)
    {
        return (this.Salary > emp.Salary);
    }

    public override string ToString()
    {
        return $"ID - {EmployeeID}  Name - {FullName}  Department - {Department}  Salary - {Salary}";
    }

}
internal class Demo02_ClassMethod
{
    static void Main(string[] args)
    {
        //int age = 22;
        //Console.WriteLine(age.ToString());

        //Employee employee1 = new Employee();
        //Console.WriteLine(employee1);
        ////employee1.DisplayEmployee();

        Employee employee2 = new Employee()
        {
            EmployeeID = 2000,
            LastName = "Singh",
            FirstName = "Tushar",
            Salary = 0,
            Department = "IT"

        };

        Console.WriteLine(employee2);

        Employee employee3 = new Employee()
        {
            EmployeeID = 2000,
            LastName = "Singh",
            Salary = 70000

        };
        Console.WriteLine(employee3);

        bool salaryGreater = employee2.IsMyCompareSalary(employee3);
        Console.WriteLine(salaryGreater);
    }
}