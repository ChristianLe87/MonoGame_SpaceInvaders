﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public interface IAlien
    {
        Rectangle alienRectangle { get; }
        bool isActive { get; }

        Texture2D alienImage { get; set; }
        //Vector2 position { get; set; }

        void LoadContent();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
