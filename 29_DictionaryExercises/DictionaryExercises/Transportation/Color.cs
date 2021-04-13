namespace DictionaryExercises.Transportation
{
    public class Color
    {
        public string Name { get; private set; }

        public Color(string name)
        {
            Name = name;
        }

        // 1. Override Color .Equals and .GetHashCdoe to use the `Name` property.
        // (Hint: Visual Studio can generate these methods for you.)
    }
}
