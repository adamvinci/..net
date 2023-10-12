

using School.Repository;
using School.UnitOfWork;
using schoolApp.Models;
using schoolApp.Repository;

SchoolContext context = new SchoolContext();

/*BaseRepositorySQL<Section> repoSect = new BaseRepositorySQL<Section>(context);

StudentRepositorySQLServer repoStud = new StudentRepositorySQLServer(context);*/
IUnitOfWorkSchool unitOfWorkSchool = new UnitOfWorkSchoolSQLServer(context);
IRepository<Section> repoSect = unitOfWorkSchool.SectionsRepository;
IStudentRepository repoStud = unitOfWorkSchool.StudentsRepository;


IList<Section> sections = repoSect.GetAll();

foreach(Section section in sections)
{
    Console.WriteLine(section.Name);
}

//2.a
Section sectionInfo = new Section();
sectionInfo.Name = "sectInfo";
repoSect.Save(sectionInfo, s=>s.Name.Equals(sectionInfo.Name));

Section sectionDiet = new Section();
sectionDiet.Name = "sectDiet";
repoSect.Save(sectionDiet, s => s.Name.Equals(sectionDiet.Name));
Console.WriteLine("After save");

IList<Section> sectionsAfterSave = repoSect.GetAll();

foreach (Section section in sectionsAfterSave)
{
    Console.WriteLine(section.Name);
}

// 2.b
Student studinfo = new Student
{
    Firstname = "studinfo",
    Name = "studinfo",
    Section = sectionDiet,
    YearResult = 100
};

Student studdiet = new Student
{
    Firstname = "studdiet",
    Name = "studdiet",
    Section = sectionInfo,
    YearResult = 120
};


Student studinfo2 = new Student
{
    Firstname = "studinfo2",
    Name = "studinfo2",
    Section = sectionDiet,
    YearResult = 110
};

repoStud.Save(studinfo, s => s.Name.Equals(studinfo.Name) && s.Firstname.Equals(studinfo.Firstname));
repoStud.Save(studinfo2, s => s.Name.Equals(studinfo2.Name) && s.Firstname.Equals(studinfo2.Firstname));
repoStud.Save(studdiet, s => s.Name.Equals(studdiet.Name) && s.Firstname.Equals(studdiet.Firstname));


IList<Student> studentList = repoStud.GetAll();

foreach (Student student in studentList)
{
    Console.WriteLine(student.Name);
}

//pour le c rajouter une classe iStudentRepository qui extendsIrepo et qui rajoute la methode qu'on veux et une classe iRepositorySQL pour l'implementer

IList<Student> students = repoStud.sortedStudPerSection();
foreach (Student student in students)
{
    Console.WriteLine($"Student {student.Name} {student.Section.Name}");
}