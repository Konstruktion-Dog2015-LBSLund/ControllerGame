using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Bullet : GameObject
    {
        const float SPEED = 10;

        GameObject parent;

        public Bullet(Vector2 position, float rotation, GameObject parent)
        : base(position, new Vector2(10, 10), Assets.shot)
        {
            this.parent = parent;
            Rotation = rotation;
        }

        public override void Update()
        {
            Position += new Vector2((float)Math.Cos(Rotation) * SPEED, (float)Math.Sin(Rotation) * SPEED);
            base.Update();
        }
    }
}
