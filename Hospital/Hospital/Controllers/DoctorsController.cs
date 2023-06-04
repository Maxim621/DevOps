using Microsoft.AspNetCore.Mvc;
using Hospital.Models;

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly HospitalDbContext _context;

        public DoctorsController(HospitalDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = _context.Doctors.ToList();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, Doctor updatedDoctor)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return NotFound();
            }

            doctor.Name = updatedDoctor.Name;
            doctor.Specialty = updatedDoctor.Specialty;

            _context.SaveChanges();

            return Ok(doctor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);

            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return NoContent();
        }
    }
}