using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MineClone.blocks;
using MineClone.camera;
using MineClone.Entities;
//using MineClone.camera;
using MineClone.render;
using MineClone.utils;
using System;
using System.Collections.Generic;

namespace MineClone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MineClone : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Dictionary<String, Block> blocks = new Dictionary<string, Block>();
        Dictionary<Vector3, Entity> dictionaryEntity = new Dictionary<Vector3, Entity>();

        List<BasicDraw> basicDrawList = new List<BasicDraw>();

        public static GraphicsDevice device;
        //public static Camera camera;

        public ICamera Camera { get; private set; }
        
        FrameCounter frameCounter = new FrameCounter();

        SpriteFont font;

        double lastUpdatedTime;

        bool showStats = false;

        struct Pair
        {
            public int x;
            public int z;
        }

        List<Pair> chunks;

        public MineClone()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // camera = new Camera(this, new Vector3(0, 2, 10), new Vector3(0, 0, 0), new Vector3(0, 1, 0));            
            this.Window.AllowUserResizing = true;
            FormControl.Maximize(this.Window);
            chunks = new List<Pair>();
        }
        
        protected override void Initialize()
        {
            //camera.Initialize();            
            base.Initialize();
        }
        
        protected override void LoadContent()
        {            
            font = Content.Load<SpriteFont>("Arial");
            spriteBatch = new SpriteBatch(GraphicsDevice);            
            device = GraphicsDevice;
            BlockRegister();
            CreateChunks(0, 0);
            
            Camera = new FirstPersonCamera(this);
            Camera.Load(device);


            //tringleTest = new TringleTest(this);
        }

        private void BlockRegister()
        {
            blocks.Add("stone", new StoneBlock());
            blocks.Add("dirt", new DirtBlock());
        }

        int lastCamX = 0;
        int lastCamZ = 0;
        int rendDist = 5;

        public void Update()
        {
            Vector3 cam = Camera.getCameraPosition();
            int x = (int) (cam.X / (rendDist * 10));
            int z = (int)(cam.Z / (rendDist * 10));
            bool updated = false;
            if (x != lastCamX)
            {
                lastCamX = x;
                updated = true;
            }
            if (z != lastCamZ)
            {
                lastCamZ = z;
                updated = true;
            }
            if (updated)
            {
                //basicDrawList.Clear();
                CreateChunks(x, z);
                UpdateBlocks();
            }
        }

        private void UpdateBlocks()
        {
            foreach (Vector3 vec in dictionaryEntity.Keys)
            {
                Entity e = dictionaryEntity[vec];                
                BlockRender r = (BlockRender) e.Render;                
            }
        }

        private void CreateChunks(int ax, int az)
        {
            Random r = new Random();
            for (int x = (ax - rendDist); x < (ax + rendDist); x++)
            {
                for (int z = (az - rendDist); z < (az + rendDist); z++)
                {
                    Pair chunk = new Pair();
                    chunk.x = x;
                    chunk.z = z;
                    if (!chunks.Contains(chunk))
                    {
                        int y = 10;
                        if (0 < r.Next(0, 2))
                        {
                            y = 20;
                        }
                        List<Entity> entites = CreateEntities(x, z, y);
                        BasicDraw basicDraw = new BasicDraw(this);
                        basicDraw.renderEntities(entites);
                        basicDrawList.Add(basicDraw);
                        chunks.Add(chunk);
                    }                   
                }

            }

        }

        private List<Entity> CreateEntities(int ax, int az, int ay)
        {
            ax *= 10;
            az *= 10;                        
            List<Entity> entities = new List<Entity>();
            for (int x = ax; x < (ax+10); x++)
            {
                for (int z = az; z < (az+10); z++)
                {
                    for (int y = 0; y < ay; y++)
                    {
                        Block block;
                        if (y < 8)
                        {
                            block = blocks["stone"];
                        } else
                        {
                            block = blocks["dirt"];
                        }
             
                        if (true)
                        {
                            Entity entity = block.CreateEntity();
                            entity.Position = new Vector3(x, y, z);
                            dictionaryEntity.Add(entity.Position, entity);
                            entities.Add(entity);
                        }                                                
                    }                    
                }                
            }
            return entities;


        }
        
        protected override void UnloadContent()
        {            

        }
        
        protected override void Update(GameTime gameTime)
        {   
            if (!FormControl.isFormActive(Window)) return;

            bool updated = false;

            bool allowUpdate = (lastUpdatedTime + 100) < gameTime.TotalGameTime.TotalMilliseconds;


            if (graphics.PreferredBackBufferWidth != Window.ClientBounds.Width || graphics.PreferredBackBufferHeight != Window.ClientBounds.Height)
            {
                graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
                graphics.ApplyChanges();                                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F3) && allowUpdate)
            {
                showStats = !showStats;
                updated = true;
            }
                
            
            if (updated)
            {
                updated = false;
                lastUpdatedTime = gameTime.TotalGameTime.TotalMilliseconds;
            }
                

            float timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            Camera.ProcessInput(timeDifference);
            
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;            
            foreach (BasicDraw basicDraw in basicDrawList)
            {
                basicDraw.Draw(gameTime);
            }
            

            if (showStats)
            {                
                var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                frameCounter.Update(deltaTime);
                var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);
                var pos = string.Format("Player position: {0}", Camera.getCameraPosition());



                spriteBatch.Begin();
                spriteBatch.DrawString(font, fps, new Vector2(1, 1), Color.Black);
                spriteBatch.DrawString(font, pos, new Vector2(1, 20), Color.Black);
                spriteBatch.End();
            }
            

            base.Draw(gameTime);
        }

        public void RegistryBlock(String blockName, Block block)
        {
            blocks.Add(blockName, block);
        }

        public bool DetectCollision(Vector3 playerPosition)
        {            
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        if (dictionaryEntity.ContainsKey(new Vector3(((int)playerPosition.X) + x, ((int)playerPosition.Y) + y, ((int)playerPosition.Z) + z)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


    }
}
