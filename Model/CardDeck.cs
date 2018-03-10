using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CardDeck
    {
        // Если карта выдана, то true, иначе false
        public Dictionary<string, bool> deck;

        public CardDeck()
        {
            deck = new Dictionary<string, bool>((int)CardSuit.Count * (int)CardQuality.Count);
        }

        public Card GetRandomCard()
        {
            Random random = new Random();
            CardSuit suit;
            CardQuality quality;

            // Ищем невыданную карту
            do
            {
                suit = (CardSuit)random.Next((int)CardSuit.Count);
                quality = (CardQuality)random.Next((int)CardQuality.Count);
            } while (deck.ContainsKey(suit.ToString() + quality.ToString()) && deck[suit.ToString() + quality.ToString()]);

            // Запоминаем, что выбранная карта выдана
            deck.Add(suit.ToString() + quality.ToString(), true);

            return new Card(suit, quality);
        }

        public void Reset()
        {
            deck.Clear();
        }
    }
}
