using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MyGame : Game
    {
        // Use NuGet: MonoGame.Framework.Portable

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Levels
        string actualScene;
        Dictionary<string, ILevel> levels = new Dictionary<string, ILevel>() {
            { "Level_1", new Level_1() }
        };


        public MyGame()
        {
            graphics = new GraphicsDeviceManager(this);

            // Window size
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
        }


        protected override void Initialize()
        {
            actualScene = "Level_1";

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            levels[actualScene].LoadContent(GraphicsDevice);
        }


        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            levels[actualScene].Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}