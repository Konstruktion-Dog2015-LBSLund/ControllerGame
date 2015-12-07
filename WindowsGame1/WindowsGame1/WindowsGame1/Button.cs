using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Button
    {
        Action onClick;
        string text;

        public Vector2 position;

        public Button(string text, Action onClick)
        {
            this.text = text;
            this.onClick = onClick;
        }

        public void Click()
        {
            onClick();
        }

        public void Draw(SpriteBatch batch, bool selected)
        {
            batch.DrawString(Assets.font, text, position, (selected ? Color.CornflowerBlue : Color.White));
        }
    }
}
