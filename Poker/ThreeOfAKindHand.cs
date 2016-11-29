// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThreeOfAKindHand.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The three of a kind hand.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Poker
{
    using System.Collections.Generic;

    /// <summary>The three of a kind hand.</summary>
    public class ThreeOfAKindHand : Hand
    {
        public ThreeOfAKindHand(IEnumerable<Card> cards)
            : base(cards, 12)
        {
        }
        public override int CompareTo(Hand other)
        {
            int result = base.CompareTo(other);

            if (result == 0)
            {
                result = this.ComparePairs(new List<Card>(this.Cards), new List<Card>(other.Cards));
            }

            return result;
        }

        protected int ComparePairs(List<Card> player1Cards, List<Card> player2Cards)
        {
            int result = 0;

            result = this.CompareHighestCards(player1Cards, player2Cards);

            return result;
        }
    }
}