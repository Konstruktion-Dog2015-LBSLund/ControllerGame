using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Particle : GameObject
    {
        Color c;
        int lifetime;
        int maxLife;

        public Particle(Vector2 position, int lifetime, Vector2 velocity, Color c)
        : base(position, new Vector2(1), Assets.particle) 
        {
            this.c = c;
            Collides = false;
            Velocity = velocity;
            this.lifetime = lifetime;
            this.maxLife  = lifetime;
        }

        public override void Update()
        {
            if (lifetime-- <= 0) Scene.RemoveObject(this);

            base.Update();
        }

        public override void OnDestroy()
        {
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            float a = ((float)(lifetime) / (float)maxLife);
            //Debug.WriteLine(a);
            batch.Draw(Texture, Position, c * a);
            base.Draw(batch);
        }
    }
}
