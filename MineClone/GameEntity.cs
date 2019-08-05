using Microsoft.Xna.Framework;
using MineClone.render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClone
{
    public class OldGameEntity
    {
        public Vector3 Position { get; set; }
        public Render Render { get; set; }

        public OldGameEntity(Vector3 Position)
        {
            //this.Position = Position;
            //Render = new BlockRender();
            //Render.Position = Position;
        }
    }
}
