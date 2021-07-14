using System;
using System.Collections.Generic;
using System.Text;

namespace TDDProject
{
    public static class Unit
    {
        public static List<string> RegisteredNames(List<string[]> list)
        {
            if (!Validate(list) || !ValidateForLanguage(list))
            {
                throw new Exception("Incorrect input length");
            }

            var returnList = new List<string>();
            var str = new Dictionary<string, List<string>>();

            foreach (var item in list)
            {
                if (!str.ContainsKey(item[1]))
                {
                    str.Add(item[1], new List<string> { item[0] });
                }
                else
                {
                    str[item[1]].Add(item[0]);
                }
            }

            foreach (var item in str)
            {
                if (item.Value.Count > 1)
                {
                    returnList.Add(string.Concat(item.Key + "_" + item.Value[0] + "_" + item.Value[1]));
                }
                else
                {
                    returnList.Add(string.Concat(item.Key + "_" + item.Value[0]));
                }
            }

            return returnList;
        }

        private static bool Validate(List<string[]> list)
        {
            foreach (var item in list)
            {
                if (item.Length != 2)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateForLanguage(List<string[]> list)
        {
            var langList = new List<string>() { "C#", "Java", "Python", "JavaScript" };
            foreach (var item in list)
            {
                if (!langList.Contains(item[1]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
