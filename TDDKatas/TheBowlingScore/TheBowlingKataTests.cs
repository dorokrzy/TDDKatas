using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace TheBowlingGameKata
{
    [TestFixture]
    public class TheBowlingGameTests
    {

        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game();
        }

        [Test]
        public void GutterGamesScoresZero()
        {
            RollMany(20, 0);

            Assert.That(game.Score(), Is.EqualTo(0));
        }

        [Test]
        public void AllOnesScore20()
        {
            RollMany(20, 1);

            Assert.That(game.Score(), Is.EqualTo(20));
        }

        [Test]
        public void OneSpareThreePinsAndThenZeros()
        {
            RollSpare();
            game.Roll(3);
            RollMany(17, 0);

            Assert.That(game.Score(), Is.EqualTo(16));
        }


        [Test]
        public void testOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);

            Assert.That(game.Score(), Is.EqualTo(24));
        }

        [Test]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.That(game.Score(), Is.EqualTo(300));
        }


        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
                game.Roll(pins);
        }


        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }


        private void RollStrike()
        {
            game.Roll(10);
        }
    }

    public class Game
    {
        private int currentRoll = 0;
        private int[] rolls = new int[21];

        public void Roll(int pins)
        {   
            rolls[currentRoll++] = pins;
        }



        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
         
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }
            }
            return score;
        }

        private int SumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return rolls[frameIndex + 1] + rolls[frameIndex + 2];
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

    }
}
