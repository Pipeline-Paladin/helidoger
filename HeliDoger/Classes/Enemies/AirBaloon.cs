﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes.Objects
{
    public class AirBaloon : Enemy
    {
        private Texture2D _texture;
        private float _speed = 30;

        public AirBaloon(Texture2D texture, float x)
        {
            this._texture = texture;
            this.Size = this._texture.Bounds.Size.ToVector2() * 0.3f;
            this.DrawOrder = 0;

            int ypos = random.Next(-400, -100);       
            this.Position = new Vector2(x, ypos);
        }

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            this.Move(0f, _speed);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, this.Position, new Rectangle(0, 0, _texture.Width, _texture.Height),
                Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }
    }
}
