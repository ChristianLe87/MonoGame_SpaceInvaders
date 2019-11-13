﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface ILevel
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}