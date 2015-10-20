using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Player : GameObject
    {
        private const float ACCELERATION = .3f, DECELERATION = .3f, ROTATION = .1f, FRICTION = .99f;
        private Keys
            forward = Keys.W,
            backward = Keys.S,
            left = Keys.A,
            right = Keys.D,
            shoot = Keys.J;

        public Player(Vector2 position, Texture2D texture)
            : base(position, new Vector2(100, 100), texture) 
        {
            Debug.WriteLine(Position + ", " + Size);
        }

        public override void Update()
        {
            Velocity *= FRICTION;
            KeyboardState ks = Game1.CurrentKs;
            KeyboardState oks = Game1.OldKs;
            if (ks.IsKeyDown(forward))
            {
                Velocity += RotationVector * ACCELERATION;
            }
            if (ks.IsKeyDown(backward))
            {
                Velocity -= RotationVector * DECELERATION;
            }
            if (ks.IsKeyDown(left)) Rotation -= ROTATION;
            if (ks.IsKeyDown(right)) Rotation += ROTATION;

            if (Position.X < 0)
                Position = new Vector2(Game1.screenWidth, Position.Y);
            if (Position.X > Game1.screenWidth)
                Position = new Vector2(0, Position.Y);
            if (Position.Y < 0)
                Position = new Vector2(Position.X, Game1.screenHeight);
            if (Position.Y + Velocity.Y > Game1.screenHeight)
                Position = new Vector2(Position.X, 0);

            if (ks.IsKeyDown(shoot) && oks.IsKeyUp(shoot)) Shoot();
            base.Update();
        }

        private void Shoot()
        {
            Scene.AddObject(new Bullet(Position, Rotation, this));
        }
    }
}
