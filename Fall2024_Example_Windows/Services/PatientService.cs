using System;
using Fall2024_Example_Windows.Models;

namespace Fall2024_Example_Windows.Services;

public class PatientService
{
    private static object _lock = new object();
    public static PatientService Current
    {
        get
        {
            lock(_lock)
            {
                if(instance == null)
                {
                    instance = new PatientService();
                }
            
            }
            return instance;
        }
    }
    private static PatientService? instance;

    private PatientService(){
        instance = null;
        Patients = new List<Patient> 
        {
            new Patient{Id = 1, Name = "John Doe"},
            new Patient{Id = 2, Name = "Jane Doe"}
        };
    }

    public int LastKey
    {
        get
        {
            if(Patients.Any())
            {
                return Patients.Select(x => x.Id).Max();
            }
            return 0;
        }
    }


    private List<Patient> patients; 
    public List<Patient> Patients { 
        get{
            return patients;
        } 
        set{
            if(patients != value){
                patients = value;
            }
        }} 

    public void AddorUpdatePatient(Patient patient)
    {
        if(patient.Id <= 0){
            patient.Id = LastKey + 1;
            Patients.Add(patient);
        }
        else
        {
            var patientToUpdate = Patients.FirstOrDefault(p => p.Id == patient.Id);

            patientToUpdate = patient;
        } 
    }

    public Patient? GetPatientById(int patientId)
    {
        return Patients?.FirstOrDefault(p => p.Id == patientId);
    }

    public void DeletePatient(int id)
    {
        var patientToRemove = Patients.FirstOrDefault(p => p.Id == id);
        if(patientToRemove != null)
        {
            Patients.Remove(patientToRemove);
        }
    }

    public void DeletePatient(Patient patient)
    {
        DeletePatient(patient.Id);
    }

    public List<Patient> Search(string query)
    {
        return Patients.Where(p => p.Name.ToUpper().Contains(query.ToUpper())).ToList();
    }

}
