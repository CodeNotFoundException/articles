using EFCoreSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                if (!context.People.Any())
                {
                    context.People.AddRange(new List<Person>
                    {
                        new Person { FirstName = "Holty Samba", LastName = "Sow", Gender = Gender.Male },
                        new Person { FirstName = "Fatim", LastName = "Sarré", Gender = Gender.Female },
                        new Person { FirstName = "Fatoumata", LastName = "Sow", Gender = Gender.Female }
                    });

                    context.SaveChanges();
                }
            }

            Console.WriteLine();
            Console.WriteLine("All people");
            using (var context = new MyDbContext())
            {
                foreach (var person in context.People)
                {
                    Console.WriteLine($"\t{person.FirstName} {person.LastName} - {person.Gender}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("All female people");
            using (var context = new MyDbContext())
            {
                foreach (var person in context.People.Where(p => p.Gender == Gender.Female))
                {
                    Console.WriteLine($"\t{person.FirstName} {person.LastName} - {person.Gender}");
                }
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
