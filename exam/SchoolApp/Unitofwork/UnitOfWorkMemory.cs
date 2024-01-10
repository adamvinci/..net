using School.Repository;
using SchoolApp.Models;
using SchoolApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Unitofwork
{
     class UnitOfWorkMemory: IUnitOfWorkSchool
    {

        private StudentRepositoryMemory _studentRepository;

        private SectionRepositoryMemory _sectionsRepository;


        public UnitOfWorkMemory()
        {
            this._studentRepository = new StudentRepositoryMemory();
            this._sectionsRepository = new SectionRepositoryMemory();

        }

        public IStudentRepository StudentsRepository
        {
            get { return this._studentRepository; }
        }

        public IRepository<Section> SectionsRepository
        {
            get { return this._sectionsRepository; }
        }
    }
}
