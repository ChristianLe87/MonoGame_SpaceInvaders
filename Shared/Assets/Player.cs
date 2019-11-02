using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Player
    {
        Texture2D ImageOne;
        Vector2 position;

        public Player(Vector2 position)
        {
            this.position = position;
        }

        internal void LoadContent(GraphicsDevice graphicsDevice)
        {
            ImageOne = Tools.CreateColorTexture(graphicsDevice, Color.LightGreen);
        }

        internal void Update()
        {
            //throw new NotImplementedException();
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageOne, position, new Rectangle(0, 0, 100, 100), Color.White);
        }


    }
}
