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
        int health;
        int Health { get { return health; } set { health = value; if (health <= 0) Scene.RemoveObject(this); } }

        public Rock(Random rnd)
            : base(Vector2.Zero, new Vector2(50, 50), Game1.RockTexture)
        {
            Collides = true;
            float a = (float)(rnd.NextDouble() * 2 * Math.PI);
            Position = new Vector2((float)Math.Cos(a), (float)Math.Sin(a)) * 1000 + new Vector2(Game1.screenWidth, Game1.screenHeight) / 2;
            a += (float)Math.PI;
            a += (float)(rnd.NextDouble() - .5) * .5f;
            Velocity = new Vector2((float)Math.Cos(a), (float)Math.Sin(a)) * rnd.Next(1, 3);
            Health = 1;
        }

        public override void OnCollide(GameObject g)
        {
            if (g is Bullet) Health--;

            if (Player.shieldIsUp && g is Player)
                Scene.RemoveObject(this);
        }

        public override void OnDestroy()
        {
            int p = 30;
            float da = 2 * (float)Math.PI / p;
            for (int i = 0; i < p; i++)
            {
                Scene.AddObject(new Particle(Position, 60, new Vector2((float)Math.Cos(da * i), (float)Math.Sin(da * i)) * 5, Color.Brown));
            }
        }
        public override void Update()
        {
            if (Position.Length() > 2000) Scene.RemoveObject(this);

            base.Update();
        }
        
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Assets.shield, Hitbox, Color.Yellow);
            base.Draw(batch);
        }
    }
}
