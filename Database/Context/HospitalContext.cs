using Microsoft.EntityFrameworkCore;
using SimbirsoftDbRep.Authentication.Models;
using SimbirsoftDbRep.Database.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.Database.Context
{
    /// <summary>
    /// Контекст для работы с базой данных.
    /// </summary>
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
        /// Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Roles.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// User roles.
        /// </summary>
        public DbSet<UserRoles> UserRoles { get; set; }

        /// <summary>
        /// Инициализирует экземпляр <see cref="HospitalContext"/>.
        /// </summary>
        /// <param name="options">Опции для конфигурации контекста.</param>
        public HospitalContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

       
    }
}

