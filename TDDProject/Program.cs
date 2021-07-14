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
                new string[] { "Tom", "Python", "Junior"},
                new string[] { "Tom", "Python", "Junior"},
                new string[] { "Lily", "Python", "Senior" },
                new string[] { "Nathan", "Java", "Senior" },
                new string[] { "Josh", "Java", "Junior" },
                new string[] { "Penka", "JavaScript", "Junior" },
                new string[] { "Gosho", "JavaScript", "Senior" },
            };

            var result = Builder.CreateDevelopers(newList);

            var pairs = Builder.ArrangePairs(result);
            foreach (var item in pairs)
            {
                Console.WriteLine(item.Language);
                Console.WriteLine(item.FirstDeveloper.Name + " and " + item.SecondDeveloper.Name);
            }

            Console.WriteLine(string.Join("|", Builder.BuildNickname(pairs)));
        }
    }
}
