using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tennis.Enumerations;

namespace Tennis
{
    public class TenisScoreTests
    {
        [Test]
        public void PrintResult_WithNewTenisScoreInscance_ReturnsLoveResult()
        {
            //Arrange
            TennisScore sut = new TennisScore();

            //Act
            string result = sut.PrintResult();

            //Assert
            Assert.AreEqual("love - love", result);
        }

        [Test]
        [TestCase(PointEnum.Love, PointEnum.Love, "love - love")]
        [TestCase(PointEnum.Fifteen, PointEnum.Fifteen, "15 - 15")]
        [TestCase(PointEnum.Thirty, PointEnum.Thirty, "30 - 30")]
        [TestCase(PointEnum.Fourty, PointEnum.Fourty, "deuce")]
        public void PrintResult_WithDifferentPlayerScores_ReturnsValidResults(PointEnum firstPlayerScore, PointEnum secondPlayerScore, string expectedResult)
        {
            //Arrange
            TennisScore sut = new TennisScore(firstPlayerScore, secondPlayerScore);

            //Act
            string result = sut.PrintResult();

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(PointEnum.Fourty, PointEnum.Fourty, "player one advantage")]
        public void PrintResult_WithFirstPlayerAdvantage_ReturnValidResult(PointEnum firstPlayerScore, PointEnum secondPlayerScore, string expectedResult)
        {
            //Arrange
            TennisScore sut = new TennisScore(firstPlayerScore, secondPlayerScore);
            sut.FirstPlayerScorePoint();

            //Act
            string result = sut.PrintResult();

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(PointEnum.Fourty, PointEnum.Fourty, "player two advantage")]
        public void PrintResult_WithSecondPlayerAdvantage_ReturnValidResult(PointEnum firstPlayerScore, PointEnum secondPlayerScore, string expectedResult)
        {
            //Arrange
            TennisScore sut = new TennisScore(firstPlayerScore, secondPlayerScore);
            sut.SecondPlayerScorePoint();

            //Act
            string result = sut.PrintResult();

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(PointEnum.Advantage, PointEnum.Fourty, "player one wins")]
        public void PrintResult_WithAdvantageFirstPlayerScores_FirstPlayerWins(PointEnum firstPlayerScore, PointEnum secondPlayerScore, string expectedResult)
        {
            //Arrange
            TennisScore sut = new TennisScore(firstPlayerScore, secondPlayerScore);
            sut.FirstPlayerScorePoint();

            //Act
            string result = sut.PrintResult();

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(PointEnum.Fourty, PointEnum.Advantage, "player two wins")]
        public void PrintResult_WithAdvantageSecondPlayerScores_SecondPlayerWins(PointEnum firstPlayerScore, PointEnum secondPlayerScore, string expectedResult)
        {
            //Arrange
            TennisScore sut = new TennisScore(firstPlayerScore, secondPlayerScore);
            sut.SecondPlayerScorePoint();

            //Act
            string result = sut.PrintResult();

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void PrintResult_WithPlayersScoringUntilDeuce_ReturnsDeuce()
        {
            //Arrange
            TennisScore sut = new TennisScore();
            sut.FirstPlayerScorePoint();
            sut.FirstPlayerScorePoint();
            sut.FirstPlayerScorePoint();
            sut.SecondPlayerScorePoint();
            sut.SecondPlayerScorePoint();
            sut.SecondPlayerScorePoint();

            //Act
            string result = sut.PrintResult();

            //Assert
            Assert.AreEqual("deuce", result);
        }

        [Test]
        public void PrintResult_WithPlayerOneAdvantageSecondPlayerScores_ReturnsDeuce()
        {
            //Arrange
            TennisScore sut = new TennisScore();
            sut.FirstPlayerScorePoint();
            sut.FirstPlayerScorePoint();
            sut.FirstPlayerScorePoint();
            sut.SecondPlayerScorePoint();
            sut.SecondPlayerScorePoint();
            sut.SecondPlayerScorePoint();
            sut.FirstPlayerScorePoint();
            sut.SecondPlayerScorePoint();

            //Act
            string result = sut.PrintResult();

            //Assert
            Assert.AreEqual("deuce", result);
        }
    }
}
