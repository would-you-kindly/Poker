using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Turn
    {
        public TurnType turnType;
        public int? money;

        public Turn()
        {
            this.turnType = TurnType.Fold;
            this.money = null;
        }

        public Turn(TurnType turnType, int? money = null)
        {
            this.turnType = turnType;
            this.money = money;
        }
    }
}
