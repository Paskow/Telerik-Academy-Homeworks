using System;
using System.Collections.Generic;
using System.Linq;
namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            var isValid = true;
            var startCardIndex = 1;

            foreach (var card in hand.Cards)
            {
                for (int i = startCardIndex; i < hand.Cards.Count; i++)
                {
                    if(card.Suit == hand.Cards[i].Suit && card.Face == hand.Cards[i].Face)
                    {
                        isValid = false;
                        break;
                    }
                }
                startCardIndex++;
                if (!isValid)
                {
                    break;
                }
            }

            return isValid;

        }

        public bool IsStraightFlush(IHand hand)
        {
            var cards = hand.Cards.Select(card => card)
                                  .OrderBy(face => (int)face.Face)
                                  .ToList();

            for (int i = 0; i < cards.Count - 1; i++)
            {
                var difference = Math.Abs((int)cards[i + 1].Face - (int)cards[i].Face);
                if (difference != 1)
                {
                    return false;
                }
            }

            foreach (var card in hand.Cards)
            {
                if (card.Suit != cards[0].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFourOfAKind(IHand hand)
        {            
            if(CardFaceCounter(hand.Cards).IndexOf(4) != -1)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if(CardFaceCounter(hand.Cards).IndexOf(3) != -1 &&
               CardFaceCounter(hand.Cards).Count == 2)
            {
                return true;
            }

            return false;
        }

        public bool IsFlush(IHand hand)
        {
            foreach (var card in hand.Cards)
            {
                if(card.Suit != hand.Cards[0].Suit)
                {
                    return false;                  
                }
            }

            if (IsStraightFlush(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            var cards = hand.Cards.Select(card => card)
                                 .OrderBy(face => (int)face.Face)
                                 .ToList();

            for (int i = 0; i < cards.Count - 1; i++)
            {
                var difference = Math.Abs((int)cards[i + 1].Face - (int)cards[i].Face);
                if (difference != 1)
                {
                    return false;
                }
            }

            if (IsStraightFlush(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
           var handCards = hand.Cards;
           if (CardFaceCounter(handCards).IndexOf(3) != - 1 &&
               CardFaceCounter(handCards).Count == 3)
            {
                return true;
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            var handCrads = hand.Cards;
            if(CardFaceCounter(handCrads).IndexOf(2) != -1 &&
               CardFaceCounter(handCrads).Count == 3)
            {
                return true;
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            var handCards = hand.Cards;

            if(CardFaceCounter(handCards).Count == 4 && 
               CardFaceCounter(handCards).IndexOf(2) != -1)
            {
                return true;
            }

            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            var handCards = hand.Cards;

            if(CardFaceCounter(handCards).Count == 5 && !IsFlush(hand) && !IsStraight(hand))
            {
                return true;
            }

            return false;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (firstHand.Type != secondHand.Type)
            {
                return (int)firstHand.Type > (int)secondHand.Type ? -1 : 1;
            }

            // TODO : Implement Logic for Hands with same type but different kicker
            throw new NotImplementedException();
        }

        private IList<int> CardFaceCounter(ICollection<ICard> cards)
        {
            var cardFaceCounts = new List<int>();
            for (int i = 0; i < 13; i++)
            {
                cardFaceCounts.Add(0);
            }

            foreach (var card in cards)
            {
                switch (card.Face)
                {
                    case CardFace.Two:
                        cardFaceCounts[0]++;
                        break;
                    case CardFace.Three:
                        cardFaceCounts[1]++;
                        break;
                    case CardFace.Four:
                        cardFaceCounts[2]++;
                        break;
                    case CardFace.Five:
                        cardFaceCounts[3]++;
                        break;
                    case CardFace.Six:
                        cardFaceCounts[4]++;
                        break;
                    case CardFace.Seven:
                        cardFaceCounts[5]++;
                        break;
                    case CardFace.Eight:
                        cardFaceCounts[6]++;
                        break;
                    case CardFace.Nine:
                        cardFaceCounts[7]++;
                        break;
                    case CardFace.Ten:
                        cardFaceCounts[8]++;
                        break;
                    case CardFace.Jack:
                        cardFaceCounts[9]++;
                        break;
                    case CardFace.Queen:
                        cardFaceCounts[10]++;
                        break;
                    case CardFace.King:
                        cardFaceCounts[11]++;
                        break;
                    case CardFace.Ace:
                        cardFaceCounts[12]++;
                        break;
                }
            }
            cardFaceCounts.RemoveAll(number => number == 0);
            return cardFaceCounts;
        }
    }
}
