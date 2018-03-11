using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Combination
    {
        int weight;
        List<Card> allCards;

        const int pairWeight = 50;
        const int twoPairsWeight = pairWeight * 5;
        const int threeWeight = twoPairsWeight * 5;
        const int straightWeight = threeWeight * 5;
        const int flashWeight = straightWeight * 5;
        const int fourWeight = flashWeight * 5;

        public Combination()
        {
            weight = 0;
            allCards = new List<Card>();
        }

        public Combination(Card playerCard1, Card playerCard2, Card flop1, Card flop2, Card flop3, Card turn = null, Card river = null)
        {
            weight = 0;
            allCards = new List<Card>();

            allCards.Add(playerCard1);
            allCards.Add(playerCard2);
            allCards.Add(flop1);
            allCards.Add(flop2);
            allCards.Add(flop3);
            allCards.Add(turn);
            allCards.Add(river);

            allCards.Sort(new CardComparer());
        }

        public int ComputeWeight()
        {
            // Ищем комбинации
            if (CheckFour())
            {
                weight += fourWeight;
            }
            else if (CheckFlash())
            {
                weight += flashWeight;
            }
            else if (CheckStraight())
            {
                weight += straightWeight;
            }
            else if (CheckThree())
            {
                weight += threeWeight;
            }
            else if (CheckTwoPairs())
            {
                weight += twoPairsWeight;
            }
            else if (CheckPair())
            {
                weight += pairWeight;
            }

            // Даем очки за каждую карту
            foreach (var card in allCards)
            {
                weight += (int)card.quality + 2;
            }

            return weight;
        }

        private bool CheckPair()
        {
            for (int i = 0; i < allCards.Count; i++)
            {
                for (int j = i; j < allCards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else if (allCards[i]?.quality == allCards[j]?.quality)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckTwoPairs()
        {
            int count = 0;

            for (int i = 0; i < allCards.Count; i++)
            {
                for (int j = i; j < allCards.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else if (allCards[i]?.quality == allCards[j]?.quality)
                    {
                        count++;
                    }
                }
            }

            if (count >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckThree()
        {
            Dictionary<CardQuality, int> cards = new Dictionary<CardQuality, int>();
            foreach (var card in allCards)
            {
                if (card != null)
                {
                    if (!cards.ContainsKey(card.quality))
                    {
                        cards.Add(card.quality, 1);
                    }
                    else
                    {
                        cards[card.quality]++;
                    }
                }
            }

            if (cards.ContainsValue(3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckStraight()
        {
            int count = 0;
            for (int i = 0; i < allCards.Count - 1; i++)
            {
                if (allCards[i] != null)
                {
                    if (allCards[i].quality == allCards[i + 1].quality + 1)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }

            if (count >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckFlash()
        {
            Dictionary<CardSuit, int> cards = new Dictionary<CardSuit, int>();
            foreach (var card in allCards)
            {
                if (card != null)
                {
                    if (!cards.ContainsKey(card.suit))
                    {
                        cards.Add(card.suit, 1);
                    }
                    else
                    {
                        cards[card.suit]++;
                    }
                }
            }

            if (cards.ContainsValue(5) || cards.ContainsValue(6) || cards.ContainsValue(7))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckFour()
        {
            Dictionary<CardQuality, int> cards = new Dictionary<CardQuality, int>();
            foreach (var card in allCards)
            {
                if (card != null)
                {
                    if (!cards.ContainsKey(card.quality))
                    {
                        cards.Add(card.quality, 1);
                    }
                    else
                    {
                        cards[card.quality]++;
                    }
                }
            }

            if (cards.ContainsValue(4))
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
