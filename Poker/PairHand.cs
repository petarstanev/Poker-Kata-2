// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PairHand.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The pair hand.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Poker
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>The pair hand.</summary>
    public class PairHand : Hand
    {
        /// <summary>Initializes a new instance of the <see cref="PairHand"/> class.</summary>
        /// <param name="cards">The cards.</param>
        public PairHand(IEnumerable<Card> cards)
            : base(cards, 10)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="PairHand"/> class.</summary>
        /// <param name="cards">The cards.</param>
        /// <param name="rank">The rank.</param>
        public PairHand(IEnumerable<Card> cards, int rank)
            : base(cards, rank)
        {
        }

        /// <summary>The compare to.</summary>
        /// <param name="other">The other.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public override int CompareTo(Hand other)
        {
            int result = base.CompareTo(other);

            if (result == 0)
            {
                result = this.ComparePairs(new List<Card>(this.Cards), new List<Card>(other.Cards));
            }

            return result;
        }

        /// <summary>The compare pairs.</summary>
        /// <param name="player1Cards">The player 1 cards.</param>
        /// <param name="player2Cards">The player 2 cards.</param>
        /// <returns>The <see cref="int"/>.</returns>
        protected int ComparePairs(List<Card> player1Cards, List<Card> player2Cards)
        {
            int result = 0;

            result = this.CompareHighestCards(player1Cards, player2Cards);

            return result;
        }
    }
}