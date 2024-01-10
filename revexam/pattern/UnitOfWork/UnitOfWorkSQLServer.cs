using pattern.Models;
using pattern.repository;
using Repository;
using School.Repository;

namespace LegumesPatternRepository.Repository
{
    class UnitOfWorkSQLServer : IUnitOfWork
    {
        private readonly SchoolContext _context;

        private BaseRepositorySQL<Section> _sectionRepo;
        private StudentRepository studentRepo;

        public UnitOfWorkSQLServer(SchoolContext context)
        {
            this._context = context;
            this._sectionRepo = new BaseRepositorySQL<Section>(context);
            this.studentRepo = new StudentRepository(context);

        }

        public IRepository<Section> SectionRepo  {
            get {  return _sectionRepo; }
            }

        public IStudent StudentRepo
        {
            get { return studentRepo; }
        }
    }
}
