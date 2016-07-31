using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public HandType Type { get; set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            var hand = new StringBuilder();
            foreach (var card in Cards)
            {
                hand.AppendLine(card.ToString());
            }

            return hand.ToString().Trim();
        }
    }
}
