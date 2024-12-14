using System;
using Fall2024_Example_Windows.Models;

namespace Fall2024_Example_Windows.Services;

public class TreatmentService
{
    private static object _lock = new object();
    public static TreatmentService Current
    {
        get
        {
            lock(_lock)
            {
                if(instance == null)
                {
                    instance = new TreatmentService();
                }
            
            }
            return instance;
        }
    }
    private static TreatmentService? instance;
    private List<Treatment> treatments;
    public List<Treatment> Treatments
    {
        get
        {
            return treatments;
        }
        set
        {
            if(treatments != value)
            {
                treatments = value;
            }
        }
    }

    public TreatmentService()
    {
        treatments = new List<Treatment>
        {
            new Treatment { Id = 1, Name = "Dental Cleaning", BasePrice = 100m },
            new Treatment { Id = 2, Name = "X-Ray", BasePrice = 50m }
        };
    }

    public int LastKey
    {
        get
        {
            if(Treatments.Any())
            {
                return Treatments.Select(x => x.Id).Max();
            }
            return 0;
        }
    }

    public List<Treatment> GetAllTreatments()
    {
        return treatments;
    }

    public Treatment? GetTreatmentById(int treatmentId)
    {
        return Treatments?.FirstOrDefault(t => t.Id == treatmentId);
    }


    public void AddorUpdateTreatment(Treatment treatment)
    {
        if(treatment.Id <= 0){
            treatment.Id = LastKey + 1;
            Treatments.Add(treatment);
        }
        else
        {
            var treatmentToUpdate = Treatments.FirstOrDefault(p => p.Id == treatment.Id);

            treatmentToUpdate = treatment;
        } 
    }

        public void DeleteTreatment(int treatmentId)
        {
            var treatment = GetTreatmentById(treatmentId);
            if (treatment != null)
            {
                Treatments.Remove(treatment);
            }
        }

        public void DeleteTreatment(Treatment treatment)
        {
            DeleteTreatment(treatment.Id);
        }
}
