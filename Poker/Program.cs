// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics;

namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Properties;

    /// <summary>The program.</summary>
    public class Program
    {
        /// <summary>The main.</summary>
        /// <param name="args">The args.</param>
        public static void Main(string[] args)
        {
            List<string> games = Resources.poker.Split(new[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var scorer = new PokerScorer();
            var player1Wins = scorer.ScoreGames(games);

            stopwatch.Stop();

            Console.WriteLine(string.Format("Player 1 won {0} games. Calculation took {1}s", player1Wins, stopwatch.Elapsed.TotalSeconds));

            Console.ReadLine();
        }
    }
}