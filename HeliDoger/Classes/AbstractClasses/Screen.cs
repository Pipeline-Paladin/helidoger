using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HeliDoger.Classes;
using System.Collections.Generic;
using HeliDoger.Classes.Objects;

namespace HeliDoger.abstractclasses
{
    public abstract class Screen
    {
        public Camera Camera { get; private set; }

        public List<GameObject> GameObjects { get; protected set; }
        protected ContentManager _content;

        public Screen(ContentManager content)
        {
            this.Camera = new Camera();

            this._content = content;
            this.GameObjects = new List<GameObject>();

            InitializeObjects();
        }

        public abstract void InitializeObjects();

        public virtual void Update(GameTime time, MouseState mouse)
        {
            foreach (var i in GameObjects)
            {
                i.Update(time, mouse);
            }

            foreach (var i in this.GameObjects)
            {
                if (i is Wall) continue;

                foreach (var j in GameObjects)
                {
                    if (i == j) continue;
                    var collided = i.IsColliding(j, time);
                    if (collided)
                    {
                        i.OnCollision(j);
                        j.OnCollision(i);
                    }
                }
            }

            foreach (var go in GameObjects)
            {
                go.LateUpdate(time);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var i in GameObjects.OrderBy(x => x.DrawOrder))
            {
                i.Draw(spriteBatch);
            }
        }


    }
}