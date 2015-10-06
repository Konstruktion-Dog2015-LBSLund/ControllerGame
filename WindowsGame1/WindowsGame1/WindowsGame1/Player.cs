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
        private const float 
            ACCELERATION = 0.40f, 
            DECELERATION = 0.30f, 
            ROTATION     = 0.10f, 
            FRICTION     = 0.98f;
        private Keys 
            forward  = Keys.W,
            backward = Keys.S,
            left     = Keys.A, 
            right    = Keys.D,
            shoot    = Keys.K,
            shield   = Keys.L;

        private bool isShieldActivated;

        public Player(Vector2 position)
            : base(position, new Vector2(50, 50), Assets.ship) 
        {
            SetOriginCenter();
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

            if (ks.IsKeyDown(shield) && oks.IsKeyUp(shield)) isShieldActivated = !isShieldActivated;

            if (ks.IsKeyDown(shoot) && oks.IsKeyUp(shoot)) Scene.AddObject(new Bullet(Position, Rotation, this));

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            if (isShieldActivated) batch.Draw(Assets.shield, Position, null, Color, Rotation, new Vector2(Assets.shield.Width, Assets.shield.Height) / 2, Size / new Vector2(Texture.Width, Texture.Height), SpriteEffects.None, 0);
        }
    }
}
