using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class OrcStrategyAxeSwing : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 25;
            return new List<StatPackage>() 
            { 
                new StatPackage(DmgType.Physical, monster.Strength, "Ork uderza Cie swoim toporem! (" + monster.Strength + " dmg [fizyczne])") 
            };
        }
    }
    class OrcStrategyBerserker : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 40;
            return new List<StatPackage>() 
            { 
                new StatPackage(DmgType.Physical, monster.Strength * 2, "Ork wpada w szal przez to ze zadajesz mu tyle obrazen i atakuje jeszcze mocniej! (" + monster.Strength * 2 + " dmg [fizyczne])") 
            };
        }
    }
    class OrcStrategyEnchantedAxeThrow : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 20;
            int axeThrowProb = Index.RNG(0, 100);
            if (monster.Precision > axeThrowProb)
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, monster.Strength, "Ork rzuca w Ciebie magicznym toporem! (" + monster.Strength + " dmg [fizyczne])"),
                    new StatPackage(DmgType.Ice, monster.MagicPower/5, "Zdajesz sobie sprawe, ze to nie byl zwyczajny topor jak Twoja rane zaczyna wypelnia przenikajacy chlod! (" + monster.MagicPower/5 + " dmg[magiczne])")
                };
            }
            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Ork nie trafia w Ciebie swoim toporem!") };
        }
    }
}
