using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack_csharp
{
    public class CardStack
    {
        private List<Card> cards;

        public CardStack()
        {
            cards = new List<Card>();
        }

        public Card Draw()
        {
            Card card = cards[0]; // check cards not empty?
            cards.RemoveAt(0);
            return card;
        }

        public void Shuffle()
        {
            cards.Clear();

            for (int i = 1; i < 5; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    int card_value = j;
                    if (j > 10)
                    {
                        card_value = 10;
                    }

                    Card card = new Card(card_value);
                    cards.Add(card);
                }
            }

            Random rnd = new Random();
            cards = cards.OrderBy(a => rnd.Next()).ToList();

        }
    }
}
