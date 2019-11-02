using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class MyGame : Game
    {
        // Use NuGet: MonoGame.Framework.Portable

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ImageOne;

        public MyGame()
        {
            graphics = new GraphicsDeviceManager(this);

            // Window size
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 500;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ImageOne = Tools.CreateColorTexture(GraphicsDevice, Color.LightGreen);
        }


        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(ImageOne, new Vector2(50, 50), new Rectangle(0,0, 100, 100), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}