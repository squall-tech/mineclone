using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MineClone.camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineClone.render
{
    public class TringleTest
    {

        BasicEffect effect = new BasicEffect(MineClone.device);
       // Camera camera = MineClone.camera;
        VertexPositionTexture[] vertices = new VertexPositionTexture[3];

        public TringleTest(Game game)
        {
            vertices[0].Position = new Vector3(-0.5f, 0.5f, 0);
            vertices[0].TextureCoordinate.X = 0;
            vertices[0].TextureCoordinate.Y = 0;

            vertices[1].Position = new Vector3(0.5f, 0.5f, 0);
            vertices[1].TextureCoordinate.X = 1;
            vertices[1].TextureCoordinate.Y = 0;

            vertices[2].Position = new Vector3(-0.5f, -0.5f, 0);
            vertices[2].TextureCoordinate.X = 0;
            vertices[2].TextureCoordinate.Y = 1;

            effect.Texture = game.Content.Load<Texture2D>("texture");
            effect.TextureEnabled = true;
        }

        public void Draw()
        {
            //effect.View = camera.view;
            //effect.Projection = camera.projection;
            effect.World = Matrix.Identity;
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();                
                MineClone.device.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 1, VertexPositionTexture.VertexDeclaration);
            }
        }
    }
}
