using Api.Clinic.Database;
using Api.Clinic.Models;
using Api.Clinic.DTO;
namespace Api.Clinic.Enterprise
{
    public class TreatmentEC
    {
        public TreatmentEC() { }

        public IEnumerable<TreatmentDTO> Treatments
        {
            get
            {
                return FakeDatabase.Treatments.Take(100).Select(t => new TreatmentDTO(t));
            }
        }

        public TreatmentDTO? GetById(int id)
        {
            var treatment = FakeDatabase.Treatments.FirstOrDefault(t => t.Id == id);
            if (treatment != null)
            {
                return new TreatmentDTO(treatment);
            }

            return null;
        }

        public TreatmentDTO? Delete(int id)
        {
            var treatmentToDelete = FakeDatabase.Treatments.FirstOrDefault(t => t.Id == id);
            if (treatmentToDelete != null)
            {
                FakeDatabase.Treatments.Remove(treatmentToDelete);
                return new TreatmentDTO(treatmentToDelete);
            }
            return null;
        }

       /* public TreatmentDTO? AddOrUpdate(TreatmentDTO? treatment)
        {
            if (treatment == null)
            {
                return null;
            }
            return FakeDatabase.AddOrUpdatePatient(new Treatment(treatment));
        }  Couldn't get this to work in time */ 

        public IEnumerable<TreatmentDTO>? Search(string query)
        {
            return FakeDatabase.Treatments
                .Where(t => t.Name.ToUpper()
                .Contains(query?.ToUpper() ?? string.Empty))
                .Select(t => new TreatmentDTO(t));
        }
    }
}
