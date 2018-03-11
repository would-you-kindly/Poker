using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
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

        public override string ToString()
        {
            string card = suit.ToString();

            switch (quality)
            {
                case CardQuality._A:
                    card += "Ace";
                    break;
                case CardQuality._2:
                    card += "2";
                    break;
                case CardQuality._3:
                    card += "3";
                    break;
                case CardQuality._4:
                    card += "4";
                    break;
                case CardQuality._5:
                    card += "5";
                    break;
                case CardQuality._6:
                    card += "6";
                    break;
                case CardQuality._7:
                    card += "7";
                    break;
                case CardQuality._8:
                    card += "8";
                    break;
                case CardQuality._9:
                    card += "9";
                    break;
                case CardQuality._10:
                    card += "10";
                    break;
                case CardQuality._J:
                    card += "Jack";
                    break;
                case CardQuality._Q:
                    card += "Queen";
                    break;
                case CardQuality._K:
                    card += "King";
                    break;
                case CardQuality.Count:
                default:
                    break;
            }

            return card;
        }

        public override bool Equals(object obj)
        {
            Card otherCard = (Card)obj;

            if (this.suit == otherCard.suit && this.quality == otherCard.quality)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
