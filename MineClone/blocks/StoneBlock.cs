using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClone.blocks
{
    public class StoneBlock : Block
    {
        public StoneBlock() : base()
        {
            TextureCord = new Microsoft.Xna.Framework.Vector2(0, 1);
        }
    }
}
