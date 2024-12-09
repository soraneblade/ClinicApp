using System;
using Fall2024_Example_Windows.Models;

namespace Fall2024_Example_Windows.Services;

public class PhysicianService
{
    private static object _lock = new object();
    public static PhysicianService Current
    {
        get
        {
            lock(_lock)
            {
                if(instance == null)
                {
                    instance = new PhysicianService();
                }
            
            }
            return instance;
        }
    }
    private static PhysicianService? instance;

    public PhysicianService(){
        instance = null;
        Physicians = new List<Physician> 
        {
            new Physician{Id = 1, Name = "Chris Doe"},
            new Physician{Id = 2, Name = "Mills Doe"}
        };
    }

    public int LastKey
    {
        get
        {
            if(Physicians.Any())
            {
                return Physicians.Select(x => x.Id).Max();
            }
            return 0;
        }
    }


    private List<Physician> physicians; 
    public List<Physician> Physicians { 
        get{
            return physicians;
        } 
        set{
            if(physicians != value){
                physicians = value;
            }
        }} 

    public void AddorUpdatePhysician(Physician physician)
    {
        if(physician.Id <= 0){
            physician.Id = LastKey + 1;
            Physicians.Add(physician);
        }
        else
        {
            var physicianToUpdate = Physicians.FirstOrDefault(p => p.Id == physician.Id);

            physicianToUpdate = physician;
        } 
    }

    public Physician? GetPhysicianById(int physicianId)
    {
        return Physicians?.FirstOrDefault(p => p.Id == physicianId);
    }

    public void DeletePhysician(int id)
    {
        var physicianToRemove = Physicians.FirstOrDefault(p => p.Id == id);
        if(physicianToRemove != null)
        {
            Physicians.Remove(physicianToRemove);
        }
    }

    public void DeletePhysician(Physician physician)
    {
        DeletePhysician(physician.Id);
    }

    public List<Physician> Search(string query)
    {
        return Physicians.Where(p => p.Name.ToUpper().Contains(query.ToUpper())).ToList();
    }

}
