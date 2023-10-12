using School.Repository;
using schoolApp.Models;
using schoolApp.Repository;

namespace School.UnitOfWork
{
    internal interface IUnitOfWorkSchool
    {
        IRepository<Section> SectionsRepository { get; }

        IStudentRepository StudentsRepository { get; }

    }
}