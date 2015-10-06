using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Asteroid : GameObject
    {
        public Asteroid(Random r)
        : this ((float)(r.NextDouble() * 2 * Math.PI)) 
        {
        }

        private Asteroid(Asteroid a)
        : base(a.Position + a.Size, a.Size, a.Texture)
        {
            Velocity = a.Velocity; // plus some random
        }

        private Asteroid(float angle)
        : base(new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * 1000, new Vector2(100, 100), Assets.asteroid) 
        {
            Rotation = angle;
            Velocity = -RotationVector * 2;
            SetOriginCenter();
        }

        public override void OnCollide(GameObject g)
        {
            if (g is Bullet)
            {
                Split();
            }
        }

        private void Split()
        {
            this.Size /= 2;

            Scene.AddObject(new Asteroid(this));
        }
    }
}
