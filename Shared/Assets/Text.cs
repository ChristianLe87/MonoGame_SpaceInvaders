using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Text
    {
        string fileName;
        SpriteFont spriteFont;
        string displayText;
        Vector2 position;

        public Text(ContentManager contentManager, Vector2 position, string fileName, string displayText)
        {
            this.fileName = fileName;
            this.spriteFont = contentManager.Load<SpriteFont>(fileName);
            this.position = position;
            this.displayText = displayText;
        }

        public void Update(string displayText)
        {
            this.displayText = displayText;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, displayText, position, Color.White);
        }
    }
}
