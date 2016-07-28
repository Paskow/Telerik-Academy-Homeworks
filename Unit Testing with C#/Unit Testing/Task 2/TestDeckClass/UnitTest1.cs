using System;
using Santase.Logic.Cards;
using NUnit.Framework;
using Santase.Logic;
namespace TestDeckClass
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void IntializeDeckClass_ShouldInitializeCorrectly()
        {
            var deck = new Deck();

            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void GetNextCar_WhenThereIsNoCard_ShouldThrowException()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }


        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 5)]
        [TestCase(0, 3)]
        public void ChangeTrumbCard_ShouldChangeItCorrectly(int a, int b)
        {
            var deck = new Deck();
            var card = new Card((CardSuit)a, (CardType)b);

            deck.ChangeTrumpCard(card);

            Assert.AreEqual(card, deck.TrumpCard);
        }

        [Test]
        public void ChangeTrumbCard_WhenThereIsNoCardsLeft_ShouldChangeItCorrectly()
        {
            var deck = new Deck();
            var card = new Card(CardSuit.Club, CardType.Nine);

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            deck.ChangeTrumpCard(card);

            Assert.AreEqual(card, deck.TrumpCard);
        }
    }
}
