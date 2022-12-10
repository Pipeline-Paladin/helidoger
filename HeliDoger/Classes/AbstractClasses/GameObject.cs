using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace HeliDoger.abstractclasses
{
    public abstract class GameObject
    {
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Vector2 Size { get; set; } = Vector2.One;

        public int DrawOrder { get; protected set; } = 0;

        private Vector2 _movement = Vector2.Zero;

        protected void Move(float x, float y)
        {
            this.Move(new Vector2(x, y));
        }

        protected void Move(Vector2 mov)
        {
            this._movement += mov;
        }

        public abstract void Update(GameTime gameTime, MouseState mouse);

        public void LateUpdate(GameTime gameTime)
        {
            this.Position += this._movement * Convert.ToSingle(gameTime.ElapsedGameTime.TotalSeconds);
            this._movement = Vector2.Zero;
        }

        public abstract void Draw(SpriteBatch spritebatch);

        public virtual Rectangle GetBounds()
        {
            var pos = this.Position;

            return new Rectangle(pos.ToPoint(), this.Size.ToPoint());
        }

        public virtual Rectangle GetBounds(GameTime time)
        {
            var bounds = this.GetBounds();
            bounds.Offset(this._movement * Convert.ToSingle(time.ElapsedGameTime.TotalSeconds));

            return bounds;
        }

        public virtual void OnCollision(GameObject gameObject)
        {
            this._movement = Vector2.Zero;
        }

        public virtual bool IsColliding(GameObject gameObject, GameTime time)
        {
            var bounds = this.GetBounds(time);  //CChineseNaam
            return !Rectangle.Intersect(bounds, gameObject.GetBounds(time)).IsEmpty;
        }
    }
}
