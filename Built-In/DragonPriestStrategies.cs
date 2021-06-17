using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class DragonPriestStrategyHealing : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 15;
            monster.Health += monster.MagicPower + 25;
            return new List<StatPackage>() 
            { 
                new StatPackage(DmgType.Other, 0, "Smoczy kaplan sie leczy i odzyskuje " + (monster.MagicPower + 25) + " punktow zdrowia!") 
            };
        }
    }
    class DragonPriestStrategyFireball : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 30;
            int fireballProb = Index.RNG(0, 100);
            if (monster.Precision > fireballProb)
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Fire, monster.MagicPower / 2, "Smoczy kaplan wystrzeliwuje ognista kule ze swojej laski ktora leci wprost na Ciebie! (" + (monster.MagicPower / 2) + " dmg [magiczne])")
                };
            }
            return new List<StatPackage>()
            {
                new StatPackage(DmgType.Other, 0, "Smoczy kaplan nie trafia w Ciebie ognista kula!")
            };
        }
    }
    class DragonPriestStrategyThunderbolt : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 25;
            int thunderboltProb = Index.RNG(1, 4);
            return new List<StatPackage>()
            {
                new StatPackage(DmgType.Shock, (thunderboltProb * monster.MagicPower) / 3, 0, 0, 0, (thunderboltProb * monster.MagicPower) / 5,
                "Smoczy kaplan sciaga na Ciebie burze i pioruny trafiaja Cie kilkukrotnie (" + ((thunderboltProb * monster.MagicPower) / 3) + " dmg [magiczne]" +
                " i uplywaja z Ciebie zdolnosci magiczne" + ((thunderboltProb * monster.MagicPower) / 5) + " dmg [magiczne])")
            };
        }
    }
    class DragonPriestStrategyIceSpike : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 20;
            int iceSpikeProb = Index.RNG(0, 100);
            if (iceSpikeProb > monster.Precision)
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Ice, monster.MagicPower, monster.MagicPower/5, 0, 0, 0, "Smoczy kaplan formuje lodowy kolec ktory leci prosto w Twoja strone! (" + monster.MagicPower + " dmg [magiczne])" +
                    " i oslabia Twoja sile (" + monster.MagicPower/5 + " dmg [magiczne])")
                };
            }
            return new List<StatPackage>()
            {
                new StatPackage(DmgType.Other, 0, "Smoczy kaplan nie trafia w Ciebie lodowym kolcem!")
            };
        }
    }
}
