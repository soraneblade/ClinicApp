using System;
using Fall2024_Example_Windows.Models;

namespace Fall2024_Example_Windows.Services;

public class InsuranceService
{  
    private PatientService patientService = PatientService.Current;

    private static object _lock = new object();
    public static InsuranceService Current
    {
        get
        {
            lock(_lock)
            {
                if(instance == null)
                {
                    instance = new InsuranceService();
                }
            
            }
            return instance;
        }
    }

    private static InsuranceService? instance; 
        public InsuranceService()
        {
            // Initialize with some dummy data for now
            insurancePlans = new List<InsurancePlan>
            {
                new InsurancePlan { Id = 1, PlanName = "Basic Plan", DiscountPercentage = 10m, CoverageDetails = "Covers basic treatments" },
                new InsurancePlan { Id = 2, PlanName = "Premium Plan", DiscountPercentage = 20m, CoverageDetails = "Covers all treatments" }
            };
        }

    private List<InsurancePlan> insurancePlans;
    public List<InsurancePlan> InsurancePlans {
        get
        {
            return insurancePlans;
        }
        set{
            if(insurancePlans != value){
                insurancePlans = value;
            }
        }
    }
    public int LastKey
    {
        get
        {
            if(InsurancePlans.Any())
            {
                return InsurancePlans.Select(x => x.Id).Max();
            }
            return 0;
        }
    }

        public List<InsurancePlan> GetAllInsurancePlans()
        {
            return insurancePlans;
        }

        public InsurancePlan GetInsurancePlanById(int id)
        {
            return insurancePlans.FirstOrDefault(i => i.Id == id);
        }

        public void AddInsurancePlanToPatient(int patientId, InsurancePlan insurancePlan)
        {
            Patient patientToUpdate = patientService.GetPatientById(patientId);
            if(patientToUpdate != null)
            {
                if(insurancePlan.Id <= 0)
                {
                    insurancePlan.Id = LastKey + 1;
                    InsurancePlans.Add(insurancePlan);
                    Console.WriteLine($"Adding {insurancePlan.Id} to Patient {patientToUpdate.Name}");
                    patientToUpdate.InsurancePlan = insurancePlan;
                }
                else
                {
                    var insuranceToUpdate = InsurancePlans.FirstOrDefault(p => p.Id == insurancePlan.Id);
                    insuranceToUpdate = insurancePlan;
                    Console.WriteLine($"Updated Insurance {insuranceToUpdate.Id}");
                }
            }
        }

        public void AddInsurancePlan(InsurancePlan insurancePlan)
        {
            insurancePlan.Id = insurancePlans.Count > 0 ? insurancePlans.Max(i => i.Id) + 1 : 1;
            insurancePlans.Add(insurancePlan);
        }

        public void UpdateInsurancePlan(InsurancePlan insurancePlan)
        {
            var existingPlan = GetInsurancePlanById(insurancePlan.Id);
            if (existingPlan != null)
            {
                existingPlan.PlanName = insurancePlan.PlanName;
                existingPlan.DiscountPercentage = insurancePlan.DiscountPercentage;
                existingPlan.CoverageDetails = insurancePlan.CoverageDetails;
            }
        }

        public void DeleteInsurancePlan(int id)
        {
            var insurancePlan = GetInsurancePlanById(id);
            if (insurancePlan != null)
            {
                insurancePlans.Remove(insurancePlan);
            }
        }

        public decimal CalculateDiscountedPrice(Treatment treatment, InsurancePlan insurancePlan)
        {
            if (insurancePlan == null) return treatment.BasePrice;
            return treatment.BasePrice - (treatment.BasePrice * (insurancePlan.DiscountPercentage / 100m));
        }
}
