using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame;
using System.Diagnostics;

namespace WindowsGame1
{
    // this is a base scene class. Game logic should not happen here, but in a more specific child class

    internal abstract class Scene
    {
        private List<GameObject> toAdd, toRemove;
        public List<GameObject> Objects { get; private set; }

        public Scene()
        {
            toAdd = new List<GameObject>();
            toRemove = new List<GameObject>();
            Objects = new List<GameObject>();
        }

        public virtual void Update()
        {
            Debug.WriteLine(toAdd.Count + " objects in add lits");
            foreach (GameObject g in toAdd)
            {
                Objects.Add(g);
                Debug.WriteLine("object added");
                g.Scene = this;
            }
            toAdd.Clear();
            foreach (GameObject g in toRemove)
            {
                Objects.Remove(g);
                g.OnDestroy();
            }
            toRemove.Clear();

            foreach (GameObject g in Objects) g.Update();

            for (int i = 0; i < Objects.Count - 1; i++)
            {
                if (!Objects[i].Collides) continue;

                for (int j = i + 1; j < Objects.Count; j++) // objects only check for collision with objects in front in the list, so nothing is checked twice
                {
                    if (!Objects[j].Collides) continue;

                    if (Objects[i].Hitbox.Intersects(Objects[j].Hitbox))
                    {
                        Objects[i].OnCollide(Objects[j]);
                        Objects[j].OnCollide(Objects[i]);
                    }
                }
            }
        }

        public virtual void OnPause() { }
        public virtual void OnResume() { }

        public void AddObject(GameObject g)
        {
            toAdd.Add(g);
            Debug.WriteLine("object added to add list," + toAdd.Count + " total");
        }

        public void RemoveObject(GameObject g)
        {
            toRemove.Add(g);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            foreach (GameObject g in Objects) g.Draw(batch);
        }
    }
}
