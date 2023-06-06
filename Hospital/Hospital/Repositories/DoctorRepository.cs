using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Repositories
{
    public class DoctorRepository
    {
        private readonly HospitalDbContext _context;

        public DoctorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }

        public void AddDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}