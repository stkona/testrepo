using System;

namespace TDDProject
{
    public class Developer : IDeveloper
    {
        public string Name { get; }
        public string Language { get; }
        public KnowledgeLevel KnowledgeLevel { get; set; }

        public Developer(string name, string language, string level)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new ArgumentException($"'{nameof(language)}' cannot be null or empty.", nameof(language));
            }

            if (string.IsNullOrEmpty(level))
            {
                throw new ArgumentException($"'{nameof(level)}' cannot be null or empty.", nameof(level));
            }

            Name = name;
            Language = language;
            KnowledgeLevel = (KnowledgeLevel)Enum.Parse(typeof(KnowledgeLevel), level);
        }
    }
}
