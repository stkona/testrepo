using System;
using System.Collections.Generic;
using System.Linq;

namespace TDDProject
{
    public static class Builder
    {
        public static List<Developer> CreateDevelopers(List<string[]> list)
        {
            var devs = new List<Developer>();

            foreach (var item in list)
            {
                if (!devs.Any(x => x.Name == item[0] && x.Language == item[1]))
                {
                    devs.Add(new Developer(item[0], item[1], item[2]));
                }
            }

            return devs;
        }

        public static List<Pair> ArrangePairs(List<Developer> developers)
        {
            var pairs = new List<Pair>();

            foreach (var item in developers)
            {
                if (!pairs.Any(x => x.Language == item.Language))
                {
                    pairs.Add(new Pair(item));
                }
                else
                {
                    pairs.Find(x => x.Language == item.Language).AddDeveloper(item);
                }
            }

            return pairs;
        }

        public static IEnumerable<string> BuildNickname(List<Pair> pairs)
        {
            if (pairs.Count == 0)
            {
                throw new ArgumentException("List of pairs cannot be empty");
            }

            foreach (var item in pairs)
            {
                yield return string.Concat(item.Language + "_" + item.FirstDeveloper.Name + item.FirstDeveloper.KnowledgeLevel + "_" + item.SecondDeveloper.Name + item.SecondDeveloper.KnowledgeLevel);
            }
        }
    }
}
