using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Repositories
{
    public class PatientRepository
    {
        private readonly HospitalDbContext _context;

        public PatientRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }

        public void DeletePatient(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}