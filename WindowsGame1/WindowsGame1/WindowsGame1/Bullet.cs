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

            Velocity = RotationVector * SPEED;
        }

        public override void OnCollide(GameObject g)
        {
            if (g != parent)
            {
                Scene.RemoveObject(this);
            }
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
