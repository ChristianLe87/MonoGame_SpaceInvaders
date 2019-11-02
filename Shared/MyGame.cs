using System.Collections.Generic;
using System.Linq;
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

        public static List<PlayerBullet> playerBullets = new List<PlayerBullet>();

        public static GraphicsDevice graphicsDevice;


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
            MyGame.graphicsDevice = GraphicsDevice;

            levels[actualScene].LoadContent(graphicsDevice);
        }


        protected override void Update(GameTime gameTime)
        {
            levels[actualScene].Update();

            foreach (var playerBullet in playerBullets) playerBullet.Update();

            // Clean array (just active bullets)
            playerBullets = playerBullets.Where(x => x.isActive == true).ToList();

            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            levels[actualScene].Draw(spriteBatch);

            foreach (var playerBullet in playerBullets) playerBullet.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}