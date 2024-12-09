using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;

namespace MauiApp1.ViewModels;

public class PhysicianDetailsViewModel : INotifyPropertyChanged
{

    public string Name { 
        get
        {
            return Model.Name;
        }

        set
        {
            Model.Name = value;
        }
    }
    public string LicenseNumber { 
        get
        {
            return Model.LicenseNumber;
        }

        set
        {
            Model.LicenseNumber = value;
        }
    }
    public DateTime GraduationDate { 
        get
        {
            return Model.GraduationDate;
        }

        set
        {
            Model.GraduationDate = value;
        }
    }
    public string Specialization { 
        get
        {
            return Model.Specialization;
        }

        set
        {
            Model.Specialization = value;
        }
    }
    public List<Appointment> Appointments { 
        get
        {
            return Model.Appointments;
        }

        set
        {
            Model.Appointments = value;
        }
    }
    
    public Physician Model { get; set; }

    public void Add()
    {
        if (Model.Id <= 0)
        {
            PhysicianService.Current.AddorUpdatePhysician(Model);
        }
    }

    public PhysicianDetailsViewModel (int physicianId)
    {
        if(physicianId <=0)
        {
            Model = new Physician();
        }
        else
        {
            Model = PhysicianService.Current.GetPhysicianById(physicianId);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }
