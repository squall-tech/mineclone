using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MineClone.camera;
using MineClone.Entities;

namespace MineClone.render
{
    public class BasicDraw
    {
        protected GraphicsDevice device = MineClone.device;
        //protected Camera camera = MineClone.camera;
       // BasicEffect effect = new BasicEffect(MineClone.device);

        Effect effect;
        public Texture2D texture;

        MineClone game;

        private VertexPositionColorTexture[] vertices;
        private short[] indices;

        VertexBuffer myVertexBuffer;
        IndexBuffer myIndexBuffer;

        private void CopyToBuffers()
        {
            myVertexBuffer = new VertexBuffer(device, VertexPositionColorTexture.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
            myVertexBuffer.SetData(vertices);
            myIndexBuffer = new IndexBuffer(device, typeof(short), indices.Length, BufferUsage.WriteOnly);
            myIndexBuffer.SetData(indices);
        }

        public BasicDraw(MineClone game)
        {            
            this.game = game;
            //effect.VertexColorEnabled = true;
            Texture2D texture = game.Content.Load<Texture2D>("textures");
            effect = game.Content.Load<Effect>("File");
            
            effect.Parameters["SpriteTexture"].SetValue(texture);
            
            //effect.Texture = texture;
            //effect.TextureEnabled = true;
        }

        public void renderEntities(List<Entity> entities)
        {
            BlockRender.count = 0;
            List<VertexPositionColorTexture> list = new List<VertexPositionColorTexture>();
            List<short> indice = new List<short>();
            foreach(Entity entity in entities)
            {
                Render render = entity.Render;
                render.SetVerticePostion(entity.Position);
                list.AddRange(render.Vertices);
                indice.AddRange(render.Indices);
            }
            vertices = list.ToArray();
            indices = indice.ToArray();
            CopyToBuffers();
        }

        public void Draw(GameTime gameTime)
        {
            //effect.View = game.Camera.getView();
            //effect.Projection = game.Camera.getProjection();
            //effect.World = Matrix.Identity;

            effect.Parameters["World"].SetValue(Matrix.Identity);
            effect.Parameters["View"].SetValue(game.Camera.getView());
            effect.Parameters["Projection"].SetValue(game.Camera.getProjection());
            effect.Parameters["AmbientIntensity"].SetValue(0.9f);


            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.Indices = myIndexBuffer;                
                device.SetVertexBuffer(myVertexBuffer);                
                device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, vertices.Length);
            }
        }        
    }
}
