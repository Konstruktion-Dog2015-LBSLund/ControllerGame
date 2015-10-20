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
        public bool Collides { get; protected set; }
        public Rectangle Hitbox { get { return new Rectangle((int)Position.X - (int)Size.X / 2, (int)Position.Y - (int)Size.Y / 2, (int)Size.X, (int)Size.Y); } }
        public Vector2 Position { get; protected set; }
        public Vector2 Velocity { get; protected set; }
        public Vector2 Size { get; protected set; }
        public Texture2D Texture { get; protected set; }
        public Color Color { get; protected set; }
        public Scene Scene { get; set; }
        public float Rotation { get; protected set; }
        public Vector2 RotationVector { get { return new Vector2((float)Math.Cos(Rotation), (float)Math.Sin(Rotation)); } }

        public GameObject(Vector2 position, Vector2 size, Texture2D texture)
        {
            this.Position = position;
            this.Size = size;
            this.Texture = texture;
            Color = Color.White;
        }

        public virtual void OnCollide(GameObject g)
        {
        }

        public virtual void OnDestroy() { }

        public virtual void Update()
        {
            Position += Velocity;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, null, Color, Rotation, new Vector2(Texture.Width, Texture.Height) / 2, Size / new Vector2(Texture.Width, Texture.Height), SpriteEffects.None, 0);
        }
    }
}
