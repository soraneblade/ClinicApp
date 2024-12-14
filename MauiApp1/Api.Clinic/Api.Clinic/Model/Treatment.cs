using System;

namespace Api.Clinic.Models;

public class Treatment
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public decimal BasePrice { get; set; }

    public override string ToString()
    {
        return $"{Name} - Base Price: {BasePrice}";
    }
}
