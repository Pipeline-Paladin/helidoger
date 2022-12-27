using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.Animations;
using HeliDoger.Classes;
using HeliDoger.Classes.Objects;
using HeliDoger.abstractclasses;
using MonoGame.Extended.Timers;
using System.Threading.Tasks;
using System.Diagnostics;
using HeliDoger.Classes.Objects.Powerups;

namespace HeliDoger.Classes.player
{
    class MainPlayer : GameObject
    {
        Texture2D _Texture;
        public Animation Animation { get; set; }

        private float _Playerspeed = 300;
        public static MainPlayer player { get; private set; }
        public int Coins { get; private set; } = 0;
        public static int scoins { get; private set; }
        public int Lives { get;  set; } = 3;
        public bool _invincible = false;
        public int _invicibleTime = 0;
     
        public bool _timeslow = false;
        public int _slowdowntime = 200;
 
        private void timer(GameTime gameTime)
        {
            if (_invincible)
            {
                if (_invicibleTime == 0)
                {
                    _invincible = false;
                }
                _invicibleTime--;
            }
            if (_timeslow)
            {
                if (_slowdowntime == 0)
                {
                    _timeslow = false;
                }
                _slowdowntime--;
            }

        }
        public MainPlayer(Texture2D texture) : base()
        {
            player = this;
            DrawOrder = 5;
            Position = new Vector2(0, 0);

            _Texture = texture;
            Animation = new Animation(5);

            for (int i = 0; i < 3; i++)
            {
                Animation.AddFrame(new AnimationFrame(new Rectangle(0, i * 148, 355, 148)));
            }

            Size = Animation.CurrentFrame.OriginRectangle.Size.ToVector2() * 0.6f;
        }

    

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            scoins = Coins;
            KeyboardState keyboard = Keyboard.GetState();
            Animation.Update(gameTime);
            Position += new Vector2(_Playerspeed, 0f) * Convert.ToSingle(gameTime.ElapsedGameTime.TotalSeconds);

            // more animation update when swimming up or down
            if (keyboard.IsKeyDown(Keys.Down))
            {
                Animation.Update(gameTime); 
                Move(0, _Playerspeed-100);
            }
            else if (keyboard.IsKeyDown(Keys.Up))
            {
                Animation.Update(gameTime);
                Move(0, -_Playerspeed+100);
            }
            timer(gameTime);



            IncrementSpeed();
        }

        public override void OnCollision(GameObject gameObject)
        {
            if (gameObject is Wall)
                base.OnCollision(gameObject);
            
            if (gameObject is coin)
            {
                Coins += 1;
                gameObject.Position = Vector2.Zero;
            }

            if (gameObject is ExtralifePowerUp)
            {

                if (Lives < 3)
                {
                    Lives++;
                }
                gameObject.Position = Vector2.Zero;
            }
            if (gameObject is invincebillityPowerup)
            {
                _invincible = true;
                _invicibleTime = 120;
                gameObject.Position = Vector2.Zero;
            }
            if (gameObject is SlowDownPower)
            {
                if (scoins > 0)
                {
                        _timeslow = true;
                    gameObject.Position = Vector2.Zero;
                }
               
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var pos = Position;


            if (!_invincible)
            {
                spriteBatch.Draw(_Texture, pos, Animation.CurrentFrame.OriginRectangle,
                    Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(_Texture, pos, Animation.CurrentFrame.OriginRectangle,
                    Color.Gray, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }


        }
        public void IncrementSpeed()
        {
            if (_timeslow)
            {
                _Playerspeed = (Coins+1) * 60;
            }
            else
            {
                _Playerspeed = (Coins + 10) * 80;
            }
            Move(0, (Coins * 2 ));
        }

    }
}