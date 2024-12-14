using System;

namespace Fall2024_Example_Windows.Models;

public class InsurancePlan
{
    public int Id { get; set; } 
    public string PlanName { get; set; } 
    public decimal DiscountPercentage { get; set; }
    public string CoverageDetails { get; set; } 

    public override string ToString()
    {
        return $"Plan Name: {PlanName}\n" +
        $"Discount Percentage {DiscountPercentage}" +
        $"Coverage Details {CoverageDetails}"; 
    }
}
