using HeliDoger.Classes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliDoger.Classes.enemy
{
    class Bird : IEnemy
    {
        //varable
        private Texture2D _texture;
        private float _Enemyspeed = 500;

        public Bird(Texture2D texture) {

            _texture = texture;
        }
        public override void Update(GameTime gameTime, MouseState mouse)
        {
            //this.Move(-this._Enemyspeed, 0f);
            base.Update(gameTime, mouse);
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, Vector2.Zero, new Rectangle(0, 0, _texture.Width, _texture.Height),
                Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);
        }
        public virtual void LoadContent(ContentManager content) { }


    }
}
