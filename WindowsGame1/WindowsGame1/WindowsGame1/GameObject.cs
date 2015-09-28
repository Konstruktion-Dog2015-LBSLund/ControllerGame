using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    abstract class GameObject
    {
        public Rectangle Hitbox { get { return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y); } }
        public Vector2 Position { get; protected set; }
        public Vector2 Velocity { get; protected set; }
        public Vector2 Size { get; protected set; }
        public Texture2D Texture { get; protected set; }
        public Color Color { get; protected set; }
        public Scene Scene { get; set; }

        public GameObject(Vector2 position, Vector2 size, Texture2D texture)
        {
            this.Position = position;
            this.Size = size;
            this.Texture = texture;
            Color = Color.White;
        }

        public virtual void Update()
        {
            Position += Velocity;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Hitbox, Color);
        }
    }
}
