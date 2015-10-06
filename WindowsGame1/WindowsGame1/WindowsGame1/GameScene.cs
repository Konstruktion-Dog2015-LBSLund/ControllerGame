using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class GameScene : Scene
    {
        Random r;

        int asteroidTimer;
        int asteroidTime = 100;

        public GameScene()
        {
            AddObject(new Player(new Vector2(100, 100)));
            r = new Random();
        }

        public override void Update()
        {
            base.Update();

            if (asteroidTimer++ > asteroidTime)
            {
                asteroidTimer = 0;
                AddObject(new Asteroid(r));
            }
        }
    }
}
