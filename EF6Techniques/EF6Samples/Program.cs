using EF6Samples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                context.People.AddRange(new List<Person>
                {
                    new Person { FirstName = "Holty Samba", LastName = "Sow", Gender = Gender.Male },
                    new Person { FirstName = "Fatim", LastName = "Sarré", Gender = Gender.Female },
                    new Person { FirstName = "Fatoumata", LastName = "Sow", Gender = Gender.Female }
                });

                context.SaveChanges();
            }

            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
