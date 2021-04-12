namespace EnumExercises
{
    class CardValidator
    {
        internal static void Validate()
        {
            // 1. Instantiate cards with the appropriate suit and rank for each validation scenario.
            // 2. Run Program.Main and confirm scenarios pass. (Indicated by console output.) Do NOT edit existing scenarios.
            // 3. Add a couple more tests to confirm everything is working as intended.

            // TODO: instantiate Card with arguments.
            Card card = new Card();
            Validator.Assert("2 of Hearts" == card.GetName(), "Card.GetName() should be '2 of Hearts'.");

            // TODO: instantiate Card with arguments.
            card = new Card();
            Validator.Assert("Queen of Diamonds" == card.GetName(), "Card.GetName() should be 'Queen of Diamonds'.");

            // TODO: instantiate Card with arguments.
            card = new Card();
            Validator.Assert("10 of Clubs" == card.GetName(), "Card.GetName() should be '10 of Clubs'.");

            // TODO: instantiate Card with arguments.
            card = new Card();
            Validator.Assert("Ace of Spades" == card.GetName(), "Card.GetName() should be 'Ace of Spades'.");
        }
        
    }
}
