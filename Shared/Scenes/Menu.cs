using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Menu : ILevel
    {
        Button playButton;
        Text score;
        public Menu(ContentManager contentManager)
        {
            playButton = new Button(contentManager, new Rectangle(MyGame.canvasWidth/2, MyGame.canvasHeight/2, 100, 100), "Play !");
            score = new Text(contentManager, new Vector2(0, 0), WK.File.Font, $"High score: {Tools.GetHighScore()}");
        }

        public void Update()
        {
            playButton.Update();
            score.Update($"High score: {Tools.GetHighScore()}");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            playButton.Draw(spriteBatch);
            score.Draw(spriteBatch);
        }
    }
}