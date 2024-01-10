using School.Repository;
using SchoolApp.Models;
using SchoolApp.Repository;
using SchoolApp.Unitofwork;

SchoolContext context = new SchoolContext();
/*StudentRepositorySQL studentRepository= new StudentRepositorySQL(context);
BaseRepositorySQL<Section> sectionRepository = new BaseRepositorySQL<Section>(context);*/

// UnitOfWorkMemory unitofwork = new UnitOfWorkMemory();

UnitOfWorkSchoolSQLServer unitofwork = new UnitOfWorkSchoolSQLServer(context);
IStudentRepository studentRepository = unitofwork.StudentsRepository;
IRepository<Section> sectionRepository = unitofwork.SectionsRepository;


Section section1 = new Section { Name = "Section1"};
sectionRepository.Save(section1,s=>s.Name.Equals(section1.Name));
Section section2 = new Section { Name = "Section2" };
sectionRepository.Save(section2, s => s.Name.Equals(section2.Name));

var section = sectionRepository.GetAll();

foreach (Section s in section)
{
    Console.WriteLine("{0} {1}",s.Name,s.SectionId);
}

Student student1 = new Student { Firstname="belo",Name = "student1",SectionId=1,YearResult=100 };
studentRepository.Save(student1, (s => s.Name.Equals(student1.Name) && s.Firstname.Equals(student1.Firstname)));
Student student2 = new Student { Firstname = "obito", Name = "student2", SectionId = 2, YearResult = 120 };
studentRepository.Save(student2, s => (s.Name.Equals(student2.Name) && s.Firstname.Equals(student2.Firstname)));
Student student3 = new Student { Firstname = "ermano",Name = "student3", SectionId = 1, YearResult = 110 };
studentRepository.Save(student3, s => (s.Name.Equals(student3.Name) && s.Firstname.Equals(student3.Firstname)));

var student = studentRepository.GetAll();

foreach(Student s in student)
{
    Console.WriteLine(s.Firstname);
}


foreach (IGrouping<int?, Student> group in studentRepository.GetStudentBySectionOrderByYearResult())
{
    Console.WriteLine($"Section ID: {group.Key}");

    foreach (var s in group)
    {
        Console.WriteLine($"  {s.StudentId} {s.Firstname} {s.Name} {s.YearResult}");
    }
}