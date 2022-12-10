using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes
{
    public class Mountain : MovableObject
    {
        private Texture2D _texture;
        private float _counterSpeed = 120;

        public Mountain(Texture2D texture, float x)
        {
            this.DrawOrder = -1;
            this._texture = texture;

            this.Position = new Vector2(x, -450);
            this.Size = new Vector2(this._texture.Bounds.Size.X, 0);
        }

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            this.Move(this._counterSpeed, 0);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this._texture, this.Position, Color.White);
        }
    }
}