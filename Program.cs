using System;
using System.Collections.Generic;
using System.Linq;

namespace CoursesDatabase
{
    class Program
    {
        static void FillDatabase()
        {
            Random r = new Random();

            using (var schoolContext = new SchoolContext())
            {
                Larare larare1 = new Larare { Namn = "Pontus" };
                Larare larare2 = new Larare { Namn = "Samir" };
                Larare larare3 = new Larare { Namn = "Aina" };
                Larare larare4 = new Larare { Namn = "Ronny" };

                schoolContext.Add(larare1);
                schoolContext.Add(larare2);
                schoolContext.Add(larare3);
                schoolContext.Add(larare4);

                schoolContext.SaveChanges();

                List<Kurs> kursList = new List<Kurs>
                {
                    new Kurs { Namn = "C#", Sal = 10, Larare = larare1 },
                    new Kurs { Namn = "HTML", Sal = 20, Larare = larare2 },
                    new Kurs { Namn = "C#.NET", Sal = 23 , Larare = larare3 },
                    new Kurs { Namn = "PYTHON", Sal = 15 , Larare = larare4},
                    new Kurs { Namn = "BASIC", Sal = 10, Larare = larare3 }
                };

                foreach (var kurs in kursList)
                {
                    schoolContext.Add(kurs);
                }
                schoolContext.SaveChanges();

                List<Elev> eleverList = new List<Elev>
                {
                    new Elev { Namn = "Adam",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "Bertil",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "Caesar",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "David", Alder = r.Next(20, 40) },
                    new Elev { Namn = "Helge", Alder = r.Next(20, 40) },
                    new Elev { Namn = "Ivar",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "Johan",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "Kalle",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "Ludwig",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "Martin", Alder = r.Next(20, 40) },
                    new Elev { Namn = "Niklas",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "Olof",  Alder = r.Next(20, 40) },
                    new Elev { Namn = "Petter", Alder = r.Next(20, 40) },
                    new Elev { Namn = "Quintus", Alder = r.Next(20, 40) }
                };

                foreach (var elev in eleverList)
                {
                    schoolContext.Add(elev);
                }
                schoolContext.SaveChanges();

                var kursElevList = new List<KursElev>();

                for (int i = 0; i < kursList.Count(); i++)
                {
                    var intar = new List<int>();
                    for (int j = 0; j < eleverList.Count; j++)
                        intar.Add(j);
                    for (int j = 0; j < 6; j++)
                    {
                        var elevPosition = r.Next(0, intar.Count());
                        kursElevList.Add(new KursElev
                        {
                            Kurs = kursList.ElementAt(i),
                            Elev = eleverList.ElementAt(intar.ElementAt(elevPosition))
                        });
                        intar.RemoveAt(elevPosition);
                    }
                    intar.Clear();
                }

                foreach (var kursElev in kursElevList)
                {
                    schoolContext.Add(kursElev);                 
                }
                                
                schoolContext.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
            //FillDatabase();

            using (var schoolContext = new SchoolContext()) { 
                // Ställ frågor till databasen:
                // Yngste studenten.
                /* select top 1 * from elever order by alder ASC
                 */
                var youngestStudent = (from Elever in schoolContext.Elever
                                       orderby Elever.Alder ascending
                                       select Elever)
                                       .First();
                Console.WriteLine("Yngste student:");
                Console.WriteLine("{0}: {1}", youngestStudent.Namn, youngestStudent.Alder);

            // Äldste eleven
                var oldestStudent = (from e in schoolContext.Elever
                                       orderby e.Alder descending
                                       select e)
                                       .First();
                Console.WriteLine("Äldste student: ");
                Console.WriteLine("{0}: {1}", oldestStudent.Namn, oldestStudent.Alder);

                // Yngste eleven i respektive kurs

                // Läraren som har flest kurser.
                var mostActiveTeacher = ( from l in schoolContext.Larare
                                         join q in 
                                            (from k in schoolContext.Kurser
                                            group k by k.LarareID into antalKurser
                                            select new
                                            {
                                                LarareID = antalKurser.Key,
                                                kurser = antalKurser.Count()
                                            })
                                            on l.LarareID equals q.LarareID
                                            select new
                                            {
                                                namn = l.Namn,
                                                kurser = q.kurser
                                            });

                foreach (var teachers in mostActiveTeacher)
                {
                    Console.WriteLine("{0} : {1}", teachers.namn, teachers.kurser);
                }
                /* Yngsta eleven i respektive kurs.
                 * Lånad uppgift.
                 */
                using (var sc2 = new SchoolContext())
                {
                    foreach (var course in (from c in sc2.Kurser select c))
                    {
                        Console.Write("Yngs i kurs " + course.Namn + " är: ");

                        var youngestStudentInCourse = (from k in schoolContext.Kurser
                                                       join ke in schoolContext.KursElev
                                                       on k.KursID equals ke.KursID
                                                       join e in schoolContext.Elever
                                                       on ke.ElevID equals e.ElevID
                                                       where e.Alder == (from k2 in schoolContext.Kurser
                                                                         join ke in schoolContext.KursElev
                                                                         on k2.KursID equals ke.KursID
                                                                         join e in schoolContext.Elever
                                                                         on ke.ElevID equals e.ElevID
                                                                         where k2.KursID == course.KursID
                                                                         select e).Min(e => e.Alder)
                                                        && k.KursID == course.KursID
                                                       select e);

                        foreach (var student in youngestStudentInCourse)
                            Console.WriteLine(student.Namn);
                        Console.WriteLine();
                    }
                }

               /*                    var youngestStudentInEackCourse = (from e in schoolContext.Elever
                                                                   join ke in schoolContext.KursElev
                                                                   on e.ElevID equals ke.ElevID
                                                                   join k in schoolContext.Kurser
                                                                   on ke.KursID equals k.KursID
                                                                   select new
                                                                   {
                                                                       namn = e.Namn,
                                                                       kurs = k.Namn,
                                                                       alder = e.Alder
                                                                   }
                                    );

                foreach (var elever in youngestStudentInEackCourse)
                {
                    Console.WriteLine("{0} : {1} : {2}", elever.kurs, elever.namn, elever.alder);
                }


              */                      
                /*
                var youngestStudentInEackCourse = (from e in schoolContext.Elever
                                                   join ke in schoolContext.KursElev
                                                   on e.ElevID equals ke.ElevID
                                                   join k in schoolContext.Kurser
                                                   on ke.KursID equals k.KursID
                                                   group e by ke.KursID into sc
                                                   select new
                                                   {
                                                       kurs = sc.Key,
                                                       yngst = sc.Min(e => e.Alder)
                                                   });
                foreach (var elever in youngestStudentInEackCourse)
                {
                    Console.WriteLine(elever.kurs.ToString(), elever.yngst);
                }
    

                 
                // Hur många elever går i respektive kurs?
                /*                var numberOfStudentsPerCourse = (
                                    from k in schoolContext.Kurser
                                    join e in schoolContext.Elever
                                    on k.KursID equals e.KursID into g
                                    select new
                                    {
                                        attendants = g.KursID,
                                        total = g.Count()

                                    }
                                    ) ;
                                    */
                // Vilka elever går i respektive kurs?

                /*

             var eleverOchKurser = (from k in schoolContext.Kurser
                                       join e in schoolContext.Elever 
                                       join ke in schoolContext.KursElev
                                       on k.KursID equals ke.KursID 
                                       on ke.elevID equals e.elevID
                                       select new
                                       {
                                           elevID = e.ElevID,
                                           elevNamn = e.Namn,
                                           kursNamn= k.Namn,
                                           sal = k.Sal
                                       });

                foreach (var elever in eleverOchKurser)
                {
                    Console.WriteLine("{0} {1} {2} {3}", elever.elevID, elever.elevNamn, elever.kursNamn, elever.sal   );
                }
               */ /*
                   SELECT e.ElevID, e.Namn, e.Alder, k.Sal, k.Namn FROM Elever e
                JOIN Kurser k
                ON e.KursID = k.KursID
                ORDER BY k.KursID;
                */
            }
        }
    }
}


