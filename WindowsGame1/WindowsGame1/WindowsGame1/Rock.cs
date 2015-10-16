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
        public Rock(Random rnd)
            : base(Vector2.Zero, new Vector2(50, 50), Game1.RockTexture)
        {
            float a = (float)(rnd.NextDouble() * 2 * Math.PI);
            Position = new Vector2((float)Math.Cos(a), (float)Math.Sin(a)) * 1000 + new Vector2(Game1.screenWidth, Game1.screenHeight) / 2;
            a += (float)Math.PI;
            a += (float)(rnd.NextDouble() - .5) * .5f;
            Velocity = new Vector2((float)Math.Cos(a), (float)Math.Sin(a)) * rnd.Next(1, 3);
        }

        public override void Update()
        {
            if (Position.Length() > 2000) Scene.RemoveObject(this);

            base.Update();
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
