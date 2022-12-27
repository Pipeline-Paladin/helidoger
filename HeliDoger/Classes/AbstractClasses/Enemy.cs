using HeliDoger.Classes.player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
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

            if (gameObject is MainPlayer)
            {
                if (!MainPlayer.player._invincible)
                {
                    MainPlayer.player.Lives -= 1;
                    MainPlayer.player._invincible = true;
                    MainPlayer.player._invicibleTime = 120; ;
                }
                if (MainPlayer.player.Lives == 0)
                {
                    Game1.gamestate.ChangeScreen("death");
                }
            }
        }
    }
}
