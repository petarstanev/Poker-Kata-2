// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Hand.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The hand.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Dynamic;

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

            var query = player1Cards.Where(c => player1Cards.Count(x => x.Value == c.Value) == 3);
            var query2 = player1Cards.Where(c => player1Cards.Count(x => x.Value == c.Value) == 2);
            if (query.Count() == 3 && query2.Count() == 2)
            {
                result = ComparePair(player1Cards, player2Cards, 3);
                if (result != 0) return result;
            }

            int a = player1Cards.Select(x => x.Value).Distinct().Count();

            if (player1Cards.Select(x => x.Value).Distinct().Count() <= 3)
            {
                result = ComparePair(player1Cards, player2Cards, 4);
                if (result != 0) return result;
            }

            if (player1Cards.Select(x => x.Value).Distinct().Count() <= 4)
            {
                result = ComparePair(player1Cards, player2Cards, 2);
                if (result != 0) return result;
            }


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

        protected int ComparePair(List<Card> player1Cards, List<Card> player2Cards, int numberOfCards)
        {
            int result = 0;
            int player1PairValue;
            int player2PairValue;
            if (numberOfCards == 2)
            {
                player1PairValue = GetPairValue(player1Cards);
                player2PairValue = GetPairValue(player2Cards);
            } else if (numberOfCards == 4)//2 pairs
            {
                player1PairValue = Get2PairsValue(player1Cards);
                player2PairValue = Get2PairsValue(player2Cards);
            }
            else
            {
                player1PairValue = Get3CardValue(player1Cards);
                player2PairValue = Get3CardValue(player2Cards);
            }


            if (player1PairValue < player2PairValue)
            {
                result = -1;
            }
            else if (player1PairValue > player2PairValue)
            {
                result = 1;
            }

            return result;
        }

        private int Get3CardValue(List<Card> playerCards)
        {
            int value = 0;
            for (int i = 0; i < playerCards.Count; i++)
            {
                for (int x = 0; x < playerCards.Count; x++)
                {
                    for (int y = 0; y < playerCards.Count; y++)
                    {

                        if (playerCards[x].Value == playerCards[i].Value && playerCards[i].Value == playerCards[y].Value && i != x && i != y && x!=y)
                        {
                            if (value < playerCards[x].Value)
                            {
                                value = playerCards[x].Value;
                            }
                        }
                    }
                }
            }
            return value;
        }
        private int GetPairValue(List<Card> playerCards)
        {
            int value = 0;
            for (int i = 0; i < playerCards.Count; i++)
            {
                for (int x = 0; x < playerCards.Count; x++)
                {
                    if (playerCards[x].Value == playerCards[i].Value && i != x)
                    {
                        if (value < playerCards[x].Value)
                        {
                            value = playerCards[x].Value;
                        }
                    }
                }
            }
            return value;
        }

        private int Get2PairsValue(List<Card> playerCards)
        {
            int pair1Value = 0;
            int pair2Value = 0;

            for (int i = 0; i < playerCards.Count; i++)
            {
                for (int x = 0; x < playerCards.Count; x++)
                {
                    if (playerCards[x].Value == playerCards[i].Value && i != x)
                    {
                            if (pair1Value > 0)
                            {
                                pair2Value = playerCards[x].Value;
                            }
                            else
                            {
                                pair1Value = playerCards[x].Value;
                            }
                    }
                }
            }
            return pair1Value + pair2Value;
        }
    }
}
