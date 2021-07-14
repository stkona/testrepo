using System;
using System.Collections.Generic;

namespace TDDProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var newList = new List<string[]>()
            {
                new string[] { "Tom", "Python"},
                new string[] { "Lily", "Python" },
                new string[] { "Nathan", "Java" },
                new string[] { "Josh", "Java" },
            };

            var val = Unit.RegisteredNames(newList);
            foreach (var item in val)
            {
                Console.WriteLine(item);
            }
        }
    }
}
