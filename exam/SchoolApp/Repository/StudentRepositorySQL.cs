using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    public class StudentRepositorySQL : BaseRepositorySQL<Student>, IStudentRepository
    {
        public StudentRepositorySQL(SchoolContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<IGrouping<int?, Student>> GetStudentBySectionOrderByYearResult()
        {
            var query = from student in _dbContext.Set<Student>().AsEnumerable()
                        orderby student.YearResult descending
                        group student by student.SectionId into student
                        select student;

            return query;
        }
    }
}
