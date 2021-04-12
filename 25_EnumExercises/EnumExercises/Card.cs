namespace EnumExercises
{
    class Card
    {
        // 1. Add a Suit and Rank property to the Card class.
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        // 2. Add a constructor that accepts a Suit and Rank and sets the appropriate properties.

        public Card(Suit suit, Rank rank) 
        {
            Suit = suit;
            Rank = rank;
        }

        public string GetName()
        {
            // 3. Complete the GetName method.
            // Given a card's suit and rank, GetName returns a string in the format:
            // "[rank] of [suit]"

            string cardName = Rank.ToString().ToLower();



            // Examples:
            // Ace of Clubs
            // 5 of Diamonds
            // King of Hearts
            // 9 of Spades

            // Note: it's unlikely you'll be able to use the enum name directly since enum naming conventions
            // don't match the required output.
            return cardName;
        }
    }
}
