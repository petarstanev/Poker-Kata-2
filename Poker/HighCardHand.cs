// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HighCardHand.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The high card hand.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Poker
{
    using System.Collections.Generic;

    /// <summary>The high card hand.</summary>
    public class HighCardHand : Hand
    {
        /// <summary>Initializes a new instance of the <see cref="HighCardHand"/> class.</summary>
        /// <param name="cards">The cards.</param>
        public HighCardHand(IEnumerable<Card> cards)
            : base(cards, 0)
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
                result = this.CompareHighestCards(this.Cards, other.Cards);
            }

            return result;
        }
    }
}