using System;

namespace Fall2024_Example_Windows.Models
{
    public class Appointment
    {
        private int id;
        private string? name;
        public string Name {
            get{
            return name ?? string.Empty;
        } 
        set{
            name = value;
        }}

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
        
        public Appointment(Physician physician, Patient patient, DateTime startTime, DateTime endTime, DateOnly day)
        {
            this.Physician = physician;
            this.Patient = patient;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Day = day;
        }

        public override string ToString()
        {
            return $"Physician: {Physician.Name}\n" +
            $"Patient: {Patient.Name}\n" +
            $"Day: {Day}\n" +
            $"Start Time  - End Time: {StartTime} - {EndTime}"; 
        }
    }
}