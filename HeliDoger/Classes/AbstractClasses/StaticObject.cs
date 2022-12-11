using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeliDoger.abstractclasses
{
    public abstract class StaticObject : GameObject
    {

        public override Rectangle GetBounds()
        {
            var pos = this.Position;
            return new Rectangle(pos.ToPoint(), this.Size.ToPoint());
        }

        public override Rectangle GetBounds(GameTime time)
        {
            var bounds = this.GetBounds();

            return bounds;
        }

        public override void OnCollision(GameObject gameObject)
        {
        }

        public override bool IsColliding(GameObject gameObject, GameTime time)
        {
            var bounds = this.GetBounds(time);   
            return !Rectangle.Intersect(bounds, gameObject.GetBounds(time)).IsEmpty;
        }

        public override void Update(GameTime gameTime, MouseState mouse)
        {
        }

        public override void Draw(SpriteBatch spritebatch)
        {
        }
    }
}
