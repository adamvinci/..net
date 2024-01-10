using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    public class StudentRepositoryMemory : IStudentRepository
    {
        protected List<Student> students;
        public StudentRepositoryMemory()
        {
            this.students = new List<Student>();
        }

        public IEnumerable<IGrouping<int?, Student>> GetStudentBySectionOrderByYearResult()
        {
            var query = from student in students
                        orderby student.YearResult descending
                        group student by student.SectionId into student
                        select student;

            return query;
        }

        public void Insert(Student entity)
        {
            students.Add(entity);
        }

        public void Delete(Student entity)
        {
            students.Remove(entity);
        }

        public void DeleteAll()
        {
            students.Clear();
        }

        public IList<Student> SearchFor(Expression<Func<Student, bool>> predicate)
        {
            return this.students.AsQueryable().Where(predicate).ToList();
        }

        public bool Save(Student entity, Expression<Func<Student, bool>> predicate)
        {
            Student s = (SearchFor(predicate)).FirstOrDefault();

            if (s == null)
            {
                Insert(entity);
                return true;
            }

            return false;

        }

        public IList<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int id)
        {
            return students.Find(s => s.StudentId == id);
        }
    }
}
