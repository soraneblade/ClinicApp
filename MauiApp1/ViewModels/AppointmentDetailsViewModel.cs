using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;

namespace MauiApp1.ViewModels;

public class AppointmentDetailsViewModel : INotifyPropertyChanged
{
    public List<Patient> Patients {get; set;}

    public Physician Physician { 
        get
        {
            return Model.Physician;
        }

        set
        {
            Model.Physician = value;
        }
    }
	public Patient Patient { 
        get
        {
            return Model.Patient;
        }

        set
        {
            Model.Patient = value;
        }
    }
    public DateTime StartTime { 
        get
        {
            return Model.StartTime;
        }

        set
        {
            Model.StartTime = value;
        }
    }
    public DateTime EndTime { 
        get
        {
            return Model.EndTime;
        }

        set
        {
            Model.EndTime = value;
        }
    }
    public Appointment Model { get; set; }

    public void Add()
    {
        if (Model.Id <= 0)
        {
            AppointmentService.Current.AddorUpdateAppointment(Model);
        }
    }

    public AppointmentDetailsViewModel (int appointmentId)
    {
        if(appointmentId <=0)
        {
            Model = new Appointment();
        }
        else
        {
            Model = AppointmentService.Current.GetAppointmentById(appointmentId);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }