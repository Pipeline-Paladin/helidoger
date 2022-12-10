using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes.background
{
    public class Clouds : MovableObject
    {
        private Texture2D _texture;
        private float _counterSpeed = 120;

        public Clouds(Texture2D texture, float x)
        {
            DrawOrder = -1;
            _texture = texture;

            Position = new Vector2(x, -450);
            Size = new Vector2(_texture.Bounds.Size.X, 0);
        }

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            Move(_counterSpeed, 0);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(_texture, Position, Color.White);
        }
    }
}