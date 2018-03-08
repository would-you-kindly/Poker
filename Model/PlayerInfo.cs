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

        public PlayerInfo(string name, int money)
        {
            this.name = name;
            this.money = money;
        }
    }
}
