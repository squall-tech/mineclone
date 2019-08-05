using Microsoft.Xna.Framework;
using MineClone.Entities;
using MineClone.render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClone.blocks
{

    public enum BlockSide
    {
        Top,
        Botton,
        South,
        North,
        West,
        East
    }
    
    public class Block
    {
        public Vector2 TextureCord { get; set; }        

        public Dictionary<BlockSide, Vector2> icons = new Dictionary<BlockSide, Vector2>();

        private Render render;
        
        public Vector2 GetTextureCord(BlockSide blockSide)
        {
            if (icons.Count > 0 && icons.ContainsKey(blockSide))
            {
                return icons[blockSide];
            }
            return TextureCord;
        }

        public Entity CreateEntity()
        {
            return new Entity()
            {
                Block = this
            };
        }

        public Render GetRender()
        {            
            return new BlockRender(this);
        }

    }
}
