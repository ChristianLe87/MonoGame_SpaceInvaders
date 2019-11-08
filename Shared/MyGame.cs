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
        Dictionary<string, Level_1> levels = new Dictionary<string, Level_1>() {
            { "Level_1", new Level_1() }
        };

        public static GraphicsDevice graphicsDevice;


        public MyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "/Users/christianlehnhoff/Repositorios/GitHub/MonoGame_SpaceInvaders/Content/";

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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MyGame.graphicsDevice = GraphicsDevice;

            levels[actualScene].LoadContent(Content);
        }


        protected override void Update(GameTime gameTime)
        {
            levels[actualScene].Update();
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