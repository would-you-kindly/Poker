using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class CardComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            Card c1 = (Card)x;
            Card c2 = (Card)y;

            if (c1.quality > c2.quality)
            {
                return 1;
            }
            else if (c1.quality < c2.quality)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
