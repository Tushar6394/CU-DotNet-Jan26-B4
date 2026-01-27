using System;

namespace Day18_LoanEMICalculation
{
    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }

        public Loan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principalAmount;
            TenureInYears = tenureInYears;
        }

        public decimal CalculateEMI()
        {
            decimal interestRate = 0.10m;
            decimal totalAmount = PrincipalAmount + (PrincipalAmount * interestRate * TenureInYears);
            decimal emi = totalAmount / (TenureInYears * 12);
            return emi;
        }
    }

    class HomeLoan : Loan
    {
        public HomeLoan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
            : base(loanNumber, customerName, principalAmount, tenureInYears)
        {
        }

        public new decimal CalculateEMI()
        {
            decimal interestRate = 0.08m;
            decimal processingFee = PrincipalAmount * 0.01m;
            decimal totalAmount = PrincipalAmount + processingFee + (PrincipalAmount * interestRate * TenureInYears);
            decimal emi = totalAmount / (TenureInYears * 12);
            return emi;
        }
    }

    class CarLoan : Loan
    {
        public CarLoan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
            : base(loanNumber, customerName, principalAmount, tenureInYears)
        {
        }

        public new decimal CalculateEMI()
        {
            decimal interestRate = 0.09m;
            decimal insuranceCharge = 15000m;
            decimal totalAmount = PrincipalAmount + insuranceCharge + (PrincipalAmount * interestRate * TenureInYears);
            decimal emi = totalAmount / (TenureInYears * 12);
            return emi;
        }
    }

    class Program
    {
        static void Main()
        {
            Loan[] loans =
            {
                new HomeLoan("H01", "A", 5000000m, 20),
                new HomeLoan("H02", "B", 3000000m, 15),
                new CarLoan("C01", "C", 800000m, 5),
                new CarLoan("C02", "D", 600000m, 4)
            };

            foreach (var loan in loans)
            {
                decimal emi;

                if (loan is HomeLoan homeLoan)
                {
                    emi = homeLoan.CalculateEMI();
                }
                else if (loan is CarLoan carLoan)
                {
                    emi = carLoan.CalculateEMI();
                }
                else
                {
                    emi = loan.CalculateEMI();
                }
                Console.WriteLine($"EMI: {emi:C}");
            }
        }
    }
}
//Learn the inheritance concept and complete the Main method to create objects of each derived class and calculate their EMIs. Dynamically typed references should be used to call the CalculateEMI method.