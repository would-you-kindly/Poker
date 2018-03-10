using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class ServerPlayerInfo : PlayerInfo
    {
        public int seat;
        public bool diller;
        public bool yourMove;
        public Card card1;
        public Card card2;


        public ServerPlayerInfo() :
            base()
        {
            seat = 0;
            diller = false;
            yourMove = false;
            card1 = null;
            card2 = null;
        }

        public ServerPlayerInfo(string name, int money, string endPoint, int seat) :
            base(name, money, endPoint)
        {
            this.seat = seat;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Seat {0};\nCards {1}, {2};\n", seat, card1, card2);
        }
    }
}
