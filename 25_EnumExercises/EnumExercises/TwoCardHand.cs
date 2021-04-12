using System;

namespace EnumExercises
{
    class TwoCardHand : IComparable<TwoCardHand>
    {
        public Card CardOne {get; private set;}
        public Card CardTwo { get; private set; }

        public TwoCardHand(Card one, Card two)
        {
            CardOne = one;
            CardTwo = two;
        }

        public int CompareTo(TwoCardHand other)
        {
            // 1. Complete the CompareTo method.
            // If the current TwoCardHand(`this`) has a lower score than the TwoCardHand parameter, CompareTo returns
            // an int less than 0.
            // If `this` has a higher score than the TwoCardHand parameter, CompareTo returns an int greater than 0.
            // If `this` and the TwoCardHand parameter have the same score, CompareTo returns 0.
            // See Exercise04.md for scoring rules.
            return 0;
        }
    }
}
