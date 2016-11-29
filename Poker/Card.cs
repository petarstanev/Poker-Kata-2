// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Card.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The suit.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Poker
{
    /// <summary>The suit.</summary>
    public enum Suit
    {
        /// <summary>The diamonds.</summary>
        Diamonds = 0, 

        /// <summary>The clubs.</summary>
        Clubs = 1, 

        /// <summary>The hearts.</summary>
        Hearts = 2, 

        /// <summary>The spades.</summary>
        Spades = 3
    }

    /// <summary>The card.</summary>
    public class Card
    {
        /// <summary>Gets or sets the suit.</summary>
        public Suit Suit { get; set; }

        /// <summary>Gets or sets the value.</summary>
        public int Value { get; set; }
    }
}