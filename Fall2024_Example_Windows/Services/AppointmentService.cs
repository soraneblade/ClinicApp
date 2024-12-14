using System;
using Fall2024_Example_Windows.Models;

namespace Fall2024_Example_Windows.Services;

public class AppointmentService
{
    private static object _lock = new object();
    public static AppointmentService Current
    {
        get
        {
            lock(_lock)
            {
                if(instance == null)
                {
                    instance = new AppointmentService();
                }
            
            }
            return instance;
        }
    }
    private static AppointmentService? instance;

    private AppointmentService(){
        instance = null;
        Appointments = new List<Appointment> 
        {
            new Appointment{Id = 1, Treatments = new List<Treatment>()},
            new Appointment{Id = 2, Treatments = new List<Treatment>()}
        };
    }

    public int LastKey
    {
        get
        {
            if(Appointments.Any())
            {
                return Appointments.Select(x => x.Id).Max();
            }
            return 0;
        }
    }


    private List<Appointment> appointments; 
    public List<Appointment> Appointments { 
        get{
            return appointments;
        } 
        set{
            if(appointments != value){
                appointments = value;
            }
        }} 

    public void AddorUpdateAppointment(Appointment appointment)
    {
            if (appointment.Id <= 0)
            {
            appointment.Id = LastKey + 1;
            Console.WriteLine($"adding appointment:{appointment.Id}");
            Appointments.Add(appointment);
            appointment.Physician.Appointments.Add(appointment);
            }
        else
        {
            Console.WriteLine($"updating appointment:{appointment.Id}");
            var appointmentToUpdate = Appointments.FirstOrDefault(p => p.Id == appointment.Id);

            appointmentToUpdate = appointment;
        } 
    }
    public Appointment? GetAppointmentById(int appointmentId)
    {
        return Appointments?.FirstOrDefault(p => p.Id == appointmentId);
    }

    public void DeleteAppointment(int id)
    {
        var appointmentToRemove = Appointments.FirstOrDefault(p => p.Id == id);
        if(appointmentToRemove != null)
        {
            Appointments.Remove(appointmentToRemove);
        }
    }

    public void DeleteAppointment(Appointment appointment)
    {
        DeleteAppointment(appointment.Id);
    }

    public List<Appointment> Search(string query)
    {
        return Appointments.Where(p => p.Physician.Name.ToUpper().Contains(query.ToUpper())).ToList();
    }

    public void CalculateAppointmentTotals(Appointment appointment)
        {
            var totalWithoutInsurance = appointment.Treatments.Sum(t => t.BasePrice);
            var totalWithInsurance = appointment.Treatments.Sum(t =>
            {
                return appointment.Patient?.InsurancePlan != null
                    ? new InsuranceService().CalculateDiscountedPrice(t, appointment.Patient.InsurancePlan)
                    : t.BasePrice;
            });

            appointment.TotalWithoutInsurance = totalWithoutInsurance;
            appointment.TotalWithInsurance = totalWithInsurance;
        }
}

