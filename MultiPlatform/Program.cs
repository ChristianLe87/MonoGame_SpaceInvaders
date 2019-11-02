using System;
using Shared;

namespace MultiPlatform
{
    class MainClass
    {
        // Use NuGet: MonoGame.Framework.DesktopGL

        public static void Main(string[] args)
        {
            using (var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
