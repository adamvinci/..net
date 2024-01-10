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
    interface IUnitOfWorkSchool
    {
           IStudentRepository StudentsRepository { get; }
        IRepository<Section> SectionsRepository { get; }
    }
}