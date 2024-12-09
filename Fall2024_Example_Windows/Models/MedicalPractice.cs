using System;

namespace Fall2024_Example_Windows.Models
{
    class MedicalPractice
    {
        public List<Patient> Patients { get; private set; }
        public List<Physician> Physicians { get; private set; }

        public MedicalPractice()
        {
            Patients = new List<Patient>();
            Physicians = new List<Physician>();
        }
        public Patient CreatePatient(string name, string address, DateTime birthdate, string race, string gender)
        {
            Patient patient = new Patient(name, address, birthdate, race, gender);
            Patients.Add(patient);
            return patient;
        }
        public Physician CreatePhysician(string name, string licenseNumber, DateTime graduationDate, string specialization)
        {
            Physician physician = new Physician(name, licenseNumber, graduationDate, specialization);
            Physicians.Add(physician);
            return physician;
        }

        public void CancelAppointment(Physician physician, Appointment appointment)
        {
            if (physician.Appointments.Contains(appointment))
            {
                physician.Appointments.Remove(appointment);
                Console.WriteLine("Appointment cancelled successfully.");
            }
            else
            {
                Console.WriteLine("Error: Appointment not found.");
            }
        }

        public void RescheduleAppointment(Appointment appointment, DateTime newTime, int newDuration)
        {
            if (!IsWithinBusinessHours(newTime, newDuration))
            {
                Console.WriteLine("Error: The new time is outside business hours (8am - 5pm, Monday - Friday).");
                return;
            }

            if (!appointment.Physician.IsAvailable(newTime, newDuration))
            {
                Console.WriteLine("Error: Physician is not available at the new time.");
                return;
            }

            appointment.StartTime = newTime;
            appointment.EndTime = newTime.AddMinutes(newDuration);
            Console.WriteLine("Appointment rescheduled successfully.");
        }

        public void CreateAppointment(Physician physician, Patient patient, DateTime startTime, int durationMinutes, DateOnly day)
        {
            if (!IsWithinBusinessHours(startTime, durationMinutes))
            {
                Console.WriteLine("Error: Appointment must be within business hours (8am - 5pm, Monday - Friday).");
                return;
            }

            if (!physician.IsAvailable(startTime, durationMinutes))
            {
                Console.WriteLine($"Error: Physician {physician.Name} is already booked for this time slot.");
                return;
            }

            DateTime endTime = startTime.AddMinutes(durationMinutes);
            Appointment appointment = new Appointment(physician, patient, startTime, endTime, day);
            physician.Appointments.Add(appointment);
            Console.WriteLine($"Appointment created for {patient.Name} with Dr. {physician.Name} on {startTime}.");
        }

        private bool IsWithinBusinessHours(DateTime startTime, int durationMinutes)
        {
            DateTime endTime = startTime.AddMinutes(durationMinutes);
            if (startTime.DayOfWeek == DayOfWeek.Saturday || startTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            if (startTime.Hour < 8 || startTime.Hour >= 17)
            {
                return false;
            }
            if (endTime.Hour >= 17)
            {
                return false;
            }
            return true;
        }

        public void ShowPhysicianAppointments(Physician physician)
        {
            Console.WriteLine($"Upcoming appointments for Dr. {physician.Name}:");
            if (physician.Appointments.Count == 0)
            {
                Console.WriteLine("No upcoming appointments.");
            }
            else
            {
                foreach (var appt in physician.Appointments)
                {
                    Console.WriteLine($"Patient: {appt.Patient.Name}, Date: {appt.StartTime}, Duration: {(appt.EndTime - appt.StartTime).TotalMinutes} minutes");
                }
            }
        }
    }
}