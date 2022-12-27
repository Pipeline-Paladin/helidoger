using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes
{
    public class Wall : StaticObject
    {
        private Texture2D _texture;

        public Wall(Texture2D texture, Vector2 position)
        {
            this._texture = texture;
            this.Position = position;
            this.Size = this._texture.Bounds.Size.ToVector2() * 1.5f;
            this.DrawOrder = 1;
        }

        public override Rectangle GetBounds()
        {
            var bounds = base.GetBounds();
            return bounds;
        }

        public override void Update(GameTime gameTime, MouseState mouse) { }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this._texture, this.Position,new Rectangle(0,0,_texture.Width,_texture.Height), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
        }
    }
}