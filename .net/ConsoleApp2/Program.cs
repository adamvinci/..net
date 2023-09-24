using LINQDataContext;
using static System.Collections.Specialized.BitVector32;

DataContext dc = new DataContext();



Console.WriteLine("-------------------------------2.2-----------------------------------");
var students = dc.Students.Select(s => new { Fullname = s.First_Name +" "+ s.Last_Name, Id = s.Student_ID, DateNaissance = s.BirthDate });

foreach(var s in students)
{
    Console.WriteLine("{0} {1} {2}",s.Fullname, s.Id,s.DateNaissance);
}

Console.WriteLine("-------------------------------3.1-----------------------------------");
var bornBefore1955 = dc.Students.Where(s => s.BirthDate.Year < 1955)
    .Select(s => new { s.Last_Name, s.First_Name, statuts = (s.Year_Result > 12) ? "OK" : "KO" });


foreach (var s in bornBefore1955)
{
    Console.WriteLine("{0} {1} {2}", s.Last_Name, s.First_Name, s.statuts);
}

Console.WriteLine("-------------------------------3.4-----------------------------------");

var classedStudent = dc.Students.Where(s => s.Year_Result <= 3)
                            .OrderByDescending(s => s.Year_Result)
                            .Select(s => new { s.Last_Name, s.Year_Result });
foreach (var s in classedStudent)
{
    Console.WriteLine("{0} {1} ", s.Last_Name, s.Year_Result);
}

Console.WriteLine("-------------------------------3.5-----------------------------------");

var classedStudent110 = dc.Students.Where(s => s.Section_ID == 1110).OrderBy(s => s.First_Name)
    .Select(s => new { Fullname = s.First_Name + " " + s.Last_Name, s.Year_Result });
foreach (var s in classedStudent110)
{
    Console.WriteLine(" {0} {1} ", s.Fullname, s.Year_Result);
}

Console.WriteLine("-------------------------------4.1-----------------------------------");

double resultatMoyen=dc.Students.Average(s => s.Year_Result);
Console.WriteLine(resultatMoyen);

Console.WriteLine("-------------------------------4.2-----------------------------------");

int nbLignes = dc.Students.Count;
Console.WriteLine(nbLignes);

Console.WriteLine("-------------------------------5.1-----------------------------------");

var resultatParGroupe = dc.Students.GroupBy(s=>s.Section_ID);

foreach (var s in resultatParGroupe)
{
    Console.WriteLine("Pour la section {0} le max est {1}", s.Key, s.Max(s => s.Year_Result));
}

Console.WriteLine("-------------------------------5.3-----------------------------------");

var resultatSameMonth = dc.Students.Where(s=>s.BirthDate.Year>=1970 && s.BirthDate.Year<=1985).GroupBy(s => s.BirthDate.Month);
foreach (var s in resultatSameMonth)
{
    Console.WriteLine("Pour le mois {0} le score moyen est de {1}",s.Key,s.Average(s => s.Year_Result));
}

Console.WriteLine("-------------------------------5.5-----------------------------------");

var profSection  = from Cours in dc.Courses
                   join prof in dc.Professors on Cours.Professor_ID equals prof.Professor_ID
                   join sect in dc.Sections on prof.Section_ID equals sect.Section_ID
                   select new { Cours.Course_Name, professor = prof.Professor_Name +" "+prof.Professor_Surname,sect.Section_Name};

foreach (var s in profSection)
{
    Console.WriteLine("{0} {1} {2}", s.Course_Name, s.professor, s.Section_Name);
}

Console.WriteLine("-------------------------------5.7-----------------------------------");

var sectionProf = from Section in dc.Sections
                  join prof in dc.Professors on Section.Section_ID equals prof.Section_ID into profs
                  select new { Section.Section_Name, professeur = profs };


foreach (var s in sectionProf)
{
    
    Console.WriteLine("Section {0} :",s.Section_Name);
    if (s.professeur.Count() > 0)
    {
        foreach (Professor prof in s.professeur)
        {

            Console.WriteLine("{0} {1}", prof.Professor_Name, prof.Professor_Surname);
        }
    } else{
        Console.WriteLine("Pas de prof");
    }

    
}

Console.WriteLine("-------------------------------2.1-----------------------------------");
var studentsFilter = dc.Students.Select(s => new { s.Last_Name, s.BirthDate, s.Login, s.Year_Result });
foreach (var student in studentsFilter)
{
    Console.WriteLine("{0} {1} {2} {3}", student.Last_Name, student.BirthDate, student.Login, student.Year_Result);
}

Console.WriteLine("-------------------------------2.3-----------------------------------");
var studentssepereate = dc.Students.Select(s => new {print = s.First_Name +" | "+ s.Last_Name + " | " + s.BirthDate + " | " + s.Login
    + " | " + s.Year_Result + " | " +s.Student_ID + " | " +s.Section_ID + " | " +s.Course_ID });
foreach (var student in studentssepereate)
{
    Console.WriteLine("{0} ", student.print);
}

Console.WriteLine("-------------------------------3.2-----------------------------------");
var studentGroupBy2 = dc.Students.Where(s => s.BirthDate.Year > 1955 && s.BirthDate.Year < 1965)
    .Select(s => new
    {
        etudiant = s.First_Name + " " + s.Year_Result + " ",
        categorie = (s.Year_Result > 10) ?
    "superieure" : (s.Year_Result == 10) ? "neutre" : "inferieuire"
    });
foreach (var student in studentGroupBy2)
{
    Console.WriteLine("{0} {1} ", student.etudiant, student.categorie);
}

Console.WriteLine("-------------------------------3.4-----------------------------------");

var studentGroupBy3 = dc.Students.Where(s => s.Last_Name.EndsWith("r")).Select(s => new { s.Last_Name, s.Student_ID });
foreach (var student in studentGroupBy3)
{
    Console.WriteLine("{0} {1}",student.Last_Name,student.Student_ID);
}

Console.WriteLine("-------------------------------3.5-----------------------------------");

var studentGroupBy5 = dc.Students.Where(s => s.Section_ID == 1110).OrderBy(s=>s.Year_Result)
    .Select(s => new { stud = s.First_Name + " "+ s.Last_Name, s.Year_Result});
foreach (var student in studentGroupBy5)
{
    Console.WriteLine("{0} {1}", student.stud, student.Year_Result);
}


Console.WriteLine("-------------------------------4.2-----------------------------------");

double maxResultAllStudent= dc.Students.Max(s => s.Year_Result);
Console.WriteLine(maxResultAllStudent);

Console.WriteLine("-------------------------------4.3-----------------------------------");

double sumResultAllStudent = dc.Students.Sum(s => s.Year_Result);
Console.WriteLine(sumResultAllStudent);

Console.WriteLine("-------------------------------4.4-----------------------------------");

double minResultAllStudent = dc.Students.Min(s => s.Year_Result);
Console.WriteLine(minResultAllStudent);

Console.WriteLine("-------------------------------5.2-----------------------------------");

var resultPerSection10 = dc.Students.Where(s => s.Section_ID.ToString().StartsWith("10")).GroupBy(s=>s.Section_ID);

foreach (var student in resultPerSection10)
{
    Console.WriteLine("{0} {1}", student.Key, student.Average(s => s.Year_Result));
}
Console.WriteLine("-------------------------------5.4-----------------------------------");

var sectionsWithMoreThan3Students = from section in dc.Sections
                                    join student in dc.Students on section.Section_ID equals student.Section_ID
                                    group student by section into sectionGroup // ou into sectiongroup apres le join mais faut trouver moyen pour le where
                                    where sectionGroup.Count() > 3
                                    select new
                                    {
                                        Section = sectionGroup.Key,
                                        AverageResults = sectionGroup.Average(student => student.Year_Result)
                                    };

foreach (var sct in sectionsWithMoreThan3Students)
{
    Console.WriteLine(" {0} {1}", sct.Section.Section_Name, sct.AverageResults);
}

Console.WriteLine("-------------------------------5.6-----------------------------------");

var sectionByDelegates = from section in dc.Sections
                         join stud in dc.Students on section.Delegate_ID equals stud.Student_ID  
                         orderby section.Section_ID descending
                         select new { section.Section_ID, section.Section_Name, delegue = stud.Last_Name };
                     
                         
                    
foreach (var section in sectionByDelegates)
{
    Console.WriteLine("{0} {1} {2}", section.Section_ID, section.Section_Name, section.delegue);
}

Console.WriteLine("-------------------------------5.11-----------------------------------");

var ectsPerTeacher = (from prof in dc.Professors
                     join courses in dc.Courses on prof.Professor_ID equals courses.Professor_ID into coursesPerProf
                     select new { prof.Professor_Name, sum = coursesPerProf.Sum(c => c.Course_Ects) }).OrderByDescending(item=>item.sum) ;

foreach (var item in ectsPerTeacher)
{
    Console.WriteLine("{0} {1}", item.Professor_Name, item.sum);
}

Console.WriteLine("-------------------------------5.10-----------------------------------");

var teacherSectionCoursesEtcs = (from prof in dc.Professors
                                join section in dc.Sections on prof.Section_ID equals section.Section_ID
                                join courses in dc.Courses on prof.Professor_ID equals courses.Professor_ID  
                                select new { prof.Professor_Name, section.Section_Name,nameCourse= courses.Course_Name ,etc = courses.Course_Ects})
                                .OrderByDescending(item=>item.etc); // perd des rows

var query = from prof in dc.Professors
            join section in dc.Sections on prof.Section_ID equals section.Section_ID
            join courses in dc.Courses on prof.Professor_ID equals courses.Professor_ID into coursesGroup
            from course in coursesGroup.DefaultIfEmpty() // Left join
            select new
            {
                 prof.Professor_Name,
                 section.Section_Name,
                nameCourse = course != null ? course.Course_Name : null, // Handle null values
                etc = course != null ? course.Course_Ects : 0 // Handle null values
            }
            into result
            orderby result.etc descending
            select result;
foreach (var item in query)
{
    Console.WriteLine("{0} {1} {2} {3}",item.Professor_Name,item.Section_Name,item.nameCourse,item.etc);
}
