using LINQDataContext;
using static System.Collections.Specialized.BitVector32;

DataContext dc = new DataContext();

Console.WriteLine("-----------------------2.1------------------------------------------------");
var studInfo = from Student in dc.Students
               select new {nom=Student.First_Name,date=Student.BirthDate,login=Student.Login,result = Student.Year_Result};
foreach(var s in studInfo)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------2.2------------------------------------------------");
var studInfo2 = from Student in dc.Students
               select new { nom = Student.First_Name + " "+ Student.Last_Name, date = Student.BirthDate, id = Student.Student_ID };
foreach (var s in studInfo2)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------2.3------------------------------------------------");
var studInfo3 = from Student in dc.Students
                select new {info= Student.First_Name + "|" +Student.Last_Name + "|" + Student.BirthDate + "|" + Student.Student_ID
                + "|" + Student.Section_ID + "|" + Student.Course_ID + "|" + Student.Year_Result + "|" + Student.Login };
foreach (var s in studInfo3)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------3.1------------------------------------------------");
var studInfo4 = from Student in dc.Students
                where Student.BirthDate.Year < 1955
                select new { Student.Last_Name, Student.Year_Result, statuts = Student.Year_Result >= 12 ? "OK" : "KO" };

foreach (var s in studInfo4)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------3.2------------------------------------------------");
var studInfo5 = from Student in dc.Students
                where Student.BirthDate.Year > 1955 && Student.BirthDate.Year < 1965
                select new { Student.Last_Name, Student.Year_Result, categorie = Student.Year_Result > 10 ? "superieur" :
                Student.Year_Result == 10 ? "neutre" : "inferieur" };

foreach (var s in studInfo5)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------3.3------------------------------------------------");
var studInfo6 = from Student in dc.Students
                where Student.Last_Name.EndsWith("r")
                select new
                {
                    Student.Last_Name,
                    Student.Section_ID,
                };

foreach (var s in studInfo6)
{
    Console.WriteLine(s);
}
Console.WriteLine("-----------------------3.4------------------------------------------------");
var studInfo7 = from Student in dc.Students
                where Student.Year_Result <=3
                orderby Student.Year_Result descending
                select new
                {
                    nom = Student.Last_Name,
                    Student.Year_Result,
                };

foreach (var s in studInfo7)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------3.5------------------------------------------------");
var studInfo8 = from Student in dc.Students
                where Student.Section_ID == 1110
                orderby Student.Last_Name
                select new
                {
                   nom =  Student.Last_Name + " "+ Student.Last_Name,
                    Student.Year_Result,
                };

foreach (var s in studInfo8)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------3.6------------------------------------------------");
var studInfo9 = from Student in dc.Students
                where (Student.Section_ID == 1010 || Student.Section_ID == 1020) && Student.Year_Result > 18 && Student.Year_Result <12
                orderby Student.Year_Result
                select new
                {
                     Student.Last_Name ,
                     Student.Section_ID,
       
                    Student.Year_Result,
                };

foreach (var s in studInfo9)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------3.7------------------------------------------------");
var studInfo10 = (from Student in dc.Students
                  where Student.Section_ID.ToString().StartsWith("10")
                  orderby Student.Year_Result descending
                  select new
                  {
                      Student.Last_Name,
                      Student.Section_ID,
                      section_100 = (Student.Year_Result *5),
                  }).Where(x=>x.section_100<=60);

foreach (var s in studInfo10)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------4.1------------------------------------------------");
var studInfo11 = dc.Students.Average(s => s.Year_Result);

Console.WriteLine(studInfo11);


Console.WriteLine("-----------------------4.2------------------------------------------------");
var studInfo12 = dc.Students.Max(s => s.Year_Result);

Console.WriteLine(studInfo12);

Console.WriteLine("-----------------------4.3------------------------------------------------");
var studInfo13 = dc.Students.Sum(s => s.Year_Result);

Console.WriteLine(studInfo13);

Console.WriteLine("-----------------------4.4------------------------------------------------");
var studInfo14 = dc.Students.Min(s => s.Year_Result);

Console.WriteLine(studInfo14);

Console.WriteLine("-----------------------4.5------------------------------------------------");
var studInfo15 = dc.Students.Count();

Console.WriteLine(studInfo15);

Console.WriteLine("-----------------------5.1------------------------------------------------");
var studInfo16 = (from Student in dc.Students
                 group Student by Student.Section_ID);

foreach(var s in studInfo16)
{
    Console.WriteLine("Max result {0} for section {1} ",s.Max(s=>s.Year_Result),s.Key);
}

Console.WriteLine("-----------------------5.2------------------------------------------------");
var studInfo17 = (from Student in dc.Students
                  where Student.Section_ID.ToString().StartsWith("10")
                  group Student by Student.Section_ID);

foreach (var s in studInfo17)
{
    Console.WriteLine("AVG result {0} for section {1} ", s.Average(s => s.Year_Result), s.Key);
}


Console.WriteLine("-----------------------5.3------------------------------------------------");
var studInfo18 = (from Student in dc.Students
                  where Student.BirthDate.Year > 1970 && Student.BirthDate.Year <1985
                  group Student by Student.BirthDate.Month);

foreach (IGrouping<int, Student> s in studInfo18)
{
    Console.WriteLine("AVG result {0} for month {1} ", s.Average(s => s.Year_Result), s.Key);
}

Console.WriteLine("-----------------------5.4------------------------------------------------");
var studInfo19 = from Student in dc.Students
                  group Student by Student.Section_ID into sectionStud
                  where sectionStud.Count() >3 select sectionStud;

foreach (IGrouping<int, Student> s in studInfo19)
{
    Console.WriteLine("AVG result {0} for section {1} ", s.Average(s => s.Year_Result), s.Key);
}

Console.WriteLine("-----------------------5.5------------------------------------------------");
var coursinfo1 = from c in dc.Courses
                 join prof in dc.Professors on c.Professor_ID equals prof.Professor_ID
                 join section in dc.Sections on prof.Section_ID equals section.Section_ID
                 select new { c.Course_Name, prof.Professor_Name, section.Section_Name };

foreach (var s in coursinfo1)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------5.6------------------------------------------------");
var sectionInfo1 = from s in dc.Sections
                   join stud in dc.Students on s.Delegate_ID equals stud.Student_ID
                   orderby s.Section_ID descending
                   select new { s.Section_ID, s.Section_Name, stud.Last_Name };

foreach (var s in sectionInfo1)
{
    Console.WriteLine(s);
}

Console.WriteLine("-----------------------5.7------------------------------------------------");
var sectionInfo2 = from s in dc.Sections
                   join prof in dc.Professors on s.Section_ID equals prof.Section_ID into profsPerSection
                   where profsPerSection.Count() > 0
                   select new {s.Section_Name,profsPerSection};

foreach (var s in sectionInfo2)
{
    Console.WriteLine("Section {0} :", s.Section_Name);
        foreach (Professor prof in s.profsPerSection)
        {

            Console.WriteLine("{0} {1}", prof.Professor_Name, prof.Professor_Surname);
        }
 
}



Console.WriteLine("-----------------------5.9------------------------------------------------");
var studInfo20 = from stud in dc.Students
                  where stud.Year_Result >= 12
                  select new
                  {
                      stud.Last_Name,
                      stud.Year_Result,
                      grade = (from grade in dc.Grades
                               where stud.Year_Result >= grade.Lower_Bound && stud.Year_Result <= grade.Upper_Bound
                               select grade.GradeName).First()
                  } into result orderby result.grade select result;

foreach (var s in studInfo20)
{
    Console.WriteLine(s);
}


Console.WriteLine("-----------------------5.10------------------------------------------------");
var profInfo1 = from prof in dc.Professors
                join section in dc.Sections on prof.Section_ID equals section.Section_ID 
                join course in dc.Courses on prof.Professor_ID equals course.Professor_ID into courseJoin
                from course in courseJoin.DefaultIfEmpty()
                select new
                {
                    prof.Professor_Name,
                    section.Section_Name,
                    nameCourse = course != null ? course.Course_Name : null, // Handle null values
                    etc = course != null ? course.Course_Ects : 0 // Handle null values
                }   ;


foreach (var s in profInfo1)
{
    Console.WriteLine(s);
}


Console.WriteLine("-----------------------5.11------------------------------------------------");
var profInfo2 = from prof in dc.Professors
                select new
                {
                    prof.Professor_ID,
                    credits = dc.Courses.Where(c=>c.Professor_ID == prof.Professor_ID).Sum(c=>c.Course_Ects)
                } into result orderby result.credits descending select result;


foreach (var s in profInfo2)
{
    Console.WriteLine(s);
}