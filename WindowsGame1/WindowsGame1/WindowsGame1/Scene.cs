using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
