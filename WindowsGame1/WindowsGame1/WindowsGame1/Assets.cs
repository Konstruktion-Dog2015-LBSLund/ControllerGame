using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Assets
    {
        private static ContentManager Content;

        public static Texture2D
            ship,
            shield,
            shot,
            asteroid;

        public static void Load(ContentManager content)
        {
            Content = content;

            ship = Texture("player");
            shield = Texture("shield");
            shot = Texture("shot");
            asteroid = Texture("asteroid");
        }

        private static Texture2D Texture(string name)
        {
            return Content.Load<Texture2D>(name);
        }
    }
}
