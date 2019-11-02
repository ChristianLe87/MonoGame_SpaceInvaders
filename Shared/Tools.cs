using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public static class Tools
    {
        public static Texture2D CreateColorTexture(GraphicsDevice graphicsDevice, Color color)
        {
            Texture2D newTexture = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            newTexture.SetData<Color>(new Color[] { color });
            return newTexture;
        }
    }
}