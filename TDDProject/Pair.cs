using System.Collections.Generic;
using System.Linq;

namespace TDDProject
{
    public class Pair
    {
        private List<IDeveloper> devs = new List<IDeveloper>();

        public Pair(Developer dev)
        {
            devs.Add(dev);
        }

        public string Language { get => devs[0].Language; }

        public IDeveloper FirstDeveloper { get => devs.First(); }
        public IDeveloper SecondDeveloper { get => devs.Last(); }

        public void AddDeveloper(Developer dev)
        {
            this.devs.Add(dev);
        }
    }
}
