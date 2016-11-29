// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FullHouseHand.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The Full House Hand.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Poker
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>The full house hand.</summary>
    public class FullHouseHand : Hand
    {
        public FullHouseHand(IEnumerable<Card> cards)
            : base(cards, 14)
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