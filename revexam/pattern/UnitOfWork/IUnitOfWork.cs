using pattern.Models;
using pattern.repository;
using Repository;
using School.Repository;

namespace LegumesPatternRepository.Repository
{
    interface IUnitOfWork
    {
        IRepository<Section> SectionRepo { get; }
        IStudent StudentRepo { get; }
    }
}
