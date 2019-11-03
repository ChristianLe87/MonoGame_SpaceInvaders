using System;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IShelter
    {
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
