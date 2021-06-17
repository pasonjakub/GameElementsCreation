using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class FireElemental : Monster
    {
        public IMonsterStrategy Strategy { get; set; }
        private List<StatPackage> playerMoves = new List<StatPackage> { };
        public FireElemental()
        {
            Health = 180;
            Strength = 40;
            MagicPower = 64;
            Armor = 65;
            Precision = 85;
            Stamina = 250;
            XPValue = 140;
            Name = "monster0009";
            BattleGreetings = "Zostanie z Ciebie tylko pyl!";
            Strategy = new FireElementalStrategyClawsAttack();
        }
        public override List<StatPackage> BattleMove()
        {
            if (Stamina > 0)
            {
                if (playerMoves.Last().DamageType == DmgType.Fire)
                    Strategy = new FireElementalStrategyFireStorm();
                else if (playerMoves.Last().HealthDmg <= (Strength))
                    Strategy = new FireElementalStrategyFireball();
                else
                    Strategy = new FireElementalStrategyClawsAttack();

                return Strategy.MonsterResponse(playerMoves, this);
            }
            else
            {
                Stamina += 40;
                return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Zywiolak ognia nie ma sil na dalsza walke i musi odpoczac!") };
            }
        }
        public override List<StatPackage> React(List<StatPackage> packs)
        {
            if (playerMoves.Any())
                if (playerMoves.Last().DamageType == DmgType.Fire)
                    foreach (StatPackage pack in packs)
                        pack.PartialImmunity();     //is it proper way to implement partial immunity to a specific attack
            
            foreach (StatPackage pack in packs)
                playerMoves.Add(pack);
            return base.React(packs);
        }
    }
}
