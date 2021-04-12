namespace EnumExercises
{
    class TwoCardHandValidator
    {
        internal static void Validate()
        {
            // 1. Instantiate hands with the appropriate suit and rank for each scenario.
            // 2. Run Program.Main and confirm they pass. Do NOT edit existing scenarios.
            // 3. Add a couple more scenarios to confirm everything is working as intended.

            // TODO: instantiate Cards and TwoCardHands with appropriate arguments
            TwoCardHand queenQueen = new TwoCardHand(new Card(), new Card());
            TwoCardHand tenTen = new TwoCardHand(new Card(), new Card());
            Validator.Assert(queenQueen.CompareTo(tenTen) > 0, "Queen/Queen should be greater than 10/10.");

            // TODO: instantiate Cards and TwoCardHands with appropriate arguments
            TwoCardHand nineNine = new TwoCardHand(new Card(), new Card());
            TwoCardHand jackTen = new TwoCardHand(new Card(), new Card());
            Validator.Assert(nineNine.CompareTo(jackTen) > 0, "9/9 should be greater than Jack/10.");

            // TODO: instantiate Cards and TwoCardHands with appropriate arguments
            TwoCardHand queenFour = new TwoCardHand(new Card(), new Card());
            Validator.Assert(queenFour.CompareTo(jackTen) > 0, "Queen/4 should be greater than Jack/10.");

            // TODO: instantiate Cards and TwoCardHands with appropriate arguments
            TwoCardHand queenFive = new TwoCardHand(new Card(), new Card());
            TwoCardHand queenThree = new TwoCardHand(new Card(), new Card());
            Validator.Assert(queenFive.CompareTo(queenThree) > 0, "Queen/5 should be greater than Queen/3.");

            // TODO: instantiate Cards and TwoCardHands with appropriate arguments
            TwoCardHand firstFiveFive = new TwoCardHand(new Card(), new Card());
            TwoCardHand secondFiveFive = new TwoCardHand(new Card(), new Card());
            Validator.Assert(firstFiveFive.CompareTo(secondFiveFive) == 0, "5/5 should be equal to 5/5.");

            // TODO: instantiate Cards and TwoCardHands with appropriate arguments
            TwoCardHand firstJackFour = new TwoCardHand(new Card(), new Card());
            TwoCardHand secondJackFour = new TwoCardHand(new Card(), new Card());
            Validator.Assert(firstJackFour.CompareTo(secondJackFour) == 0, "Jack/4 should be equal to Jack/4.");
        }
    }
}
