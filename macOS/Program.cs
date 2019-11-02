using System;
using Shared;

namespace macOS
{
    class MainClass
    {
        // Use NuGet: MonoGame.Framework.MacOS

        public static void Main(string[] args)
        {
            using (var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
