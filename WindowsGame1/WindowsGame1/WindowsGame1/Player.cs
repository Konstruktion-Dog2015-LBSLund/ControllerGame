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
        public override Rectangle Hitbox { get { if (shieldIsUp) return new Rectangle((int)Position.X - (int)Size.X + 20, (int)Position.Y - (int)Size.Y + 20, Assets.shield.Width, Assets.shield.Height); else return base.Hitbox; } }
        public static bool shieldIsUp;
        sbyte shieldTimer;
        private Keys
            forward  = Keys.E,
            backward = Keys.C,
            left     = Keys.D3,
            right    = Keys.D,
            shoot    = Keys.A,
            powerup  = Keys.Q,
            shield   = Keys.Z;

        public Player(Vector2 position, Texture2D texture)
            : base(position, new Vector2(100, 100), texture)
        {
            Debug.WriteLine(Position + ", " + Size);
            Collides = true;
        }

        public override void Update()
        {
            Velocity *= FRICTION;
            KeyboardState ks = Game1.CurrentKs;
            KeyboardState oks = Game1.OldKs;
            if (ks.IsKeyDown(forward))
            {
                Velocity += RotationVector * ACCELERATION;
                int p = 5;
                float a = .3f;
                float da = a / 5;
                for (int i = 0; i < p; i++)
                {
                    float ca = da * i + Rotation - a / 2 + (float)Math.PI;
                    Scene.AddObject(new Particle(Position - RotationVector * 30, 20, new Vector2((float)Math.Cos(ca), (float)Math.Sin(ca)) * 10, Color.Yellow));
                }
            }

            if (ks.IsKeyDown(shield))
            {
                shieldIsUp = true;
                shieldTimer = 100;
            }
            if (shieldIsUp)
            {
                shieldTimer--;
                if (shieldTimer == 0)
                    shieldIsUp = false;
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
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            if (shieldIsUp)
                batch.Draw(Assets.shield, Hitbox, Color.White);
        }
        private void Shoot()
        {
            Scene.AddObject(new Bullet(Position, Rotation, this));
        }
    }
}
