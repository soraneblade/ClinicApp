using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Fall2024_Example_Windows.Models;
using Fall2024_Example_Windows.Services;
namespace MauiApp1.ViewModels;

public class AppointmentsViewModel : INotifyPropertyChanged
{

        public Appointment SelectedAppointment { get; set; }

        public string Query { get; set; }


        //Collection of Appointments Model that we use to display on the AppointmentsView XAML page
        public ObservableCollection<Appointment> Appointments
        {
            //If Query is null or empty we return the whole list of the Appointments in AppointmentService,
            // otherwise we pass the Query to our AppointmentService which returns a list of Appointments whose name contains the text in the query (not case sensitive)
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Appointment>(AppointmentService.Current.Appointments);

                }
                return new ObservableCollection<Appointment>(AppointmentService.Current.Search(Query));
            }
        }

        //I
        public void Delete()
        {
            if (SelectedAppointment == null)
            {
                return;
            }
            AppointmentService.Current.DeleteAppointment(SelectedAppointment);
            NotifyPropertyChanged("Appointments");
        }

        public void Search()
        {
            NotifyPropertyChanged("Appointments");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
}
