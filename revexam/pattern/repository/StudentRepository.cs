using pattern.Models;
using Repository;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pattern.repository
{
    public class StudentRepository : BaseRepositorySQL<Student>, IStudent
    {
        public StudentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<IGrouping<int?, Student>> GetStudentBySectionOrderByYearResult()
        {
            var students = from student in _dbContext.Set<Student>().AsEnumerable()
                           orderby student.Section.Name, student.YearResult descending
                           group student by student.SectionId;
            return students;
        }
    }
}
