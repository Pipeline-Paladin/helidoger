using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;
using HeliDoger.Animations;
using MonoGame.Extended.Sprites;
using Animation = HeliDoger.Animations.Animation;

namespace HeliDoger.Classes.Enemies
{
    class bird : Enemy
    {
        private Texture2D _texture;
        private float _speed = 300;
        public Animation _Animation;
        public bird(Texture2D texture, float x)
        {
            this._texture = texture;
            this.Size = this._texture.Bounds.Size.ToVector2() * 0.3f;
            this.DrawOrder = 0;

            int ypos = random.Next(-300, 200);
            this.Position = new Vector2(x, ypos);
            _Animation = new Animation(4);
            for (int i = 0; i < 3; i++)
            {
                _Animation.AddFrame(new AnimationFrame(new Rectangle(i * 260, 0, 260, 300)));
            }

        }

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            this.Move(-this._speed, 0f);
            _Animation.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, this.Position, _Animation.CurrentFrame.OriginRectangle, 
                Color.Red, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

    }
}
