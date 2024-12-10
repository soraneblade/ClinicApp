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
            new Appointment{Id = 1, Name = "John Doe"},
            new Appointment{Id = 2, Name = "Jane Doe"}
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
            if (appointment.Id < 0)
            {
            appointment.Id = LastKey + 1;
            Appointments.Add(appointment);
            }
        else
        {
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
        return Appointments.Where(p => p.Name.ToUpper().Contains(query.ToUpper())).ToList();
    }
}

