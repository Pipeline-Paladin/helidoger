using System;
using System.Collections.Generic;
using HeliDoger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.Animations;
using HeliDoger.Classes;
using HeliDoger.Classes.Objects;
using HeliDoger.abstractclasses;

namespace HeliDoger
{
    class player : GameObject
    {
        Texture2D _Texture;
        public Animation Animation { get; set; }

        private float _speed = 300;
      
        public int Coins { get; private set; } = 0;
        public static int scoins { get; private set; }
        public int Lives { get; private set; } = 3;
        private bool _invincible = false;

        public player(Texture2D texture, int fps) : base()
        {
            this.DrawOrder = 5;
            this.Position = new Vector2(0, 0);

            _Texture = texture;
            Animation = new Animation(fps);

            for (int i = 0; i < 3; i++)
            {
                Animation.AddFrame(new AnimationFrame(new Rectangle(0, i * 148, 355, 148)));
            }

            this.Size = Animation.CurrentFrame.OriginRectangle.Size.ToVector2() * 0.6f;
        }

       

        public override void Update(GameTime gameTime, MouseState mouse)
        {
            scoins = Coins;
            KeyboardState keyboard = Keyboard.GetState();

            // Update sprite
            Animation.Update(gameTime);

            // Constantly move right
            this.Position += new Vector2(this._speed, 0f) * 
                Convert.ToSingle(gameTime.ElapsedGameTime.TotalSeconds);
            
            if (keyboard.IsKeyDown(Keys.Down))
            {
                Animation.Update(gameTime); // more animation update when swimming up or down
                this.Move(0, this._speed);
            }
            else if (keyboard.IsKeyDown(Keys.Up))
            {
                Animation.Update(gameTime);
                this.Move(0, -this._speed);
            }

            
            IncrementSpeed();
        }

        public override void OnCollision(GameObject gameObject)
        {
            if (gameObject is Wall) 
                base.OnCollision(gameObject);
            if (gameObject is Enemy)
            {
                if (!this._invincible) 
                {
                    this.Lives -= 1;
                    _invincible = true;
                }

                if (this.Lives == 0) 
                {
                    
                    Game1.gamestate.ChangeScreen(GameState.GameOver);
                }
            }
            if (gameObject is coin) 
            {
                if (this._invincible) 
                    this._invincible = false;
                Coins += 1;
                gameObject.Position = Vector2.Zero;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var pos = this.Position;
          

            if (!this._invincible) 
            {
                spriteBatch.Draw(_Texture, pos, Animation.CurrentFrame.OriginRectangle,
                    Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
            else 
            {
                    spriteBatch.Draw(_Texture, pos, Animation.CurrentFrame.OriginRectangle,
                        Color.Black, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);
            }
            

        }
        public void IncrementSpeed() 
        {
            
            this._speed = (Coins +10)* 80;
            this.Move(0, Coins * coin.Weight);
        }

    }
}