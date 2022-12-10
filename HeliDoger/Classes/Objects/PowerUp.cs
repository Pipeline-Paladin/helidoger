using HeliDoger.abstractclasses;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliDoger.Classes.Objects
{
    class PowerUp : IStaticObject
    {
        private Texture2D _texture;
        private float _speed = 0;
        public static float Weight { get; private set; } = 5f;

        public PowerUp(Texture2D texture, Vector2 pos)
        {
            this._texture = texture;
            this.Position = pos;
            this.Size = this._texture.Bounds.Size.ToVector2();
            this.DrawOrder = 10;
        }

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            this.Position += new Vector2(-this._speed, 0f) *
                Convert.ToSingle(gameTime.ElapsedGameTime.TotalSeconds);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, this.Position, new Rectangle(Point.Zero, _texture.Bounds.Size),
                Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }

    }
}
