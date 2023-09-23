using LINQDataContext;

DataContext dc = new DataContext();


//2.2
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