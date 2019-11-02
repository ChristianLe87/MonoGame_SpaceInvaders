using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : ILevel
    {
        Texture2D ImageOne;

        public Level_1()
        {
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageOne, new Vector2(50, 50), new Rectangle(0, 0, 100, 100), Color.White);
        }

        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            ImageOne = Tools.CreateColorTexture(graphicsDevice, Color.LightGreen);
        }

    }
}
