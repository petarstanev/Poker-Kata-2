// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hand.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The hand.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>The hand.</summary>
    public abstract class Hand : IComparable<Hand>
    {
        /// <summary>Initializes a new instance of the <see cref="Hand"/> class.</summary>
        /// <param name="cards">The cards.</param>
        /// <param name="rank">The rank.</param>
        protected Hand(IEnumerable<Card> cards, int rank)
        {
            this.Cards = cards.ToList();
            this.Rank = rank;
        }

        /// <summary>Gets or sets the cards.</summary>
        public List<Card> Cards { get; protected set; }

        /// <summary>Gets or sets the rank.</summary>
        public int Rank { get; protected set; }

        /// <summary>The compare to.</summary>
        /// <param name="other">The other.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public virtual int CompareTo(Hand other)
        {
            if (this.Rank == other.Rank)
            {
                return 0;
            }

            return this.Rank < other.Rank ? -1 : 1;
        }

        /// <summary>The find player with highest non special card.</summary>
        /// <param name="player1Cards">The player 1 cards.</param>
        /// <param name="player2Cards">The player 2 cards.</param>
        /// <returns>The <see cref="int"/>.</returns>
        protected int CompareHighestCards(List<Card> player1Cards, List<Card> player2Cards)
        {
            int result = 0;

            int max = player1Cards.Count - 1;
            for (int i = max; i >= 0; i--)
            {
                if (player1Cards[i].Value < player2Cards[i].Value)
                {
                    result = -1;
                    break;
                }

                if (player1Cards[i].Value > player2Cards[i].Value)
                {
                    result = 1;
                    break;
                }
            }

            return result;
        }
    }
}