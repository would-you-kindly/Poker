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
        public Dictionary<int, bool> deck;

        public CardDeck()
        {
            deck = new Dictionary<int, bool>((int)CardSuit.Count * (int)CardQuality.Count);
            Reset();
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
            } while (deck.ContainsKey((int)suit | (int)quality) && deck[(int)suit | (int)quality]);

            // Запоминаем, что выбранная карта выдана
            deck.Add((int)suit | (int)quality, true);

            return new Card(suit, quality);
        }

        public void Reset()
        {
            deck.Clear();
        }
    }
}
