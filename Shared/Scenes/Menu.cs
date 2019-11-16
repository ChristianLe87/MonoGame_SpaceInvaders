using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Menu : ILevel
    {
        Button button;
        Text score;
        public Menu(ContentManager contentManager)
        {
            button = new Button(contentManager, new Rectangle(100, 100, 100, 100), "Play !");
            score = new Text(contentManager, new Vector2(0, 0), WK.File.Font, $"High score: {Tools.GetHighScore()}");
        }

        public void Update()
        {
            button.Update();
            score.Update($"High score: {Tools.GetHighScore()}");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            button.Draw(spriteBatch);
            score.Draw(spriteBatch);
        }
    }
}