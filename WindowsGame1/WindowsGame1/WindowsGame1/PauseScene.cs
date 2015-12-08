using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class PauseScene : Scene
    {
        Menu menu;
        Scene prevScene;

        public PauseScene(Scene prevScene)
            : base()
        {
            List<Button> buttons = new List<Button>();

            buttons.Add(new Button("resume", Play));
            buttons.Add(new Button("main menu", ToMenu));
            buttons.Add(new Button("quit", Exit));

            menu = new Menu("Paused", buttons);

            this.prevScene = prevScene;
        }

        public override void Update()
        {
            menu.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
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
