using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Card
    {
        public CardSuit suit;
        public CardQuality quality;

        public Card()
        {
            suit = CardSuit.Count;
            quality = CardQuality.Count;
        }

        public Card(CardSuit suit, CardQuality quality)
        {
            this.suit = suit;
            this.quality = quality;
        }
    }
}
