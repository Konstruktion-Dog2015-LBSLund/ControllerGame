using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class GameScene : Scene
    {
        public GameScene()
        {
            AddObject(new Player(new Vector2(100, 100), Assets.ship));
        }
    }
}
