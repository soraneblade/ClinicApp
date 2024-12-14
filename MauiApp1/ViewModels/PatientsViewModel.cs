using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;
namespace MauiApp1.ViewModels;

public class PatientsViewModel : INotifyPropertyChanged
{

        public Patient SelectedPatient { get; set; }

        public string Query { get; set; }


        //Collection of Patients Model that we use to display on the PatientsView XAML page
        public ObservableCollection<Patient> Patients
        {
            //If Query is null or empty we return the whole list of the Patients in PatientService,
            // otherwise we pass the Query to our PatientService which returns a list of Patients whose name contains the text in the query (not case sensitive)
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Patient>(PatientService.Current.Patients);

                }
                return new ObservableCollection<Patient>(PatientService.Current.Search(Query));
            }
        }

        //I
        public void Delete()
        {
            if (SelectedPatient == null)
            {
                return;
            }
            PatientService.Current.DeletePatient(SelectedPatient);
            NotifyPropertyChanged("Patients");
        }

        public void Search()
        {
            NotifyPropertyChanged("Patients");
        }

        public void EditInsurance()
        {
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
