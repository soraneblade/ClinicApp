using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;

namespace MauiApp1.ViewModels;

public class PatientDetailsViewModel : INotifyPropertyChanged
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

    public DateTime Birthday { 
        get
        {
            return Model.Birthday;
        }

        set
        {
            Model.Birthday = value;
        }
    }
    public string Address { 
        get
        {
            return Model.Address;
        }

        set
        {
            Model.Address = value;
        }
    }
    public string Race { 
        get
        {
            return Model.Race;
        }

        set
        {
            Model.Race = value;
        }
    }
    public string Gender { 
        get
        {
            return Model.Gender;
        }

        set
        {
            Model.Gender = value;
        }
    }
    public string SSN { 
        get
        {
            return Model.SSN;
        }

        set
        {
            Model.SSN = value;
        }
    }
    public Patient Model { get; set; }

    public void Add()
    {
        if (Model.Id <= 0)
        {
            PatientService.Current.AddorUpdatePatient(Model);
        }
    }

    public PatientDetailsViewModel (int patientId)
    {
        if(patientId <=0)
        {
            Model = new Patient();
        }
        else
        {
            Model = PatientService.Current.GetPatientById(patientId);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    }
