// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parser.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   Defines the Parser type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace Poker
{
    public static class Parser
    {
        /// <summary>The get player cards.</summary>
        /// <param name="cardString">The cards.</param>
        /// <param name="player1Hand">The player 1 Hand.</param>
        /// <param name="player2Hand">The player 2 Hand.</param>
        public static void GetPlayerHands(string cardString, out Hand player1Hand, out Hand player2Hand)
        {
            cardString = cardString.Trim();
            var strings = cardString.Split(' ');

            var player1Cards = strings.Take(5).Select(StringToCard).OrderBy(x => x.Value).ToList();
            var player2Cards = strings.Skip(5).Select(StringToCard).OrderBy(x => x.Value).ToList();

            player1Hand = HandFactory.GetHand(player1Cards);
            player2Hand = HandFactory.GetHand(player2Cards);
        }

        /// <summary>The string to card.</summary>
        /// <param name="cardString">The card string.</param>
        /// <returns>The <see cref="Card" />.</returns>
        private static Card StringToCard(string cardString)
        {
            var value = CharToValue(cardString[0]);
            var suit = CharToSuit(cardString[1]);

            return new Card { Value = value, Suit = suit };
        }

        /// <summary>The char to suit.</summary>
        /// <param name="c">The c.</param>
        /// <returns>The <see cref="Suit" />.</returns>
        private static Suit CharToSuit(char c)
        {
            Suit suit;

            switch (c)
            {
                case 'D':
                    suit = Suit.Diamonds;
                    break;
                case 'C':
                    suit = Suit.Clubs;
                    break;
                case 'H':
                    suit = Suit.Hearts;
                    break;
                default:
                    suit = Suit.Spades;
                    break;
            }

            return suit;
        }

        /// <summary>The char to value.</summary>
        /// <param name="c">The c.</param>
        /// <returns>The <see cref="int" />.</returns>
        private static int CharToValue(char c)
        {
            int value;

            var success = int.TryParse(c.ToString(), out value);

            if (!success)
                switch (c)
                {
                    case 'T':
                        value = 10;
                        break;
                    case 'J':
                        value = 11;
                        break;
                    case 'Q':
                        value = 12;
                        break;
                    case 'K':
                        value = 13;
                        break;
                    case 'A':
                        value = 14;
                        break;
                }

            return value;
        }
    }
}