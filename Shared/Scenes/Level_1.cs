using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shared
{
    public class Level_1 : ILevel
    {

        // --- Score ---
        Text scoreLabel;
        public static int score;


        // --- PlayerHealth ---
        Text playerHealthLabel;

        // --- GameOver ---
        Text gameOver;
        FadeOut fadeOut;
        Text youWin;
        public static GameMode_Enum gameMode;

        // --- Player ---
        Player player;


        // --- Aliens ---
        public static List<Alien_1> aliens;// = new List<Alien_1>();
        char[,] aliensMap = {
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' },
            {'x','x','x','x','x','x','x','x','x','x','x','x','x','x','x' }
        };


        // --- Shelters ---
        public static List<Shelter> shelters = new List<Shelter>();
        char[,] sheltersMap =
        {
            {' ','x',' ','x',' ','x',' ','x',' ','x',' ' }
        };


        // --- PlayerBullets ---
        public static List<PlayerBullet> playerBullets = new List<PlayerBullet>();


        // --- AlienBullets ---
        public static List<AlienBullets> alienBullets = new List<AlienBullets>();


        public Level_1(ContentManager contentManager)
        {
            gameMode = GameMode_Enum.Playing;
            player = new Player(new Rectangle(250, 400, 25, 25));

            SetUpAliensPosition();
            SetUpSheltersMap();

            scoreLabel = new Text(contentManager, new Vector2(10, 10), "MyFont", $"Score {score}");
            playerHealthLabel = new Text(contentManager, new Vector2(350, 10), "MyFont", $"Health {player.health}");
            gameOver = new Text(contentManager, new Vector2(200, 200), "MyFont", "Game Over");
            youWin = new Text(contentManager, new Vector2(200, 200), "MyFont", "You Win");

            fadeOut = new FadeOut(500, 500);
        }

        public void Reset()
        {
            player = new Player(new Rectangle(250, 400, 25, 25));

            SetUpAliensPosition();
            SetUpSheltersMap();
            score = 0;
            //scoreLabel = new Text(contentManager, new Vector2(10, 10), "MyFont", $"Score {score}");
            //playerHealthLabel = new Text(contentManager, new Vector2(350, 10), "MyFont", $"Health {player.health}");
            //gameOver = new Text(contentManager, new Vector2(200, 200), "MyFont", "Game Over");

            fadeOut = new FadeOut(500, 500);
            gameMode = GameMode_Enum.Playing;
        }

        public void Update()
        {
            // Update Assets
            if (gameMode == GameMode_Enum.Playing)
            {
                player.Update();
                foreach (var playerBullet in playerBullets) playerBullet.Update();
                foreach (var alienBullet in alienBullets) alienBullet.Update();
                foreach (var alien in aliens) alien.Update();
                foreach (var shelter in shelters) shelter.Update();
                scoreLabel.Update($"Score {score}");
                playerHealthLabel.Update($"Health {player.health}");

                // Clean lists
                playerBullets = playerBullets.Where(x => x.isActive == true).ToList();
                alienBullets = alienBullets.Where(x => x.isActive == true).ToList();
                aliens = aliens.Where(x => x.isActive == true).ToList();
                shelters = shelters.Where(x => x.isActive == true).ToList();

                if(aliens.Count == 0)
                {
                    gameMode = GameMode_Enum.YouWin;
                }
            }
            else
            {
                fadeOut.Update(0.003f);
            }


            if (fadeOut.alpha > 1f)
            {
                Tools.SaveHighScore(score);
                this.fadeOut.Reset();
                Reset();
                MyGame.actualScene = "Menu";
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            foreach (var alien in aliens) alien.Draw(spriteBatch);
            foreach (var alienBullet in alienBullets) alienBullet.Draw(spriteBatch);
            foreach (var playerBullet in playerBullets) playerBullet.Draw(spriteBatch);
            foreach (var shelter in shelters) shelter.Draw(spriteBatch);


            // When game over
            if (gameMode == GameMode_Enum.GameOver)
            {
                fadeOut.Draw(spriteBatch);
                gameOver.Draw(spriteBatch);
            }
            else if (gameMode == GameMode_Enum.YouWin)
            {
                fadeOut.Draw(spriteBatch);
                youWin.Draw(spriteBatch);
            }

            // UI
            scoreLabel.Draw(spriteBatch);
            playerHealthLabel.Draw(spriteBatch);
        }

        internal void SetUpAliensPosition()
        {
            aliens = new List<Alien_1>();
            for (int row = 0; row < aliensMap.GetLength(0); row++)
            {
                for (int element = 0; element < aliensMap.GetLength(1); element++)
                {
                    if (aliensMap[row, element] == 'x')
                    {
                        aliens.Add(new Alien_1(new Rectangle(element * 25, row * 25, 20, 20), new Point(element, row)));
                    }
                }
            }
        }

        internal void SetUpSheltersMap()
        {
            for (int row = 0; row < sheltersMap.GetLength(0); row++)
            {
                for (int element = 0; element < sheltersMap.GetLength(1); element++)
                {
                    if (sheltersMap[row, element] == 'x')
                    {
                        shelters.Add(new Shelter(new Rectangle(element * 45, 300, 40, 20)));
                    }
                }
            }
        }

        public enum GameMode_Enum
        {
            GameOver = 0,
            YouWin = 1,
            Playing = 2
        }
    }
}
