using HeliDoger.Animations;
using HeliDoger.Interfaces;
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

namespace HeliDoger.Classes.player
{
    internal class Player : IGameObject
    {
        //varable
        public Texture2D _texture;
        public int lives { get; set; }
        public Animation Animation;
        public Player(Texture2D texture)
        {
            _texture = texture;
            Animation = new Animation(4);
            lives = 3;
            for (int i = 0; i < 3; i++)
            {
                Animation.AddFrame(new AnimationFrame(new Rectangle(0, i* 148, 355, 148)));
            }
        }

        public void LoadContent(ContentManager Content)
        {


        }
        public override void Draw(SpriteBatch spriteBatch)
        {
          
        }

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            Animation.Update(gameTime);
        }

     
    }
}
