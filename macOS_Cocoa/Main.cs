using System;
using AppKit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharedMultiplataforma;

namespace macOS_Cocoa
{
    static class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();

            using (var game = new MyGame())
            {
                game.Run();
            }
        }
    }
}
