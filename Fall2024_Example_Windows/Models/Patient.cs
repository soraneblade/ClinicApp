using System;
namespace Fall2024_Example_Windows.Models
{
    //Model Class for Patients
    public class Patient
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
        public DateTime Birthday{get; set;}
        public string? Address{get; set;}
        public string? Race {get; set;}
        public string? Gender {get; set;}
        public string? SSN{get; set;}
        public InsurancePlan InsurancePlan { get; set; }
        public Patient()
        {
            Name = string.Empty;
            Address = string.Empty;
            Birthday = DateTime.MinValue;
            SSN = string.Empty;
        }
        public Patient(string name, string address, DateTime birthdate, string race, string gender)
        {
            this.Name = name;
            this.Address = address;
            this.Birthday = birthdate;
            this.Race = race;
            this.Gender = gender;
        }
        //ToString override that we use when displaying the model in the MAUI views
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}