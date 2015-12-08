﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WindowsGame;

namespace WindowsGame1
{
    class Player : GameObject
    {
        private const float ACCELERATION = .3f, DECELERATION = .3f, ROTATION = .01f, FRICTION = .99f, ANG_FRICTION = .9f;
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

        private int health;
        public static int score;
        private float angularVel;

        public Player(Vector2 position, Texture2D texture)
            : base(position, new Vector2(100, 100), texture)
        {
            Debug.WriteLine(Position + ", " + Size);
            Collides = true;

            health = 10;
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

            bool pausing = false;
            if (ks.IsKeyDown(shoot) && ks.IsKeyDown(powerup) && ks.IsKeyDown(shield))
            {
                pausing = true;
                Game1.Scene = new PauseScene(Scene);
            }

            if (ks.IsKeyDown(shield) && !pausing)
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

            angularVel *= ANG_FRICTION;
            if (ks.IsKeyDown(left)) angularVel -= ROTATION;
            if (ks.IsKeyDown(right)) angularVel += ROTATION;

            Rotation += angularVel;

            if (Position.X < 0)
                Position = new Vector2(Game1.screenWidth, Position.Y);
            if (Position.X > Game1.screenWidth)
                Position = new Vector2(0, Position.Y);
            if (Position.Y < 0)
                Position = new Vector2(Position.X, Game1.screenHeight);
            if (Position.Y + Velocity.Y > Game1.screenHeight)
                Position = new Vector2(Position.X, 0);

            if (ks.IsKeyDown(shoot) && oks.IsKeyUp(shoot)) Shoot();

            

            if (health <= 0)
            {
                Game1.Scene = new GameOverScene(score);
            }

            base.Update();
        }

        public override void OnCollide(GameObject g)
        {
            if (g is Rock)
            {
                Scene.RemoveObject(g);
                if (!shieldIsUp) health--;
            }

            if (g is Powerup)
            {
                Scene.RemoveObject(g);
                health++;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            if (shieldIsUp)
                batch.Draw(Assets.shield, Hitbox, Color.White);

            batch.DrawString(Assets.font, "Health: " + health + "\nScore: " + score, Vector2.Zero, Color.White);
        }
        private void Shoot()
        {
            Scene.AddObject(new Bullet(Position, Rotation, this));
        }
    }
}
