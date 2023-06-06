using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Hospital.Models;
using Hospital.Repositories;

namespace Hospital.Tests
{
    [TestFixture]
    public class DoctorControllerTests
    {
        private DbContextOptions<HospitalDbContext> _options;

        [SetUp]
        public void Setup()
        {
            // Налаштування контексту бази даних для тестів
            _options = new DbContextOptionsBuilder<HospitalDbContext>()
                .UseInMemoryDatabase(databaseName: "Hospital")
                .Options;
        }

        [Test]
        public void GetAllDoctors_ReturnsAllDoctors()
        {
            // Arrange
            using (var context = new HospitalDbContext(_options))
            {
                // Створюємо тестових лікарів
                var doctors = new List<Doctor>
                {
                    new Doctor { Id = 1, Name = "John Doe" },
                    new Doctor { Id = 2, Name = "Jane Smith" },
                    new Doctor { Id = 3, Name = "Michael Johnson" }
                };
                context.Doctors.AddRange(doctors);
                context.SaveChanges();
            }

            using (var context = new HospitalDbContext(_options))
            {
                var repository = new DoctorRepository(context);

                // Act
                var result = repository.GetAllDoctors();

                // Assert
                Assert.AreEqual(3, result.Count()); // Переконаємося, що повернуто трьох лікарів
            }
        }

        [Test]
        public void GetDoctorById_ReturnsCorrectDoctor()
        {
            // Arrange
            using (var context = new HospitalDbContext(_options))
            {
                // Створюємо тестових лікарів
                var doctors = new List<Doctor>
                {
                    new Doctor { Id = 1, Name = "John Doe" },
                    new Doctor { Id = 2, Name = "Jane Smith" },
                    new Doctor { Id = 3, Name = "Michael Johnson" }
                };
                context.Doctors.AddRange(doctors);
                context.SaveChanges();
            }

            using (var context = new HospitalDbContext(_options))
            {
                var repository = new DoctorRepository(context);

                // Act
                var result = repository.GetDoctorById(2);

                // Assert
                Assert.IsNotNull(result); // Переконаємося, що лікар не є порожнім
                Assert.AreEqual("Jane Smith", result.Name); // Переконаємося, що правильний лікар повернуто
            }
        }

        [Test]
        public void AddDoctor_CreatesNewDoctor()
        {
            // Arrange
            using (var context = new HospitalDbContext(_options))
            {
                var repository = new DoctorRepository(context);

                // Act
                var newDoctor = new Doctor { Id = 1, Name = "John Doe" };
                repository.AddDoctor(newDoctor);

                // Assert
                Assert.AreEqual(1, context.Doctors.Count()); // Переконаємося, що лікаря додали
                Assert.AreEqual("John Doe", context.Doctors.First().Name); // Переконаємося, що правильне ім'я лікаря було додано
            }
        }
    }
}