using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Orc : Monster
    {
        public IMonsterStrategy Strategy { get; set; }
        private List<StatPackage> playerMoves = new List<StatPackage> { };
        public Orc()
        {
            Health = 200;
            Strength = 30;
            MagicPower = 50;
            Armor = 45;
            Precision = 75;
            Stamina = 450;
            XPValue = 110;
            Name = "monster0008";
            BattleGreetings = "Wyglada na to, ze mieso wrocilo do menu!";
            Strategy = new OrcStrategyAxeSwing();
        }
        public override List<StatPackage> BattleMove()
        {
            List<DmgType> magicDmgTypes = new List<DmgType> { DmgType.Fire, DmgType.Air, DmgType.Water, DmgType.Earth, DmgType.Ice, DmgType.Shock, DmgType.Psycho };
            //List<DmgType> magicDmgTypes = new List<DmgType> { DmgType.Fire, DmgType.Water, DmgType.Earth, DmgType.Ice, DmgType.Psycho };

            if (Stamina > 0)
            {
                if (magicDmgTypes.Contains(playerMoves.Last().DamageType))
                    Strategy = new OrcStrategyEnchantedAxeThrow();
                else if (playerMoves.Last().HealthDmg > (Strength * 1.5))
                    Strategy = new OrcStrategyBerserker();
                else
                    Strategy = new OrcStrategyAxeSwing();

                return Strategy.MonsterResponse(playerMoves, this);
            }
            else
            {
                Stamina += 30;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Ork nie ma sil na dalsza walke i musi odpoczac!") };
            }
        }
        public override List<StatPackage> React(List<StatPackage> packs)
        {
            foreach (StatPackage pack in packs)
                playerMoves.Add(pack);
            return base.React(packs);
        }
    }
}
