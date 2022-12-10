using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeliDoger.abstractclasses
{
    public abstract class Enemy : GameObject
    {
        protected Random random = new Random();

        public override void Update(GameTime gameTime, MouseState mouse) { }
        public override void Draw(SpriteBatch spritebatch) { }

        public override void OnCollision(GameObject gameObject)
        {
            
        }
    }
}
