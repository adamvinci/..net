using pattern.Models;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern.repository
{
    public interface IStudent:IRepository<Student>
    {
        IEnumerable<IGrouping<int?,Student>> GetStudentBySectionOrderByYearResult();


    }
}
