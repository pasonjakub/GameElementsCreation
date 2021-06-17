using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Game.Engine.Monsters.MonsterFactories
{
    [Serializable]
    class FireElementalFactory : MonsterFactory
    {
        public override Monster Create()
        {
            return new FireElemental();
        }

        public override Image Hint()
        {
            return new FireElemental().GetImage();
        }
    }
}
