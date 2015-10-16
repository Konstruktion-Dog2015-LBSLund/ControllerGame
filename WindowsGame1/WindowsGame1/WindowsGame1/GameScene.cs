using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame;

namespace WindowsGame1
{
    class GameScene : Scene
    {
        private const int ROCK_DELAY = 60;
        private int rockCounter;

        private Random rnd = new Random();

        public GameScene()
        {
            AddObject(new Player(new Vector2(100, 100), Game1.PlayerTexture));
        }

        public override void Update()
        {
            if (rockCounter++ >= ROCK_DELAY)
            {
                rockCounter = 0;
                AddObject(new Rock(rnd));
            }
            base.Update();
        }
    }
}
