using LegumesPatternRepository.Repository;
using pattern.Models;
using pattern.repository;
using pattern.UnitOfWork;
using Repository;
using School.Repository;

SchoolContext schoolContext = new SchoolContext();
//UnitOfWorkSQLServer unitOfWorkSQLServer = new UnitOfWorkSQLServer(schoolContext);
UnitOfWorkMemory unitOfWorkSQLServer = new UnitOfWorkMemory();

IStudent studentRepository = unitOfWorkSQLServer.StudentRepo;

IRepository<Section> sectionRepository = unitOfWorkSQLServer.SectionRepo;

Section section1 = new Section { Name = "sectInfo" };
Section section2 = new Section { Name = "sectDiet" };

sectionRepository.Save(section1,s=>s.Name.Equals(section1.Name));
sectionRepository.Save(section2, s => s.Name.Equals(section2.Name));
foreach(Section section in sectionRepository.GetAll())
{
    Console.WriteLine(section.Name + ""+section.SectionId);
}

Student studinfo1= new Student{ Firstname = "stud",Name="info1",SectionId=1,YearResult=100 };
Student studinfo2 = new Student { Firstname = "stud", Name = "info2", SectionId = 1, YearResult = 110 };
Student studdiet1 = new Student { Firstname = "stud",Name="diet1", SectionId = 2, YearResult = 120 };

studentRepository.Save(studinfo1, s => s.Name.Equals(studinfo1.Name));
studentRepository.Save(studinfo2, s => s.Name.Equals(studinfo2.Name));
studentRepository.Save(studdiet1, s => s.Name.Equals(studdiet1.Name));

foreach (var students in studentRepository.GetStudentBySectionOrderByYearResult())
{
    Console.WriteLine(students.Key);
    foreach(Student student in students)
    {
        Console.WriteLine(student.Name + " " + student.YearResult);
    }
}


