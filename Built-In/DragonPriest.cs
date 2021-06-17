using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class DragonPriest : Monster
    {
        public IMonsterStrategy Strategy { get; set; }
        private List<StatPackage> playerMoves = new List<StatPackage> { };
        private int healingCounter = 0;
        public DragonPriest()
        {
            Health = 170;
            MagicPower = 50;
            Armor = 40;
            Precision = 85;
            Stamina = 250;
            XPValue = 175;
            Name = "monster0011";
            BattleGreetings = "Jak smiales dotknac tego grobowca!";
            Strategy = new DragonPriestStrategyFireball();
        }
        public override List<StatPackage> BattleMove()
        {
            List<DmgType> magicDmgTypes = new List<DmgType> { DmgType.Fire, DmgType.Air, DmgType.Water, DmgType.Earth, DmgType.Ice, DmgType.Shock, DmgType.Psycho };
            if (Stamina > 0)
            {
                if (playerMoves.Last().HealthDmg >= (Health * 2) && healingCounter < 2)
                {
                    healingCounter++;
                    Strategy = new DragonPriestStrategyHealing();
                }
                else if (playerMoves.Last().HealthDmg > (Health / 3))
                {
                    if (playerMoves.Last().DamageType == DmgType.Physical)
                        Strategy = new DragonPriestStrategyIceSpike();
                    else if (magicDmgTypes.Contains(playerMoves.Last().DamageType))
                        Strategy = new DragonPriestStrategyThunderbolt();
                }
                else
                    Strategy = new DragonPriestStrategyFireball();

                return Strategy.MonsterResponse(playerMoves, this);
            }
            else
            {
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Smoczy kaplan nie ma sil na dalsza walke!") };
            }
        }
        public override List<StatPackage> React(List<StatPackage> packs)
        {
            if (playerMoves.Any())
                if (playerMoves.Last().DamageType == DmgType.Fire)
                    foreach (StatPackage pack in packs)
                        pack.Aversion();

            foreach (StatPackage pack in packs)
                playerMoves.Add(pack);
            return base.React(packs);
        }
    }
}
