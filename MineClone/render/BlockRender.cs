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
    public class BlockRender : Render
    {
        public static short count;

        public bool[] hasNeighbor = new bool[6];

        float div = 0.50f;
        
        public BlockRender(Block block) : base(block)
        {            
            SetUpVertices();            
        }

        private void SetUpTop()
        {
            Vector2 posTexture = Block.GetTextureCord(BlockSide.Top);

            Vertices[0].Position = new Vector3(-0.5f, 0.5f, -0.5f);
            Vertices[0].TextureCoordinate.X = posTexture.X * div;
            Vertices[0].TextureCoordinate.Y = posTexture.Y * div;

            Vertices[1].Position = new Vector3(0.5f, 0.5f, -0.5f);
            Vertices[1].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[1].TextureCoordinate.Y = posTexture.Y * div;

            Vertices[2].Position = new Vector3(-0.5f, 0.5f, 0.5f);
            Vertices[2].TextureCoordinate.X = posTexture.X * div;
            Vertices[2].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[3].Position = new Vector3(0.5f, 0.5f, 0.5f);
            Vertices[3].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[3].TextureCoordinate.Y = (posTexture.Y +1) * div;


            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 3));

            count = (short)(count + 4);
        }

        private void SetUpBotton()
        {

            Vector2 posTexture = Block.GetTextureCord(BlockSide.Botton);

            Vertices[4].Position = new Vector3(-0.5f, -0.5f, 0.5f);
            Vertices[4].TextureCoordinate.X = posTexture.X * div;
            Vertices[4].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[5].Position = new Vector3(0.5f, -0.5f, 0.5f);
            Vertices[5].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[5].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[6].Position = new Vector3(0.5f, -0.5f, -0.5f);
            Vertices[6].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[6].TextureCoordinate.Y = posTexture.Y * div;

            
            Vertices[7].Position = new Vector3(-0.5f, -0.5f, -0.5f);
            Vertices[7].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[7].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 3));

            count = (short)(count + 4);
            
        }

        private void SetSouth()
        {
            Vector2 posTexture = Block.GetTextureCord(BlockSide.South);

            Vertices[8].Position = new Vector3(-0.5f, 0.5f, 0.5f);
            Vertices[8].TextureCoordinate.X = posTexture.X * div;
            Vertices[8].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[9].Position = new Vector3(0.5f, 0.5f, 0.5f);
            Vertices[9].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[9].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[10].Position = new Vector3(0.5f, -0.5f, 0.5f);
            Vertices[10].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[10].TextureCoordinate.Y = posTexture.Y * div;


            Vertices[11].Position = new Vector3(-0.5f, -0.5f, 0.5f);
            Vertices[11].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[11].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 3));

            count = (short)(count + 4);
        }

        private void SetNorth()
        {
            Vector2 posTexture = Block.GetTextureCord(BlockSide.North);

            Vertices[12].Position = new Vector3(-0.5f, -0.5f,  -0.5f);
            Vertices[12].TextureCoordinate.X = posTexture.X * div;
            Vertices[12].TextureCoordinate.Y = posTexture.Y * div;

            Vertices[13].Position = new Vector3(0.5f, -0.5f, -0.5f);
            Vertices[13].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[13].TextureCoordinate.Y = posTexture.Y * div;

            Vertices[14].Position = new Vector3(-0.5f, 0.5f, -0.5f);
            Vertices[14].TextureCoordinate.X = posTexture.X * div;
            Vertices[14].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[15].Position = new Vector3(0.5f, 0.5f, -0.5f);
            Vertices[15].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[15].TextureCoordinate.Y = (posTexture.Y + 1) * div;


            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 3));

            count = (short)(count + 4);
        }

        private void SetWest()
        {
            Vector2 posTexture = Block.GetTextureCord(BlockSide.West);

            Vertices[16].Position = new Vector3(0.5f, -0.5f, -0.5f);
            Vertices[16].TextureCoordinate.X = posTexture.X * div;
            Vertices[16].TextureCoordinate.Y = posTexture.Y * div;

            Vertices[17].Position = new Vector3(0.5f, -0.5f, 0.5f);
            Vertices[17].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[17].TextureCoordinate.Y = posTexture.Y * div;

            Vertices[18].Position = new Vector3(0.5f, 0.5f, -0.5f);
            Vertices[18].TextureCoordinate.X = posTexture.X * div;
            Vertices[18].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[19].Position = new Vector3(0.5f, 0.5f, 0.5f);
            Vertices[19].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[19].TextureCoordinate.Y = (posTexture.Y + 1) * div;


            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 3));

            count = (short)(count + 4);
        }

        private void SetEast()
        {
            Vector2 posTexture = Block.GetTextureCord(BlockSide.East);

            Vertices[20].Position = new Vector3(-0.5f, 0.5f, -0.5f);
            Vertices[20].TextureCoordinate.X = posTexture.X * div;
            Vertices[20].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[21].Position = new Vector3(-0.5f, 0.5f, 0.5f);
            Vertices[21].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[21].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Vertices[22].Position = new Vector3(-0.5f, -0.5f, 0.5f);
            Vertices[22].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[22].TextureCoordinate.Y = posTexture.Y * div;
            
            Vertices[23].Position = new Vector3(-0.5f, -0.5f, -0.5f);
            Vertices[23].TextureCoordinate.X = (posTexture.X + 1) * div;
            Vertices[23].TextureCoordinate.Y = (posTexture.Y + 1) * div;

            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 1));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 0));
            Indices.Add((short)(count + 2));
            Indices.Add((short)(count + 3));

            count = (short)(count + 4);
        }

        private void SetUpVertices()
        {
            Vertices = new VertexPositionColorTexture[4 * 6];
            Indices = new List<short>();
            if (!hasNeighbor[0])
                SetUpTop();
            if (!hasNeighbor[1])
                SetUpBotton();
            if (!hasNeighbor[2])
                SetSouth();
            if (!hasNeighbor[3])
                SetNorth();
            if (!hasNeighbor[4])
                SetWest();
            if (!hasNeighbor[5])
                SetEast();
        }

        public override void SetVerticePostion(Vector3 postion)
        {
            for (int x = 0; x < Vertices.Length; x++)
            {
                Vertices[x].Position += postion;
            }
        }
    }
}
