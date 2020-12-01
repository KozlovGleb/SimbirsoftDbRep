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
        /// Пациенты.
        /// </summary>
        public DbSet<Patient> Patients { get; set; }

        /// <summary>
        /// Доктора.
        /// </summary>
        public DbSet<Doctor> Doctors { get; set; }

        /// <summary>
        /// Карты пациентов.
        /// </summary>
        public DbSet<PatientCard> PatientCards { get; set; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="HospitalContext"/>.
        /// </summary>
        /// <param name="options">Опции для конфигурации контекста.</param>
        public HospitalContext(DbContextOptions options) : base(options)
        {
        }

       
    }
}

