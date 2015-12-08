using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class MenuScene : Scene
    {
        Menu menu;

        public MenuScene()
        : base()
        {
            List<Button> buttons = new List<Button>();

            buttons.Add(new Button("play", Play));
            buttons.Add(new Button("how to play", HowTo));
            buttons.Add(new Button("quit", Exit));

            menu = new Menu("Main Menu", buttons);
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
            Game1.Scene = new GameScene();
        }

        private void HowTo()
        {
            Game1.Scene = new InfoScene(Game1.Scene);
        }

        private void Exit()
        {
            Game1.Exit();
        }
    }
}
