using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public ServerPlayerInfo(string name, int money, int seat) :
            base(name, money)
        {
            this.seat = seat;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("on seat {0}", seat);
        }
    }
}
