using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedADV
{
    internal class Player
    {
        public PlayerClass Class { get; private set; }

        public Player(PlayerClass playerClass)
        {
            Class = playerClass;
        }
    }
}

