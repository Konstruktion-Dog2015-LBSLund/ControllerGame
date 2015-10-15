using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 
using System.Text;
using WindowsGame1;

namespace WindowsGame
{
    class Rock : GameObject
    {
        Random rnd = new Random(2);
        public Rock(Vector2 position, Texture2D texture, int seed)
            : base(position, new Vector2(50, 50), texture)
        {
            rnd = new Random(seed);
            Velocity = new Vector2(rnd.Next(-5,5),rnd.Next(-5,5));
            if (Velocity.X == 0 && Velocity.Y == 0)
                Velocity = new Vector2(3,3);
        }

        public override void Update()
        {
            base.Update();
            Position += Velocity;
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
