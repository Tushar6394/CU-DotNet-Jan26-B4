// using System;

// public class Employee
// {
//     public int EmployeeId { get; set;}
//     public string EmployeeName { get; set;}
//     public decimal BasicSalary { get; set;}
//     public int ExperienceInYears { get;}

//     public Employee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
//     {
//         EmployeeId = employeeId;
//         EmployeeName = employeeName;
//         BasicSalary = basicSalary;
//         ExperienceInYears = experienceInYears;
//     }

//     public decimal CalculateAnnualSalary()
//     {
//         return BasicSalary * 12;
//     }

//     public void DisplayEmployeeDetails()
//     {
//         Console.WriteLine($"Employee ID: {EmployeeId}, Name: {EmployeeName}, Basic Salary: {BasicSalary}, Experience: {ExperienceInYears} years");
//         Console.WriteLine($"Annual Salary: {CalculateAnnualSalary()}");
//         Console.WriteLine();
//     }
// }

// public class PermanentEmployee : Employee
// {
//     public PermanentEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
//         : base(employeeId, employeeName, basicSalary, experienceInYears)
//     {
//     }

//     public new decimal CalculateAnnualSalary()
//     {
//         decimal hra = 0.20m * BasicSalary;
//         decimal specialAllowance = 0.10m * BasicSalary;
//         decimal loyaltyBonus = ExperienceInYears >= 5 ? 50000m : 0m;
//         return (BasicSalary + hra + specialAllowance) * 12 + loyaltyBonus;
//     }
// }

// public class ContractEmployee : Employee
// {
//     public int ContractDurationInMonths { get; set; }

//     public ContractEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears, int contractDurationInMonths)
//         : base(employeeId, employeeName, basicSalary, experienceInYears)
//     {
//         ContractDurationInMonths = contractDurationInMonths;
//     }

//     public new decimal CalculateAnnualSalary()
//     {
//         decimal bonus = ContractDurationInMonths >= 12 ? 30000m : 0m;
//         return BasicSalary * 12 + bonus;
//     }
// }

// public class InternEmployee : Employee
// {
//     public InternEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
//         : base(employeeId, employeeName, basicSalary, experienceInYears)
//     {
//     }

//     public new decimal CalculateAnnualSalary()
//     {
//         return BasicSalary * 12;
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Employee emp1 = new PermanentEmployee(1, "Tushar", 50000m, 6);
//         PermanentEmployee emp2 = new PermanentEmployee(2, "Singh", 60000m, 3);

//         Console.WriteLine("emp1 (Employee ref): " + emp1.CalculateAnnualSalary()); 
//         Console.WriteLine("emp2 (Permanent ref): " + emp2.CalculateAnnualSalary()); 

//         Employee contrEmp = new ContractEmployee(3, "Sahil", 40000m, 2, 15);
//         Console.WriteLine("Contract Annual: " + contrEmp.CalculateAnnualSalary());

//         ContractEmployee contrEmpDirect = new ContractEmployee(4, "Aman", 45000m, 1, 10);
//         Console.WriteLine("Contract Direct: " + contrEmpDirect.CalculateAnnualSalary());

//         Employee intern = new InternEmployee(5, "Hrithik", 10000m, 0);
//         Console.WriteLine("Intern Annual: " + intern.CalculateAnnualSalary());

//         emp1.DisplayEmployeeDetails();
//         contrEmpDirect.DisplayEmployeeDetails();
//     }
// }
namespace Excercise2_Inheritance{

    class Employee{
       
       public int EmployeeId {get; set;}
       public string EmployeeName {get; set;}
       public decimal BasicSalary {get;set;}
       public int ExperienceInYears {get;set;}

       public Employee(int employee, string employeeName, decimal basicSalary ,int experienceInYears){

             EmployeeId = employee;
             EmployeeName = employeeName;
             BasicSalary = basicSalary;
             ExperienceInYears = experienceInYears;
       }

       public decimal CalculateAnnualSalary(){
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
       }

       public string DisplayEmployeeDetails(){
           return $"Id:{EmployeeId}, Employee Name:{EmployeeName}, Experience:{ExperienceInYears}, Annual Salary:{CalculateAnnualSalary()}";
       }
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int employee, string employeeName, decimal basicSalary ,int experienceInYears)
        : base(employee, employeeName, basicSalary, experienceInYears)
        {}
        public new decimal CalculateAnnualSalary(){
            decimal HRA = BasicSalary * 20/100;
            decimal SpecialAllowance = BasicSalary * 10/100;
            decimal Bonus = 0;
            if(ExperienceInYears >= 5){Bonus = 50000;}
            decimal AnnualSalary = (BasicSalary * 12) +  HRA + SpecialAllowance + Bonus;

            return AnnualSalary;
        }

    }

    class ContractEmployee : Employee
    {
        
        public int ContractDurationInMonths {get;set;}
        public ContractEmployee(int employee, string employeeName, decimal basicSalary ,int experienceInYears, int contractDurationInMonths)
        : base(employee, employeeName, basicSalary, experienceInYears)
        {
            ContractDurationInMonths = contractDurationInMonths;
        }

        public new decimal CalculateAnnualSalary(){
            decimal Bonus = 0;
            if(ContractDurationInMonths >= 12) {Bonus = 30000;}
            decimal AnnualSalary = (BasicSalary * 12) + Bonus;
            return AnnualSalary;
        }
    }

    class InternEmployee : Employee 
    {
        public InternEmployee(int employee, string employeeName, decimal basicSalary ,int experienceInYears)
        : base(employee, employeeName, basicSalary, experienceInYears)
        {}
        public new decimal CalculateAnnualSalary(){
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }
    }

    internal class AnnualSalary{

        public static void Main(string[] args){
            
            Employee e1 = new Employee(14479, "Tushar Singh" , 30000 , 4);
            PermanentEmployee p1 = new PermanentEmployee(13325 , "Sahil" , 15000 , 3);
            ContractEmployee c1 = new ContractEmployee(14603, "Hrithik", 35000 , 5, 12);
            InternEmployee i1 = new InternEmployee(14448, "Aman", 25000, 3);
            Console.WriteLine(e1.CalculateAnnualSalary());
            Console.WriteLine(p1.CalculateAnnualSalary());
            Console.WriteLine(c1.CalculateAnnualSalary());  
            Console.WriteLine(i1.CalculateAnnualSalary());
        }
    }
}