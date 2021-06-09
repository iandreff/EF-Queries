﻿
using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //var query = from c in context.Courses
            //                           where c.Name.Contains("c#")
            //                           orderby c.Name
            //                           select c;

            var query = context.Courses.Where(c => c.Name.Contains("c#")).OrderBy(c => c.Name);

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
                        
        }
    }
}
