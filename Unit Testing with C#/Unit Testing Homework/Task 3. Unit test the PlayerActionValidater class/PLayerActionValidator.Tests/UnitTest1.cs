using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Santase.Logic.PlayerActionValidate;
using Santase.Logic.Players;
using Santase.Logic.Cards;
using Santase.Logic.RoundStates;
using System.Collections.Generic;

namespace PLayerActionValidator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsValid_usingValidData_ShuldBeValid()
        {
            var actionValidator = new PlayerActionValidator();
            ICollection<Card> playerCards = new List<Card>();
            var deck = new Deck();
            var context = new PlayerTurnContext(new FinalRoundState(new StateManager()), deck.TrumpCard, deck.CardsLeft, 3, 4);
            bool result = actionValidator.IsValid(PlayerAction.PlayCard(new Card(CardSuit.Club, CardType.Jack)),
                                   context,
                                   playerCards);

            playerCards.Add(new Card(CardSuit.Club, CardType.Jack));
            context.FirstPlayedCard = null;
                     
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GetPossibleCardToPlay()
        {
            var actionValidator = new PlayerActionValidator();
            
        }
    }
}
