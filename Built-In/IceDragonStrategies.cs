using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class IceDragonStrategyRegenerate : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 25;
            monster.Health += monster.MagicPower + 25;
            return new List<StatPackage>()
            {
                new StatPackage(DmgType.Physical, ((monster.MagicPower / 5) * 2), "Smok podniosl sie do lotu i odrzuca Cie podmuchem wiatru, zeby zregenerowac sily i odzyskuje " 
                + (monster.MagicPower + 25) + " punktow zdrowia! (" + ((monster.MagicPower / 5) * 2) + " dmg [fizyczne])")
            };
        }
    }
    class IceDragonStrategyIceBreath : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 35;
            return new List<StatPackage>()
            {
                new StatPackage(DmgType.Ice, monster.MagicPower * 2, monster.MagicPower / 2, 0, 0, 0, "Smok zieje na Ciebie swoim lodowym oddechem, od ktorego kostnieja Ci rece i wyprowadzasz slabsze uderzenia! ("
                + (monster.MagicPower * 2) + " dmg [magiczne] i utrata sily " + monster.MagicPower / 2 + " dmg [magiczne])")
            };
        }
    }
    class IceDragonStrategyTailFlick : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 30;
            int tailFlickProb = Index.RNG(0, 4);
            if (tailFlickProb > 1)
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, monster.Strength, 0, monster.Strength/2, 0, 0, "Smok podnosi swoj ogon i widzisz jak odpadaja czesci Twojej zbroi! ("
                    + monster.Strength + " dmg [fizyczne] i utrata zbroi" + monster.Strength/2 + " dmg [fizyczne])")
                };
            }
            return new List<StatPackage>() 
            { 
                new StatPackage(DmgType.Other, 0, "Smok nie trafia w miejsce gdzie stoisz!") 
            };
        }
    }
}