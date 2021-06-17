using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class FireElementalStrategyClawsAttack : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 35;
            if (playerMoves.Last().DamageType == DmgType.Physical)      //player dealt physical damage
            { 
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Physical, monster.Strength, "Zywiolak ognia atakuje Cie swoimi plonacymi szponami! (" + monster.Strength + " dmg [fizyczne])"),
                    new StatPackage(DmgType.Fire, monster.MagicPower/8, "Zwegla Ci sie skora przez Zywiolaka ognia! (" + monster.MagicPower/8 + " dmg [magiczne])"),
                    new StatPackage(DmgType.Fire, monster.MagicPower/16, "Atakujesz bronia wrecz i zywiolak Cie pali! (" + monster.MagicPower/16 + " dmg [magiczne])")
                };
            }
            return new List<StatPackage>()
            {
                new StatPackage(DmgType.Physical, monster.Strength, "Zywiolak ognia atakuje Cie swoimi plonacymi szponami! (" + monster.Strength + " dmg [fizyczne])"),
                new StatPackage(DmgType.Fire, monster.MagicPower/8, "Zwegla Ci sie skora przez Zywiolaka ognia! (" + monster.MagicPower/8 + " dmg [magiczne])")
            };
        }
    }
    class FireElementalStrategyFireball : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 30;
            int fireballProb = Index.RNG(0, 100);
            if (monster.Precision > fireballProb)
            {
                if (playerMoves.Last().DamageType == DmgType.Physical)
                {
                    return new List<StatPackage>()
                    {
                        new StatPackage(DmgType.Fire, monster.MagicPower, "Zywiolak formuje ognista kule ktora leci wprost na Ciebie! (" + monster.MagicPower + " dmg [magiczne])"),
                        new StatPackage(DmgType.Fire, monster.MagicPower/16, "Atakujesz bronia wrecz i zywiolak Cie pali! (" + monster.MagicPower/16 + " dmg [magiczne])")
                    };
                }
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Fire, monster.MagicPower, "Zywiolak formuje ognista kule ktora leci wprost na Ciebie! (" + monster.MagicPower + " dmg [magiczne])")
                };
            }
            if (playerMoves.Last().DamageType == DmgType.Physical)
            {
                return new List<StatPackage>()
                {
                    new StatPackage(DmgType.Other, 0, "Zywiolak nie trafia w Ciebie ognista kula!"),
                    new StatPackage(DmgType.Fire, monster.MagicPower/16, "Atakujesz bronia wrecz i zywiolak Cie pali! (" + monster.MagicPower/16 + " dmg [magiczne])")
                };
            }
            return new List<StatPackage>()
            {
                new StatPackage(DmgType.Other, 0, "Zywiolak nie trafia w Ciebie ognista kula!")
            };
        }
    }
    class FireElementalStrategyFireStorm : IMonsterStrategy
    {
        public List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster)
        {
            monster.Stamina -= 45;
            return new List<StatPackage>()
            {
                new StatPackage(DmgType.Fire, monster.MagicPower + 11, "Zywiolak wpada w szal ze smiesz uzywac jego broni przeciw niemu! (" + (monster.MagicPower + 11) + " dmg [magiczne])")
            };
        }
    }
}
