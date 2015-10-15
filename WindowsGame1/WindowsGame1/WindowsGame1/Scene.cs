using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame;

namespace WindowsGame1
{
    internal class Scene
    {
        private List<GameObject> toAdd, toRemove;
        public List<GameObject> Objects { get; private set; }

        public Scene()
        {
            toAdd = new List<GameObject>();
            toRemove = new List<GameObject>();
            Objects = new List<GameObject>();
        }

        public void Update()
        {
            foreach (GameObject g in toAdd)
            {
                Objects.Add(g);
                g.Scene = this;
            }
            foreach (GameObject g in toRemove) Objects.Remove(g);
            toAdd.Clear();
            toRemove.Clear();
            foreach (GameObject g in Objects) g.Update();
            toAdd.Add(new Rock(new Vector2(Game1.rnd.Next(-200, -100), Game1.rnd.Next(-100, 700)), Game1.RockTexture, Game1.rnd.Next()));
        }

        public virtual void OnPause() { }
        public virtual void OnResume() { }

        public void AddObject(GameObject g)
        {
            toAdd.Add(g);
        }

        public void RemoveObject(GameObject g)
        {
            toRemove.Add(g);
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (GameObject g in Objects) g.Draw(batch);
        }
    }
}
