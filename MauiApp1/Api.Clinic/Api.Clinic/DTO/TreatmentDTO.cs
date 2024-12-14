using Api.Clinic.Models;
namespace Api.Clinic.DTO
{
    public class TreatmentDTO
    {
        public override string ToString()
        {
            return Display;
        }

        public string Display
        {
            get
            {
                return $"[{Id}] {Name}";
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }

        public TreatmentDTO() { }
        public TreatmentDTO(Treatment t)
        {
            Id = t.Id;
            Name = t.Name;
            BasePrice = t.BasePrice;
        }
    }
}
