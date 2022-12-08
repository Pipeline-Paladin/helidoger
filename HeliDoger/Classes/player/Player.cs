using HeliDoger.Animations;
using HeliDoger.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliDoger.Classes.player
{
    internal class Player : IGameObject
    {
        //varable
        private Texture2D _texture;
        public int lives { get; set; }
        public Animation Animation;
        public Player()
        {
            Animation = new Animation(60);
            lives = 3;
            for (int i = 0; i < 4; i++)
            {
                Animation.AddFrame(new AnimationFrame(new Rectangle(i* 634, 0, 680, 211)));
            }
        }

        public void LoadContent(ContentManager Content)
        {

            _texture = Content.Load<Texture2D>("player/helicopter");

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Vector2.Zero, Animation.CurrentFrame.OriginRectangle,
                    Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            Animation.Update(gameTime);
        }

     
    }
}
