using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class DragonPriestTomb : Monster
    {
        public DragonPriestTomb()
        {
            Health = 10;
            Armor = 10;
            XPValue = 5;
            Name = "monster0010";
            BattleGreetings = "Widzisz grobowiec, ktory moze nalezec do poteznej istoty";
        }
        public override List<StatPackage> BattleMove()
        {
            return new List<StatPackage>() { new StatPackage(DmgType.Other) };
        }
    }
}
