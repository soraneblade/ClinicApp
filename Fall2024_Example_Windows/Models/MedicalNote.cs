using System;

namespace Fall2024_Example_Windows.Models

{
    class MedicalNote
    {
        public string Diagnosis { get; private set; }
        public string Prescription { get; private set; }

        public MedicalNote(string diagnosis, string prescription)
        {
            Diagnosis = diagnosis;
            Prescription = prescription;
        }
    }

}