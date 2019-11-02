using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : ILevel
    {
        Player player;

        public Level_1()
        {
            player = new Player(new Vector2(50,50));
        }

        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            player.LoadContent(graphicsDevice);
        }

        public void Update()
        {
            player.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
        }
    }
}
