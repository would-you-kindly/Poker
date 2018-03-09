using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class PlayerInfo
    {
        public string name;
        public int money;

        public PlayerInfo()
        {
            name = "Player1";
            money = 1000;
        }

        public PlayerInfo(string name, int money)
        {
            this.name = name;
            this.money = money;
        }

        public override string ToString()
        {
            return string.Format("Player {0} with ${1} money", name, money);
        }
    }
}
