using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes.Enemies
{
    class Tree :Enemy
    {
        private Texture2D _texture;

        public Tree(Texture2D texture, float x)
        {
            this._texture = texture;
            this.Size = this._texture.Bounds.Size.ToVector2() * 0.3f;
            int ypos = random.Next(-100, 250);
            this.DrawOrder = 0;
            this.Position = new Vector2(x, ypos);
        }

        public override void Update(GameTime gameTime, MouseState mouse) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, this.Position, new Rectangle(0, 0, _texture.Width, _texture.Height), 
                Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }
    }
}
