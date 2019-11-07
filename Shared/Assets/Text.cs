using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared.Assets
{
    public class Text
    {
        string fileName;
        SpriteFont spriteFont;
        string displayText;

        public Text(ContentManager contentManager, string fileName)
        {
            this.fileName = "";
            this.fileName = fileName;
            this.spriteFont = contentManager.Load<SpriteFont>(fileName);
        }

        public void Update(string displayText)
        {
            this.displayText = displayText;
        }

        public void Draw(SpriteBatch spriteBatch, string text)
        {
            spriteBatch.DrawString(spriteFont, displayText, new Vector2(100, 100), Color.White);
        }
    }
}
