using School.Repository;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    class SectionRepositoryMemory : IRepository<Section>
    {
        protected List<Section> sections;
        public SectionRepositoryMemory()
        {
            this.sections = new List<Section>();    
        }
        public void Delete(Section entity)
        {
            sections.Remove(entity);
        }

        public void DeleteAll()
        {
            sections.Clear();
        }

        public IList<Section> GetAll()
        {
            return sections;
        }

        public Section GetById(int id)
        {
            return sections[id];
        }

        public void Insert(Section entity)
        {
            sections.Add(entity);
        }

        public bool Save(Section entity, Expression<Func<Section, bool>> predicate)
        {
            Section s = SearchFor(predicate).SingleOrDefault();

            if (s == null)
            {
                Insert(entity);

            }
            return true;

        }

        public IList<Section> SearchFor(Expression<Func<Section, bool>> predicate)
        {
            return sections.AsQueryable().Where(predicate).ToList(); 
        }
    }
}
