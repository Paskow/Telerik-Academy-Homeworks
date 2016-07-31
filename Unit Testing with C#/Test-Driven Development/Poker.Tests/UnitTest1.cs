using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class PokerTests
    {
        [TestMethod]
        public void CardToString_ShouldReturnCardRepresentAssStringCorrectly()
        {
            var card = new Card(CardFace.Nine, CardSuit.Clubs);

            Assert.AreEqual("Nine of Clubs", card.ToString());
        }

        [TestMethod]           
        public void HandToString_ShouldReturnCardRepresentAssStringCorrectly()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };
            var hand = new Hand(handCards);
            var expected = @"Ace of Clubs
Ace of Diamonds
Ace of Hearts
Ace of Spades
King of Hearts";



            Assert.AreEqual(expected, hand.ToString());
        }

        [TestMethod]
        public void IsValidHand_UseValidHand_ShuldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidHand_UseInValidHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsValidHand(hand));
        }

        [TestMethod]
        public void IsFlush_UseFlusHand_ShouldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsFlush(hand));
        }

        [TestMethod]
        public void IsFlush_UseStraightFlusHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);
            
            Assert.IsFalse(new PokerHandsChecker().IsFlush(hand));
        }

        [TestMethod]
        public void IsFlush_UseNoFlusHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);
            
            Assert.IsFalse(new PokerHandsChecker().IsFlush(hand));
        }

        [TestMethod]
        public void IsFourOfKind_UseValidFourOfKindHand_ShouldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsFourOfKind_UseInValidFourOfKindHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsFourOfAKind(hand));
        }

        [TestMethod]
        public void IsFullHouse_UseValidFullHouseHand_ShouldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsFullHouse(hand));
        }

        [TestMethod]
        public void IsFullHouse_UseInValidFullHouseHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsFullHouse(hand));
        }

        [TestMethod]
        public void IsFullHouse_UseThreeOfKindHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsFullHouse(hand));
        }

        [TestMethod]
        public void IsStraight_UseValidStraightHand_ShouldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsStraight(hand));
        }

        [TestMethod]
        public void IsStraight_UseInValidStraightHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsStraight(hand));
        }

        [TestMethod]
        public void IsStraight_UseStraightFlushHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsStraight(hand));
        }

        [TestMethod]
        public void IsThreeOfKind_UseValidThreeOfKindHand_ShouldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void IsThreeOfKind_UseFullHouseHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void IsTwoPair_UseValidTwoPairHand_ShouldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Spades)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsTwoPair(hand));
        }

        [TestMethod]
        public void IsTwoPair_UseOtherHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsTwoPair(hand));
        }

        [TestMethod]
        public void IsOnePair_UseValidOnePairHand_ShouldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsOnePair(hand));
        }

        [TestMethod]
        public void IsOnePair_UseOtherHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts )
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsOnePair(hand));
        }

        [TestMethod]
        public void IsHighCard_UseValidHighCardHand_ShouldReturnTrue()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades)
            };
            var hand = new Hand(handCards);

            Assert.IsTrue(new PokerHandsChecker().IsHighCard(hand));
        }

        [TestMethod]
        public void IsHighCard_UseFlushHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsHighCard(hand));
        }

        [TestMethod]
        public void IsHighCard_UseStraightHand_ShouldReturnFalse()
        {
            var handCards = new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var hand = new Hand(handCards);

            Assert.IsFalse(new PokerHandsChecker().IsHighCard(hand));
        }

        [TestMethod]
        public void CompareHands_UsingDifferentTypeHands_ShouldReturnMinusOne()
        {
            var firstHandCards = new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var secondHandCards = new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };
            var firstHand = new Hand(firstHandCards);
            var secondHand = new Hand(secondHandCards);

            firstHand.Type = HandType.Straight;
            secondHand.Type = HandType.FullHouse;

            Assert.AreEqual(-1, new PokerHandsChecker().CompareHands(secondHand, firstHand));
        }

        [TestMethod]
        public void CompareHands_UsingDifferentTypeHands_ShouldReturnOne()
        {
            var firstHandCards = new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var secondHandCards = new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };
            var firstHand = new Hand(firstHandCards);
            var secondHand = new Hand(secondHandCards);

            firstHand.Type = HandType.Straight;
            secondHand.Type = HandType.FullHouse;

            Assert.AreEqual(1, new PokerHandsChecker().CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void CompareHands_UsingSameTypeAndSamePowerHands_ShouldReturnZero()
        {
            var firstHandCards = new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };
            var secondHandCards = new List<ICard>()
            {
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts)
            };
            var firstHand = new Hand(firstHandCards);
            var secondHand = new Hand(secondHandCards);

            firstHand.Type = HandType.Straight;
            secondHand.Type = HandType.Straight;

            Assert.AreEqual(0, new PokerHandsChecker().CompareHands(firstHand, secondHand));
        }
    }
}
