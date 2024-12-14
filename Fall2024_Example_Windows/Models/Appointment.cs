using System;

namespace Fall2024_Example_Windows.Models
{
    public class Appointment
    {
        private int id;
        public int Id {
            get{
                return id; 
            } 
            set{
                id = value; 
            }
        }
        public Appointment()
        {
            Physician = new Physician();
            Patient = new Patient();
            StartTime = DateTime.MinValue;
            EndTime = StartTime.AddDays(1);
        }
        public Physician Physician { get; set; }
        public Patient Patient { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateOnly Day {get; set;}
        public List<Treatment> Treatments { get; set; } // List of treatments for the appointment
        public decimal TotalWithoutInsurance { 
            get
            {
                return CalculateTotalWithoutInsurance();
            } 
            set {}
            } // Total cost before insurance
        public decimal TotalWithInsurance { 
            get
            {
                return CalculateTotalWithInsurance();
            }
            set {} 
            } 
        public Appointment(Physician physician, Patient patient, DateTime startTime, DateTime endTime, DateOnly day)
        {
            this.Physician = physician;
            this.Patient = patient;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Day = day;
        }

        public decimal CalculateTotalWithoutInsurance(){
            decimal total = new decimal();
            foreach(Treatment t in Treatments)
            {
                total += t.BasePrice;
            }
            return total;
        }

        public decimal CalculateTotalWithInsurance(){
            decimal total = TotalWithoutInsurance;
            if(Patient != null){
                if(Patient.InsurancePlan != null){
                total = 0;
                foreach(Treatment t in Treatments)
                {
                    total += t.BasePrice - (t.BasePrice * (Patient.InsurancePlan.DiscountPercentage/100));
                }
                }
            }
                return total;
        }

        public override string ToString()
        {
            return $"ID: {Id} Physician: {Physician.Name}\n" +
            $"Patient: {Patient.Name}\n" +
            $"Day: {Day}\n" +
            $"Start Time  - End Time: {StartTime} - {EndTime}\n" +
            $"Total Before Insurance: {TotalWithoutInsurance}\n" +
            $"Total After Insurance: {TotalWithInsurance}"; 
        }
    }
}