using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MineClone.blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClone.render
{
    public abstract class Render
    {
        public VertexPositionColorTexture[] Vertices { get; set; }
        public List<short> Indices { get; set; }
        public Block Block { get; set; }

        public Render(Block block)
        {
            Block = block;
        }

        public abstract void SetVerticePostion(Vector3 postion);
        
    }
}
