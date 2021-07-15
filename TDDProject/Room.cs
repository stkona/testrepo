namespace TDDProject
{
    public class Room
    {
        public string Name { get; set; }
        public Pair ProgrammingPair { get; set; }

        public Room(Pair pair)
        {
            ProgrammingPair = pair;
            Name = pair.Language;
        }
    }
}
