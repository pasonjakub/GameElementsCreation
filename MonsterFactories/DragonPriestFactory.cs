using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class DragonPriestFactory : MonsterFactory
    {
        private int a = 0;
        public override Monster Create()
        {
            if (a == 0)
            {
                a++;
                return new DragonPriestTomb();
            }
            else if (a  == 1)
            {
                a++;
                return new DragonPriest();
            }
            else return new IceDragon();
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (a == 0) return new DragonPriestTomb().GetImage();
            else if (a == 1) return new DragonPriest().GetImage();
            else return new IceDragon().GetImage();
        }
    }
}
