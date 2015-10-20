using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WindowsGame;

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
            Collides = true;
            Velocity = RotationVector * SPEED;
        }

        public override void OnCollide(GameObject g)
        {
            if (g is Rock)
            {
                Debug.WriteLine("Collision");
                Scene.RemoveObject(this);
            }
        }

        public override void Update()
        {
            if (Position.Length() > 1000) Scene.RemoveObject(this);

            base.Update();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            batch.Draw(Assets.shield, Hitbox, Color.Yellow);
            base.Draw(batch);
        }
    }
}
