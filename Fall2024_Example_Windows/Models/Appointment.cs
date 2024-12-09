using System;

namespace Fall2024_Example_Windows.Models
{
    public class Appointment
    {
        public Physician Physician { get; private set; }
        public Patient Patient { get; private set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public DateOnly Day {get; set;}
        public Appointment(Physician physician, Patient patient, DateTime startTime, DateTime endTime, DateOnly day)
        {
            Physician = physician;
            Patient = patient;
            StartTime = startTime;
            EndTime = endTime;
            Day = day;
        }

        public override string ToString()
        {
            return $"Physician: {Physician}\n" +
            $"Patient: {Physician}\n" +
            $"Day: {Day}\n" +
            $"Start Time  - End Time: {StartTime} - {EndTime}"; 
        }
    }
}