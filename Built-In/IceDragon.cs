using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class IceDragon : Monster
    {
        public IMonsterStrategy Strategy { get; set; }
        private List<StatPackage> playerMoves = new List<StatPackage> { };
        private bool regen = false;
        public IceDragon()
        {
            Health = 250;
            MagicPower = 35;
            Strength = 50;
            Armor = 90;
            Precision = 85;
            Stamina = 600;
            XPValue = 250;
            Name = "monster0012";
            BattleGreetings = "Wrraau!";
            Strategy = new IceDragonStrategyIceBreath();
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                if (playerMoves.Last().HealthDmg >= Health * 2)
                {
                    regen = true;
                    Strategy = new IceDragonStrategyRegenerate();
                }
                else if (playerMoves.Last().HealthDmg > (Health / 3))
                    Strategy = new IceDragonStrategyTailFlick();
                else
                    Strategy = new IceDragonStrategyIceBreath();

                return Strategy.MonsterResponse(playerMoves, this);
            }
            else
            {
                Stamina += 120;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Lodowy smok nie ma sil na dalsza walke i musi odpoczac!") };
            }
        }
        public override List<StatPackage> React(List<StatPackage> packs)
        {
            if (regen)
            {
                regen = false;
                if (playerMoves.Any())
                {
                    if (playerMoves.Last().DamageType == DmgType.Physical)
                    {
                        foreach (StatPackage pack in packs)
                        {
                            pack.ArmorDmg /= 2;
                            pack.Immunity();
                        }
                    }
                    else
                    {
                        foreach(StatPackage pack in packs)
                        {
                            pack.ArmorDmg /= 2;
                            pack.PartialImmunity();
                        }
                    }
                }
            }
            foreach (StatPackage pack in packs)
                playerMoves.Add(pack);
            return base.React(packs);
        }
    }
}