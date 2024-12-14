using Api.Clinic.Models;
using Api.Clinic.DTO;

namespace Api.Clinic.Database
{
    static public class FakeDatabase
    {
        public static int LastKey
        {
            get
            {

                if (Treatments.Any())
                {
                    return Treatments.Select(x => x.Id).Max();
                }
                return 0;
            }
        }
        private static List<Treatment> treatments = new List<Treatment>
    
        {
            new Treatment { Id = 1, Name = "Dental Cleaning", BasePrice = 100m },
            new Treatment { Id = 2, Name = "X-Ray", BasePrice = 50m }

        };


        public static List<Treatment> Treatments
        {
            get
            {
                return treatments;
            }

        }

        public static TreatmentDTO? AddOrUpdatePatient(Treatment? treatment)
        {
            if (treatment == null)
            {
                return null;
            }
            bool isAdd = false;
            if (treatment.Id <= 0)
            {
                treatment.Id = LastKey + 1;
                isAdd = true;
            }
            if (isAdd)
            {
                Treatments.Add(treatment);
            }
            return new TreatmentDTO(treatment);
        }
    }
}
