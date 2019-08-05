using Microsoft.Xna.Framework;
using MineClone.blocks;
using MineClone.render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClone.Entities
{
    public class Entity
    {
        public Vector3 Position { get; set; }
        public Block Block { get; set; }

        private Render _render;

        public Render Render
        {
            get
            {
                if (_render == null)
                {
                    _render = Block.GetRender();
                }
                return _render;
            }            
        }

    }
}
