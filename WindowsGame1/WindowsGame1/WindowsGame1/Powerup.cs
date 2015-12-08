using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Powerup : GameObject
    {
        public Powerup(Vector2 position)
        : base(position, new Vector2(30, 30), Assets.powerup)
        {
            Collides = true;
        }
    }
}
