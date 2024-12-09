using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;
namespace MauiApp1.ViewModels;

public class PhysicianViewModel : INotifyPropertyChanged
{

        public Physician SelectedPhysician { get; set; }

        public string Query { get; set; }


        //Collection of Physicians Model that we use to display on the PhysiciansView XAML page
        public ObservableCollection<Physician> Physicians
        {
            //If Query is null or empty we return the whole list of the Physicians in PhysicianService,
            // otherwise we pass the Query to our PhysicianService which returns a list of Physicians whose name contains the text in the query (not case sensitive)
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Physician>(PhysicianService.Current.Physicians);

                }
                return new ObservableCollection<Physician>(PhysicianService.Current.Search(Query));
            }
        }

        //I
        public void Delete()
        {
            if (SelectedPhysician == null)
            {
                return;
            }
            PhysicianService.Current.DeletePhysician(SelectedPhysician);
            NotifyPropertyChanged("Physicians");
        }

        public void Search()
        {
            NotifyPropertyChanged("Physicians");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
}
