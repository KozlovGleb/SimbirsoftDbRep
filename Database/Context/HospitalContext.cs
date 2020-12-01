using Microsoft.EntityFrameworkCore;
using SimbirsoftDbRep.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Database.Context
{
    public class HospitalContext:DbContext
    {
        /// <summary>
        /// Магазины.
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Поставщики.
        /// </summary>
        public DbSet<Doctor> Doctors { get; set; }

        /// <summary>
        /// Одежда.
        /// </summary>
        public DbSet<PatientCard> PatientCards { get; set; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="AspNetLectionsContext"/>.
        /// </summary>
        /// <param name="options">Опции для конфигурации контекста.</param>
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Правила создания сущностей.
        /// </summary>
        /// <param name="builder">Билдер моделей.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AvailabilityConfig());
        }
    }
}
}
