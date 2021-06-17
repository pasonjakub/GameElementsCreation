using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    interface IMonsterStrategy
    {
        List<StatPackage> MonsterResponse(List<StatPackage> playerMoves, Monster monster);
    }
}
