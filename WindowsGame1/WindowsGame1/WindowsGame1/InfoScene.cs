using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class InfoScene : Scene
    {
        Menu menu;
        Scene prevScene;

        public InfoScene(Scene prevScene)
            : base()
        {
            List<Button> buttons = new List<Button>();

            buttons.Add(new Button("main menu", ToMenu));
            buttons.Add(new Button("quit", Exit));

            menu = new Menu("Info", buttons);

            this.prevScene = prevScene;
        }

        public override void Update()
        {
            menu.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(Assets.font, "Shoot: White button\nShield: Red button\nPick up powerup: Yellow button\nUse the joystick to move.\n\nShoot the asteroids to score points.\nYou lose when your health runs out.",
                new Vector2(200, 100), Color.White);
            menu.Draw(batch);
        }

        private void Play()
        {
            Game1.Scene = prevScene;
        }

        private void ToMenu()
        {
            Game1.Scene = new MenuScene();
        }

        private void Exit()
        {
            Game1.Exit();
        }
    }
}
