using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class Menu
    {
        const Keys UP = Keys.E, DOWN = Keys.C, SELECT = Keys.A;

        private List<Button> buttons;

        int selected;

        public Menu(List<Button> buttons)
        {
            this.buttons = buttons;

            int i = 0;
            foreach (Button b in buttons)
            {
                b.position = new Microsoft.Xna.Framework.Vector2(100, 300 + i++ * 50);
            }
        }

        public void Update()
        {
            if (Game1.CurrentKs.IsKeyDown(UP) && Game1.OldKs.IsKeyUp(UP)) selected--;
            if (Game1.CurrentKs.IsKeyDown(DOWN) && Game1.OldKs.IsKeyUp(DOWN)) selected++;

            if (selected < 0) selected = buttons.Count - 1; 
            if (selected >= buttons.Count) selected = 0;

            if (Game1.CurrentKs.IsKeyDown(SELECT) && Game1.OldKs.IsKeyUp(SELECT)) buttons[selected].Click();
        }

        public void Draw(SpriteBatch batch)
        {
            int i = 0;
            foreach (Button b in buttons) b.Draw(batch, selected == i++);
        }
    }
}
