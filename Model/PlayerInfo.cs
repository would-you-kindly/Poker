using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class PlayerInfo
    {
        public string name;
        public int money;
        public string endPoint;

        public PlayerInfo()
        {
            name = "Player1";
            money = 1000;
            endPoint = "";
        }

        public PlayerInfo(string name, int money, string endPoint)
        {
            this.name = name;
            this.money = money;
            this.endPoint = endPoint;
        }

        public override string ToString()
        {
            return string.Format("Player {0};\n${1};\n", name, money);
        }
    }
}
