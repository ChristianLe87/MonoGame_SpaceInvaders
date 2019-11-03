using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : ILevel
    {
        List<IAlien> aliens = new List<IAlien>();

        char[,] aliensPosition = {
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' }
        };

        IShelter shelter;

        Player player;


        public static List<PlayerBullet> playerBullets = new List<PlayerBullet>();

        public Level_1()
        {
            player = new Player(new Vector2(250, 400), 25, 25);
        }

        public void LoadContent(GraphicsDevice graphicsDevice)
        {
            player.LoadContent();

            // Insert aliens
            for (int row = 0; row < aliensPosition.GetLength(0); row++)
            {
                for (int element = 0; element < aliensPosition.GetLength(1); element++)
                {
                    if (aliensPosition[row, element] == 'x')
                    {
                        aliens.Add(new Alien_1(new Vector2(element*25, row*25), 20, 20));
                    }
                }
            }

            shelter = new Shelter(new Rectangle(225,330, 40,20));
        }

        public void Update()
        {
            player.Update();

            foreach (var alien in aliens) alien.Update(8);

            foreach (var playerBullet in playerBullets) playerBullet.Update();

            // Clean array (just active bullets)
            playerBullets = playerBullets.Where(x => x.isActive == true).ToList();

            shelter.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (var alien in aliens) alien.Draw(spriteBatch);
            foreach (var playerBullet in playerBullets) playerBullet.Draw(spriteBatch);
            shelter.Draw(spriteBatch);

        }
    }
}
