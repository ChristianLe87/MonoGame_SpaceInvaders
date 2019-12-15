using Microsoft.Xna.Framework.Graphics;

namespace SharedMultiplataforma
{
    public interface ILevel
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}