using System;

namespace CoursesDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var schoolContext = new SchoolContext())
            {
                Kurs kurs1 = new Kurs { Namn = "C#" };
                schoolContext.Kurser.Add(kurs1);

                Kurs kurs2 = new Kurs { Namn = "C#" };
                schoolContext.Kurser.Add(kurs2);

                Kurs kurs3 = new Kurs { Namn = "C#" };
                schoolContext.Kurser.Add(kurs3);

                Kurs kurs4 = new Kurs { Namn = "C#" };
                schoolContext.Kurser.Add(kurs4);

                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Adam",
                    Kurs = kurs1
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Bertil",
                    Kurs = kurs2
                });
                schoolContext.SaveChanges();
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Caesar",
                    Kurs = kurs3
                });
                schoolContext.SaveChanges();
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "David",
                    Kurs = kurs4
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Helge",
                    Kurs = kurs1
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Ivar",
                    Kurs = kurs2
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Johan",
                    Kurs = kurs3
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Kalle",
                    Kurs = kurs4
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Ludwig",
                    Kurs = kurs1
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Martin",
                    Kurs = kurs2
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Niklas",
                    Kurs = kurs3
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Olof",
                    Kurs = kurs4
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Petter",
                    Kurs = kurs1
                });
                schoolContext.Elever.Add(new Elev
                {
                    Namn = "Quintus",
                    Kurs = kurs2
                });
                schoolContext.SaveChanges();
            }
        }
    }
}
