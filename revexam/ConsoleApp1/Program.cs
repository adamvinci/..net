using LINQDataContext;

DataContext dataContext = new DataContext();

var join2 = from section in dataContext.Sections
            join prof in dataContext.Professors on section.Section_ID equals prof.Section_ID into profs
            select new { section=section.Section_ID,profs};
foreach (var item in join2)
{
    if(item.profs.Count() > 0)
    {
        Console.WriteLine(item.section);

        foreach (Professor prof in item.profs)
        {
            Console.WriteLine(prof.Professor_Name);
        }
    }
 
}

/*
var join1 = from course in dataContext.Courses
            join prof in dataContext.Professors on course.Professor_ID equals prof.Professor_ID
            join section in dataContext.Sections on prof.Section_ID equals section.Section_ID
            select new { course.Course_Name, section.Section_Name, prof.Professor_Name };
foreach(var item in join1)
{
    Console.WriteLine(item);
}


var resultatPerSectionParDate = (from student in dataContext.Students
                                 where student.BirthDate.Year <=1985 && student.BirthDate.Year >=1970
                          group student by student.BirthDate.Month).Select(x => new { month = x.Key, average = x.Average(s => s.Year_Result) }).ToList();
foreach (var result in resultatPerSectionParDate)
{
    Console.WriteLine(result);
}

var resultatPerSection = (from student in dataContext.Students
                          group student by student.Section_ID).Select(x => new { sectionId = x.Key,max=x.Max(s=>s.Year_Result) }).ToList();
foreach (var result in resultatPerSection)
{
    Console.WriteLine(result);
}

                         

var nbLigne = dataContext.Students.Count();
Console.WriteLine(nbLigne);

var minscore = dataContext.Students.Min(s => s.Year_Result);
Console.WriteLine(minscore);

var sumscore = dataContext.Students.Sum(s => s.Year_Result);
Console.WriteLine(sumscore);

var maxscore = dataContext.Students.Max(s => s.Year_Result);
Console.WriteLine(maxscore);

var averageScore = dataContext.Students.Average(s => s.Year_Result);
Console.WriteLine(averageScore);    


var stud5 = from student in dataContext.Students
            where student.Section_ID == 1110
            orderby student.Last_Name 
            select new { student.First_Name, student.Section_ID,student.Year_Result };
foreach (var stud in stud5)
{
    Console.WriteLine(stud);
}

var stud4 = from student in dataContext.Students
            where student.Year_Result <= 3
            orderby student.Year_Result descending
            select new {student.First_Name,student.Year_Result};
foreach(var stud in stud4)
{
    Console.WriteLine(stud);
}

var stud3 = from student in dataContext.Students
            where student.BirthDate.Year < 1955
            select new { fullname = student.First_Name + " " + student.Last_Name, student.Year_Result,status = student.Year_Result >=12 ? "OK":student.Year_Result == 10 ?"neutre" : "KO"};
foreach (var stud in stud3)
{
    Console.WriteLine(stud);
}

var stud2 = from student in dataContext.Students
            select new { fullname = student.First_Name + " " + student.Last_Name, student.Student_ID, student.BirthDate };
foreach (var stud in stud2)
{
    Console.WriteLine(stud);
}
*/