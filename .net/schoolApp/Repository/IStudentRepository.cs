using School.Repository;
using schoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolApp.Repository
{
    public interface IStudentRepository:IRepository<Student>
    {
        IList<Student> sortedStudPerSection();
    }
}
