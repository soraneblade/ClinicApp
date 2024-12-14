using System;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace MauiApp1.ViewModels;

public class TreatmentViewModel : INotifyPropertyChanged
    {
        public Treatment SelectedTreatment { get; set; }
        public string Query {get; set;}

        public ObservableCollection<Treatment> Treatments 
        { 
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Treatment>(TreatmentService.Current.Treatments);
                }
                return new ObservableCollection<Treatment>(TreatmentService.Current.Treatments);

            }
        }


        public void Delete()
        {
            if (SelectedTreatment == null)
            {
                return;
            }
            TreatmentService.Current.DeleteTreatment(SelectedTreatment);
            NotifyPropertyChanged("Treatments");
        }

        public void Search()
        {
            NotifyPropertyChanged("Treatments");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
