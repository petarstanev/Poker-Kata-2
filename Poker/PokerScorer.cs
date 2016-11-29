// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PokerScorer.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   Defines the PokerScorer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Poker
{
    using System.Collections.Generic;

    /// <summary>The poker scorer.</summary>
    public class PokerScorer
    {
        /// <summary>
        /// Scores a list of poker games
        /// </summary>
        /// <param name="games">The list of games to score</param>
        /// <returns>The number of games player 1 wins</returns>
        public int ScoreGames(List<string> games)
        {
            int player1Wins = 0;

            foreach (var game in games)
            {
                var player1Won = ScoreGame(game);

                if (player1Won)
                {
                    player1Wins++;
                }
            }

            return player1Wins;
        }

        /// <summary>Scores a poker game.</summary>
        /// <param name="cards">A string of 10 cards in the format [value][suit] separated by spaces.
        ///     The first 5 are for player 1, the last 5 for player 2.</param>
        /// <returns>True if player 1 wins, else false if player 2 wins.</returns>
        public bool ScoreGame(string cards)
        {
            Hand player1Hand, player2Hand;
            Parser.GetPlayerHands(cards, out player1Hand, out player2Hand);

            var player1Won = player1Hand.CompareTo(player2Hand) > 0;

            return player1Won;
        }     
    }
}