using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;

namespace MauiApp1.ViewModels;

public class AppointmentDetailsViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Patient> Patients 
    {
        get
        {
            return new ObservableCollection<Patient>(PatientService.Current.Patients);
        } 
    }

    public ObservableCollection<Physician> Physicians
    {
        get
        {
            return new ObservableCollection<Physician>(PhysicianService.Current.Physicians);
        }
    }

    public ObservableCollection<Treatment> Treatments
    {
        get
        {
            if(Model.Treatments != null){
                return new ObservableCollection<Treatment>(Model.Treatments);
            }else
            {
                return new ObservableCollection<Treatment>();
            }
        }
    }

    public ObservableCollection<Treatment> AvailableTreatments
    {
        get
        {
            return new ObservableCollection<Treatment>(TreatmentService.Current.Treatments);
        }
    }

    public Treatment SelectedAvailableTreatment {get; set;}

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

    public void AddTreatment()
    {
        if(SelectedAvailableTreatment != null){
          Model.Treatments.Add(SelectedAvailableTreatment);
             NotifyPropertyChanged("Treatments");
        }

    }
    public AppointmentDetailsViewModel (int appointmentId)
    {
        if(appointmentId <=0)
        {
            Model = new Appointment(){Treatments = new List<Treatment>()};
        }
        else
        {
            Model = AppointmentService.Current.GetAppointmentById(appointmentId);
            Console.WriteLine(Model.Id);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }