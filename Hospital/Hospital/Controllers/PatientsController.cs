using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public PatientsController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patients = _context.Patients.ToList();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost]
        public IActionResult CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return Ok(patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, Patient updatedPatient)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.Name = updatedPatient.Name;
            patient.Age = updatedPatient.Age;
            patient.Gender = updatedPatient.Gender;

            _context.SaveChanges();

            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();

            return NoContent();
        }
    }
}