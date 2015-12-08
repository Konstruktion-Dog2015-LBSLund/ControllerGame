using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    class GameOverScene : Scene
    {
        Menu menu;
        int score;

        public GameOverScene(int score)
            : base()
        {
            List<Button> buttons = new List<Button>();

            buttons.Add(new Button("play again", Play));
            buttons.Add(new Button("quit", Exit));

            menu = new Menu(buttons);

            this.score = score;
        }

        public override void Update()
        {
            menu.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.DrawString(Assets.font, "score: " + score, new Vector2(100, 50), Color.White);
            menu.Draw(batch);
        }

        private void Play()
        {
            Game1.Scene = new GameScene();
        }

        private void Exit()
        {
            Game1.Exit();
        }
    }
}
