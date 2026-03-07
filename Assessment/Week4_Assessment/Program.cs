namespace StMemorialBilling
{
    public class Patient
    {
        public string Name{get; set;}
        public decimal BaseFee{get; set;}
        public Patient(string name, decimal baseFee)
        {
            Name = name;
            BaseFee = baseFee;
        }
        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }
    public class Impatient : Patient
    {
        public int DaysStayed{get; set;}
        public decimal DailyRate{get; set;}
        public Impatient(string name, decimal baseFee, int daysStayed, decimal dailyRate) : base(name, baseFee)
        {
            DaysStayed = daysStayed;
            DailyRate = dailyRate;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee + (DaysStayed * DailyRate);
        }
    }
    public class Outpatient : Patient
    {
        public decimal ProcedureFee{get; set;}
        public Outpatient(string name, decimal baseFee, decimal procedureFee) : base(name, baseFee)
        {
            ProcedureFee = procedureFee;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee + ProcedureFee;
        }
    }
    public class EmergencyPatient : Patient
    {
        public int SeverityLevel{get; set;}
        public EmergencyPatient(string name, decimal baseFee, int severityLevel) : base(name, baseFee)
        {
            SeverityLevel = severityLevel;
        }
        public override decimal CalculateFinalBill()
        {
            return BaseFee * SeverityLevel;
        }
    }
    internal class HospitalBilling
    {
        private readonly List<Patient> _patients = new List<Patient>();
        public void AddPatient(Patient p)
        {
            _patients.Add(p);
        }
        public void GenerateDailyReport()
        {
            Console.WriteLine("==============Daily Billing Report===============");
            foreach(var patient in _patients)
            {
                Console.WriteLine($"Patient Name: {patient.Name}, Final Bill: {patient.CalculateFinalBill():C2}");
            }
        }
        public decimal CalculateTotalRevenue()
        {
            decimal total = 0m;
            foreach(var patient in _patients)
            {
                total += patient.CalculateFinalBill();
            }
            return total;
        }
        public int GetInpatientCount()
        {
            int count = 0;
            foreach(var patient in _patients)
            {
                if(patient is Impatient)
                {
                    count++;
                }
            }
            return count;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            HospitalBilling billing = new HospitalBilling();
            billing.AddPatient(new Impatient("Tushar Singh",500m, 3, 1500m));
            billing.AddPatient(new Outpatient("Ankit Kumar", 300m, 700m));
            billing.AddPatient(new EmergencyPatient("Sahil Singh", 1000m, 4));
            billing.AddPatient(new Impatient("Aman Singh", 600m, 2, 1200m));
            billing.GenerateDailyReport();
            decimal totalRevenue = billing.CalculateTotalRevenue();
            Console.WriteLine();
            Console.WriteLine("Total Revenue: " + totalRevenue.ToString("C2"));
            int inpatientCount = billing.GetInpatientCount();
            Console.WriteLine("Total Inpatients: " + inpatientCount);
        }
    }

}
