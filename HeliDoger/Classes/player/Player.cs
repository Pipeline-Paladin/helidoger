using HeliDoger.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliDoger.Classes.player
{
    internal class Player 
    {
        //varable
        private Texture2D _texture;
        public int lives { get; set; }
        public Player()
        {

            lives = 3;
        }

        public void LoadContent(ContentManager Content)
        {

            _texture = Content.Load<Texture2D>("player/helicopter");

        }
        public void Draw(SpriteBatch spriteBatch)
        { 
        }
      
       
    }
}
