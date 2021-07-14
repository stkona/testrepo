namespace TDDProject
{
    public interface IDeveloper
    {
        string Name { get; }
        string Language { get; }
        KnowledgeLevel KnowledgeLevel { get; set; }
    }
}