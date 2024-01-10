using pattern.Models;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace pattern.repository
{
    internal class SectionMemory : IRepository<Section>
    {
        protected List<Section> sections;
        public SectionMemory()
        {
            sections = new List<Section>();
        }

        public void Insert(Section entity)
        {

            sections.Add(entity);

        }

        public void Delete(Section entity)
        {
            sections.Remove(entity);
        }

        public IList<Section> SearchFor(Expression<Func<Section, bool>> predicate)
        {
            return sections.AsQueryable().Where(predicate).ToList();

        }

        public IList<Section> GetAll()
        {
            return sections.ToList();
        }

        public Section GetById(int id)
        {
            return sections.Where(s => s.SectionId == id).SingleOrDefault();
        }

        public bool Save(Section entity, Expression<Func<Section, bool>> predicate)
        {
            Section ent = (SearchFor(predicate)).FirstOrDefault();

            if (ent == null)
            {
                Insert(entity);
                return true;
            }
            return false;
        }
    }
}
