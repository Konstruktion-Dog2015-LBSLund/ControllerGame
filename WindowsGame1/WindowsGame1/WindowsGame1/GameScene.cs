using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class GameScene : Scene
    {
        Random rnd = new Random();
        public GameScene()
        {
            AddObject(new Player(new Vector2(100, 100), Game1.PlayerTexture));
        }
    }
}
