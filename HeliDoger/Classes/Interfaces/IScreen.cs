using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace HeliDoger.Interfaces
{
    public abstract class IScreen
    {
        public Camera Camera { get; private set; }

        public List<IGameObject> GameObjects { get; protected set; }
        protected ContentManager _content;

        public IScreen(ContentManager content)
        {
            this.Camera = new Camera();

            this._content = content;
            this.GameObjects = new List<IGameObject>();

            initobj();
        }

        public abstract void initobj();

        public virtual void Update(GameTime time, MouseState mouse)
        {
            foreach (var i in GameObjects)
            {
                i.Update(time, mouse);
            }

            foreach (var go1 in this.GameObjects)
            {
               

                foreach (var go2 in GameObjects)
                {
                    if (go1 == go2) continue;
                    var collided = go1.IsColliding(go2, time);
                    if (collided)
                    {
                        go1.OnCollision(go2);
                        go2.OnCollision(go1);
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
            foreach (var go in GameObjects.OrderBy(x => x.DrawOrder))
            {
                go.Draw(spriteBatch);
            }
        }


    }
}