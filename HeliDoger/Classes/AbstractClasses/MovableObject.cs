using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeliDoger.abstractclasses
{
    public abstract class MovableObject : GameObject
    {

        private Vector2 _movement = Vector2.Zero;

        public override void Update(GameTime gameTime, MouseState mouse)
        {
        }

        public override void Draw(SpriteBatch spritebatch)
        {
        }

        public new void LateUpdate(GameTime gameTime)
        {
            this.Position += this._movement * Convert.ToSingle(gameTime.ElapsedGameTime.TotalSeconds);
            this._movement = Vector2.Zero;
        }

        public override Rectangle GetBounds()
        {
            var pos = this.Position;
            return new Rectangle(pos.ToPoint(), this.Size.ToPoint());
        }

        public override Rectangle GetBounds(GameTime time)
        {
            var bounds = this.GetBounds();
            bounds.Offset(this._movement * Convert.ToSingle(time.ElapsedGameTime.TotalSeconds));

            return bounds;
        }

        public override void OnCollision(GameObject gameObject)
        {
            this._movement = Vector2.Zero;
        }

        public override bool IsColliding(GameObject gameObject, GameTime time)
        {
            var bounds = this.GetBounds(time);   
            return !Rectangle.Intersect(bounds, gameObject.GetBounds(time)).IsEmpty;
        }
    }
}
