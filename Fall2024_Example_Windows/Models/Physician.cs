using System;

namespace Fall2024_Example_Windows.Models
{
    public class Physician
    {

        public int Id{get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime GraduationDate { get; set; }
        public string Specialization { get; set; }
        public List<Appointment> Appointments { get; set; }

        public Physician(){}
        public Physician(string name, string licenseNumber, DateTime graduationDate, string specialization)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            GraduationDate = graduationDate;
            Specialization = specialization;
            Appointments = new List<Appointment>();
        }
        public bool IsAvailable(DateTime startTime, int durationMinutes)
        {
            DateTime endTime = startTime.AddMinutes(durationMinutes);
            foreach (var appt in Appointments)
            {
                if (appt.StartTime < endTime && startTime < appt.EndTime)
                {
                    return false;
                }
            }
            return true;
        }
                //ToString override that we use when displaying the model in the MAUI views
        public override string ToString()
        {
            return $"{Name}";
        }
    }
    
}