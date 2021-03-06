
using System;
using System.Linq;
using System.Data.Entity;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            var query = from c in context.Courses
                        where c.Name.Contains("c#")
                        orderby c.Name
                        select c;

            var query1 = context.Courses.Where(c => c.Name.Contains("c#")).OrderBy(c => c.Name);

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            var anonimus = from c in context.Courses
                           where c.Author.Id == 1
                           orderby c.Level descending, c.Name
                           select new { Name = c.Name, Author = c.Author.Name };

            var groupBy = from c in context.Courses
                          group c by c.Level into g
                          select g;

            foreach (var gr in groupBy)
            {
                Console.WriteLine(gr.Key);
                foreach (var i in gr)
                {
                    Console.WriteLine(i.Name);
                }

            }

            foreach (var item in groupBy)
            {
                Console.WriteLine("{0}, ({1})", item.Key, item.Count());
            }

            var queryJoins = from c in context.Courses
                             join a in context.Authors on c.AuthorId equals a.Id
                             select new { courseName = c.Name, AuthorName = a.Name };

            var groupJoin = from a in context.Authors
                            join c in context.Courses on a.Id equals c.AuthorId into g
                            select new {authorName=a.Name, courses=g.Count() };

            foreach (var item in groupJoin)
            {
                Console.WriteLine("{0}, ({1})", item.authorName, item.courses);
            }

            var courses23 = context.Courses.Include(c=>c.Author).ToList();

            foreach (var item in courses23)
            {
                Console.WriteLine("{0}, ({1})", item.Name, item.Author.Name);
            }


        }
    }
}
