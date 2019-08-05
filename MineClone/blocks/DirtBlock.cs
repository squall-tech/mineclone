using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClone.blocks
{
    public class DirtBlock : Block
    {
        public DirtBlock()
        {
            TextureCord = new Microsoft.Xna.Framework.Vector2(1, 1);
            icons.Add(BlockSide.Top, new Microsoft.Xna.Framework.Vector2(0, 0));
        }
    }
}
