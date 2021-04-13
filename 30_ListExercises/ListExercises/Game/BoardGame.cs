using System;

namespace ListExercises.Game
{
    public class BoardGame
    {
        public string Name { get; private set; }
        public int MinPlayers { get; private set; }
        public int MaxPlayers { get; private set; }
        public string Category { get; private set; }

        public BoardGame(string name, int minPlayers, int maxPlayers, string category)
        {
            Name = name;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name}, {MinPlayers}-{MaxPlayers} players, {Category}";
        }

        public override bool Equals(object obj)
        {
            return obj is BoardGame game &&
                   Name == game.Name &&
                   MinPlayers == game.MinPlayers &&
                   MaxPlayers == game.MaxPlayers &&
                   Category == game.Category;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, MinPlayers, MaxPlayers, Category);
        }
    }
}