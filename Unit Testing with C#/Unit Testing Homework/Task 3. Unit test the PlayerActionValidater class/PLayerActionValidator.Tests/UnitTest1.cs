using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Santase.Logic.PlayerActionValidate;
using Santase.Logic.Players;
using Santase.Logic.Cards;
using Santase.Logic.RoundStates;
using System.Collections.Generic;
using System.Linq;

namespace PLayerActionValidator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsValid_usingValidPlayerActionPlayCard_ShuldBeValid()
        {     
            ICollection<Card> playerCards = new List<Card>();
            var deck = new Deck();
            var context = new PlayerTurnContext(new FinalRoundState(new StateManager()), deck.TrumpCard, deck.CardsLeft, 3, 4);
            bool result;

            playerCards.Add(new Card(CardSuit.Club, CardType.Jack));
            context.FirstPlayedCard = null;
            result = PlayerActionValidator.Instance.IsValid(PlayerAction.PlayCard(new Card(CardSuit.Club, CardType.Jack)),
                                   context,
                                   playerCards);

            Assert.AreEqual(true, result);
           
        }

        [TestMethod]
        public void IsValid_usingValidPlayerActionChangeTrump_ShuldBeValid()
        {
            ICollection<Card> playerCards = new List<Card>();
            var deck = new Deck();
            var context = new PlayerTurnContext(new MoreThanTwoCardsLeftRoundState(new StateManager()), deck.TrumpCard, deck.CardsLeft, 3, 4);
            bool result;


            playerCards.Add(new Card(deck.TrumpCard.Suit, CardType.Nine));
            context.FirstPlayedCard = null;
            result = PlayerActionValidator.Instance.IsValid(PlayerAction.ChangeTrump(),
                                   context,
                                   playerCards);

            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void IsValid_usingNullAction_ShuldThrowException()
        {
            ICollection<Card> playerCards = new List<Card>();
            PlayerAction playerAction = null;
            var deck = new Deck();
            var context = new PlayerTurnContext(new StartRoundState(new StateManager()), deck.TrumpCard, deck.CardsLeft, 3, 4);
            bool result;

            
            result = PlayerActionValidator.Instance.IsValid(playerAction,
                                   context,
                                   playerCards);

            Assert.AreEqual(false, result);

        }

        [TestMethod]
        public void IsValid_CloseGame_ShuldBeValid()
        {
            ICollection<Card> playerCards = new List<Card>();
            var deck = new Deck();
            var context = new PlayerTurnContext(new MoreThanTwoCardsLeftRoundState(new StateManager()), deck.TrumpCard, deck.CardsLeft, 3, 4);
            bool result;

            
            context.FirstPlayedCard = null;
            result = PlayerActionValidator.Instance.IsValid(PlayerAction.CloseGame(),
                                   context,
                                   playerCards);

            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void GetPossibleCardsToPlay_ShouldRetturnCorrectCollection()
        {
            var deck = new Deck();
            var context = new PlayerTurnContext(new MoreThanTwoCardsLeftRoundState(new StateManager()),
                                                deck.TrumpCard, deck.CardsLeft, 2, 2);
            var playerCards = new List<Card>()
            {
                new Card(CardSuit.Club, CardType.Ace),
                new Card(CardSuit.Diamond, CardType.King),
                new Card(CardSuit.Heart, CardType.Nine),
                new Card(CardSuit.Spade, CardType.Queen),
                new Card(CardSuit.Spade, CardType.Jack),
                new Card(CardSuit.Club, CardType.King)

            };
            ICollection<Card> result;

            context.FirstPlayedCard = null;
            result = PlayerActionValidator.Instance.GetPossibleCardsToPlay(context, playerCards);


            Assert.AreEqual(playerCards.Count, result.Count);
        }
    }
}
