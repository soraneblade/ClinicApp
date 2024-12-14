using System;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace MauiApp1.ViewModels;

public class InsuranceViewModel : INotifyPropertyChanged
    {
        public string PlanName { 
            get
            {
                return Model.PlanName;
            }
            
            set
            {
                Model.PlanName = value;
            } 
        }
        public decimal DiscountPercentage { 
            get
            {

             return Model.DiscountPercentage;

            }
            
            set
            {
                Model.DiscountPercentage = value;
            } 
        }
        public string CoverageDetails {
            get
            {

                return Model.CoverageDetails;

            } 
            set
            {
                Model.CoverageDetails = value;
            } 
        }
        public Patient SelectedPatient {get; set;}
        public InsurancePlan Model {get; set;}
        private PatientService patientService = PatientService.Current;

        private InsuranceService insuranceService = InsuranceService.Current;

        public InsuranceViewModel(int patientId)
        {
            SelectedPatient = patientService.GetPatientById(patientId);
            if (SelectedPatient != null)
            {
                if(SelectedPatient.InsurancePlan != null)
                    Model = SelectedPatient.InsurancePlan;
                else
                {
                    Console.WriteLine("New Insurance Made");
                    Model = new InsurancePlan();
                }
            }
        }

        public void Save()
        {
            if(patientService.GetPatientById(SelectedPatient.Id) !=  null)
            {
                Console.WriteLine("Saving Insurance");
                insuranceService.AddInsurancePlanToPatient(SelectedPatient.Id, Model);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
