using HeliDoger.Animations;
using HeliDoger.Classes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
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
        private float _Enemyspeed = 100;
        public Animation _Animation;
        private Random random;
        public Bird(Texture2D texture) {

            _texture = texture;

            _Animation = new Animation(4);
         
            for (int i = 0; i < 3; i++)
            {
                _Animation.AddFrame(new AnimationFrame(new Rectangle(i * 184, 0, 184, 184)));
            }
        }
        public override void Update(GameTime gameTime, MouseState mouse)
        {
            this.Move(-this._Enemyspeed, 0f);
            base.Update(gameTime, mouse);
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, Vector2.Zero, _Animation.CurrentFrame.OriginRectangle,Color.White, 0f, Vector2.Zero, 0.3f, SpriteEffects.None, 0f);

        }
        public virtual void LoadContent(ContentManager content) { }


    }
}
