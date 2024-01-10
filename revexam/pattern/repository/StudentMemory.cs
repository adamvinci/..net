using Microsoft.EntityFrameworkCore;
using pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pattern.repository
{
    internal class StudentMemory : IStudent
    {
        protected List<Student> students;
        public StudentMemory()
        {
            students = new List<Student>();
        }

        public void Insert(Student entity)
        {

            students.Add(entity);

        }

        public void Delete(Student entity)
        {
            students.Remove(entity);
        }

        public IList<Student> SearchFor(Expression<Func<Student, bool>> predicate)
        {
            return students.AsQueryable().Where(predicate).ToList();

        }

        public IList<Student> GetAll()
        {
            return students.ToList();
        }

        public Student GetById(int id)
        {
            return students.Where(s=>s.StudentId==id).SingleOrDefault();
        }

        public bool Save(Student entity, Expression<Func<Student, bool>> predicate)
        {
            Student ent = (SearchFor(predicate)).FirstOrDefault();

            if (ent == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }

        public IEnumerable<IGrouping<int?, Student>> GetStudentBySectionOrderByYearResult()
        {
            var student = from s in students
                           orderby  s.YearResult descending
                           group s by s.SectionId;
            return student;
        }
    }
}
