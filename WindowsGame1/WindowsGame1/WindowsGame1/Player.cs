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
            forward = Keys.A,
            backward = Keys.S,
            left = Keys.D, 
            right = Keys.D3;

        private float rotation;

        public Player(Vector2 position, Texture2D texture)
            : base(position, new Vector2(100, 100), texture) 
        {
            Debug.WriteLine(Position + ", " + Size);
        }

        public override void Update()
        {
            Velocity *= FRICTION;
            KeyboardState ks = Game1.CurrentKs;
            if (ks.IsKeyDown(forward))
            {
                Velocity += new Vector2((float)Math.Cos(rotation) * ACCELERATION, (float)Math.Sin(rotation) * ACCELERATION);
            }
            if (ks.IsKeyDown(backward))
            {
                Velocity -= new Vector2((float)Math.Cos(rotation) * DECELERATION, (float)Math.Sin(rotation) * DECELERATION);
            }
            if (ks.IsKeyDown(left)) rotation -= ROTATION;
            if (ks.IsKeyDown(right)) rotation += ROTATION;

            if (Position.X < 0)
                Position = new Vector2(Game1.screenWidth, Position.Y);
            if (Position.X > Game1.screenWidth)
                Position = new Vector2(0, Position.Y);
            if (Position.Y < 0)
                Position = new Vector2(Position.X, Game1.screenHeight);
            if (Position.Y + Velocity.Y > Game1.screenHeight)
                Position = new Vector2(Position.X, 0);
            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, null, Color, rotation, new Vector2(Texture.Width, Texture.Height) / 2, Size / new Vector2(Texture.Width, Texture.Height), SpriteEffects.None, 0);
        }
    }
}
