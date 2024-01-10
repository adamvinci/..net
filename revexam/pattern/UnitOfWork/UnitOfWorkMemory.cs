using pattern.Models;
using pattern.repository;
using Repository;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern.UnitOfWork
{
    internal class UnitOfWorkMemory
    {
        private SectionMemory _sectionRepo;
        private StudentMemory studentRepo;

        public UnitOfWorkMemory()
        {
            this._sectionRepo = new SectionMemory();
            this.studentRepo = new StudentMemory();

        }

        public IRepository<Section> SectionRepo
        {
            get { return _sectionRepo; }
        }

        public IStudent StudentRepo
        {
            get { return studentRepo; }
        }
    }
}
