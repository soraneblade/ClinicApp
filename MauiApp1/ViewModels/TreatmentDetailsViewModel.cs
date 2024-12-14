using System;
using Fall2024_Example_Windows.Services;
using Fall2024_Example_Windows.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels;

public class TreatmentDetailsViewModel 
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

    public decimal BasePrice{
        get
        {
            return Model.BasePrice;
        }
        set
        {
            Model.BasePrice = value;
        }
    }
    
    public Treatment Model { get; set; }

    public void Add()
    {
        if (Model.Id <= 0)
        {
            TreatmentService.Current.AddorUpdateTreatment(Model);
        }
    }

    public TreatmentDetailsViewModel (int treatmentId)
    {
        if(treatmentId <=0)
        {
            Console.WriteLine($"TreatmentId {treatmentId}");
            Model = new Treatment();
        }
        else
        {
            Console.WriteLine($"TreatmentId {treatmentId}");
            Model = TreatmentService.Current.GetTreatmentById(treatmentId);
        }
    }
    
}
