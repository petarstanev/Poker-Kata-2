// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestPokerScorer.cs" company="Christian Coda">
//   Copyright (c) Christian Coda 2013
// </copyright>
// <summary>
//   The test poker scorer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Poker.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The test poker scorer.</summary>
    [TestClass]
    public class TestPokerScorer
    {
        /// <summary>The test high card ace beats high card king.</summary>
        [TestMethod]
        public void WhenPlayer1HasHighCardKingAndPlayer2HasHighCardQueenPlayer1Wins()
        {
            // Given
            const string Cards = "2H 3D 5S KC AS 2D 4C 6S QH AC";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has pair of kings and player 2 has high card ace player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasPairOfKingsAndPlayer2HasHighCardAcePlayer1Wins()
        {
            // Given
            const string Cards = "2H 3D 5S KC KS 2D 4C 6S KH AC";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has pair of aces and player 2 has pair of kings player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasPairOfAcesAndPlayer2HasPairOfKingsPlayer1Wins()
        {
            // Given
            const string Cards = "2H 3D AS AC KS 2D 4C JS KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has pair of kings high card ace and player 2 has pair of kings high card jack player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasPairOfKingsHighCardAceAndPlayer2HasPairOfKingsHighCardJackPlayer1Wins()
        {
            // Given
            const string Cards = "2H 3D AS KC KS 2D 4C JS KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has two pair and player 2 has pair player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasTwoPairAndPlayer2HasPairPlayer1Wins()
        {
            // Given
            const string Cards = "2H 3D 3S KC KS 2D 4C JS KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has two pair king over three and player 2 has two pair king over two player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasTwoPairKingOverThreeAndPlayer2HasTwoPairKingOverTwoPlayer1Wins()
        {
            // Given
            const string Cards = "2H 3D 3S KC KS 2D 2C JS KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has two pair king over three and player 2 has two pair jack over four player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasTwoPairKingOverThreeAndPlayer2HasTwoPairJackOverFourPlayer1Wins()
        {
            // Given
            const string Cards = "2H 3D 3S KC KS 4D 4C JS JH 2D";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has two pair king over three high card ace and player 2 has two pair king over three high card two player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasTwoPairKingOverThreeHighCardAceAndPlayer2HasTwoPairKingOverThreeHighCardTwoPlayer1Wins()
        {
            // Given
            const string Cards = "AH 3D 3S KC KS 3C 3H 2S KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has three aces and player 2 has two pairs player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasThreeAcesAndPlayer2HasTwoPairsPlayer1Wins()
        {
            // Given
            const string Cards = "AH 3D 2S AC AS 3C 3H 2D KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has three aces and player 2 has three kings player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasThreeAcesAndPlayer2HasThreeKingsPlayer1Wins()
        {
            // Given
            const string Cards = "AH 3D 2S AC AS 3C 4H KC KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has straight and player 2 has three kings player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasStraightAndPlayer2HasThreeKingsPlayer1Wins()
        {
            // Given
            const string Cards = "4H 3D 2S 5C 6S 3C 4D KC KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has straight high card 7 and player 2 straight high card 6 player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasStraightHighCard7AndPlayer2StraightHighCard6Player1Wins()
        {
            // Given
            const string Cards = "4C 3C 7S 5D 6C 4H 3D 2S 5C 6S";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has flush and player 2 straight high card 6 player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasFlushAndPlayer2StraightHighCard6Player1Wins()
        {
            // Given
            const string Cards = "4C 3C 8C 5C 6C 4H 3D 2S 5D 6S";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has flush high card 8 and player 2 has flush high card 7 player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasFlushHighCard8AndPlayer2HasFlushHighCard7Player1Wins()
        {
            // Given
            const string Cards = "4C 3C 8C 5C 6C 4H 3H 2H 5H 7H";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has full house and player 2 has flush player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasFullHouseAndPlayer2HasFlushPlayer1Wins()
        {
            // Given
            const string Cards = "4C 4D 4S JC JH 4H 3H 2H 5H 7H";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has full house with 3 fours and player 2 has full house with 3 twos player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasFullHouseWith3FoursAndPlayer2HasFullHouseWith3TwosPlayer1Wins()
        {
            // Given
            const string Cards = "4C 4D 4S JC JH 2S 2D 2H KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has four of a kind and player 2 has full house player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasFourOfAKindAndPlayer2HasFullHousePlayer1Wins()
        {
            // Given
            const string Cards = "4C 4D 4S 4H JH 2S 2D 2H KH KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has four of a kind fours and player 2 has four of a kind twos player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasFourOfAKindFoursAndPlayer2HasFourOfAKindTwosPlayer1Wins()
        {
            // Given
            const string Cards = "4C 4D 4S 4H JH 2S 2D 2H 2C KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has straight flush and player 2 has four of a kind twos player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasStraightFlushAndPlayer2HasFourOfAKindTwosPlayer1Wins()
        {
            // Given
            const string Cards = "4C 5C 6C 7C 8C 2S 2D 2H 2C KD";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has straight flush high card 8 and player 2 has straight flush high card 7 player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasStraightFlushHighCard8AndPlayer2HasStraightFlushHighCard7Player1Wins()
        {
            // Given
            const string Cards = "4C 5C 6C 7C 8C 3S 4S 6S 5S 7S";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }

        /// <summary>The when player 1 has royal flush and player 2 has straight flush player 1 wins.</summary>
        [TestMethod]
        public void WhenPlayer1HasRoyalFlushAndPlayer2HasStraightFlushPlayer1Wins()
        {
            // Given
            const string Cards = "AC KC QC JC TC 3S 4S 6S 5S 7S";
            var scorer = new PokerScorer();

            // When
            bool player1Won = scorer.ScoreGame(Cards);

            // Then
            Assert.IsTrue(player1Won);
        }
    }
}
