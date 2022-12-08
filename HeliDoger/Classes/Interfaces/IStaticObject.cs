using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeliDoger.Interfaces
{
    public abstract class IStaticObject : IGameObject
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

        public override void OnCollision(IGameObject gameObject)
        {
        }

        public override bool IsColliding(IGameObject gameObject, GameTime time)
        {
            var bounds = this.GetBounds(time);  //CChineseNaam
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
