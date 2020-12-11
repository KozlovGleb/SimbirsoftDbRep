using AutoMapper;
using SimbirsoftDbRep.Database.Context;
using SimbirsoftDbRep.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimbirsoftDbRep.UoW
{
    public class UnitOfWork: IDisposable
    {
        private HospitalContext _context;
        private PatientRepository patientRepository;
        private DoctorRepository doctorRepository;
        private PatientCardRepository patientCardRepository;
        private IMapper _mapper;

        public UnitOfWork(HospitalContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public PatientRepository Patients
        {
            get
            {
                if (patientRepository == null)
                    patientRepository = new PatientRepository(_context, _mapper);
                return patientRepository;
            }
        }

        public DoctorRepository Doctors
        {
            get
            {
                if (doctorRepository == null)
                    doctorRepository = new DoctorRepository(_context, _mapper);
                return doctorRepository;
            }
        }
        public PatientCardRepository PatietnCard
        {
            get
            {
                if (patientCardRepository == null)
                    patientCardRepository = new PatientCardRepository(_context, _mapper);
                return patientCardRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
