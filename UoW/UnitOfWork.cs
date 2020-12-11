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
        public PatientRepository Patients => patientRepository ?? (patientRepository = new PatientRepository(_context,_mapper));
        public DoctorRepository Doctors => doctorRepository ?? (doctorRepository = new DoctorRepository(_context, _mapper));
        public PatientCardRepository PatientCards => patientCardRepository ?? (patientCardRepository = new PatientCardRepository(_context, _mapper));


       
        public bool Save()
        {
            bool returnValue = true;
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    returnValue = false;
                    dbContextTransaction.Rollback();
                }
            }

            return returnValue;
            //_context.SaveChanges();
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
