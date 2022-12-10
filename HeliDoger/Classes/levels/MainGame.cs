using System;
using HeliDoger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;
using SharpDX.Direct2D1;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using HeliDoger.Classes.background;

namespace HeliDoger.Classes
{
    class MainGame : IScreen
    {
        #region TexturesAndSounds
        private Texture2D _staticBackground;
        private Texture2D _lives3;
        private Texture2D _lives2;
        private Texture2D _lives1;
        private SpriteFont _scoreFont;
        private SoundEffect _sound;
        SoundEffectInstance breathingSound;
        #endregion

        private player _player;
        private LevelGen _generator;
        private BackClouds _clouds;
        private int gravity = 80;

        public MainGame(ContentManager content) : base(content)
        {
            Game1.gamestate.IsMouseVisible = false;

            var factory = new LevelFactory(content);
            this._generator = new LevelGen(this, factory);
            this._clouds = new BackClouds(this, factory);
        }

        public override void InitializeObjects()
        {
            _sound = _content.Load<SoundEffect>("Music/MainMusic");
            breathingSound = _sound.CreateInstance();
            breathingSound.IsLooped = true;
            breathingSound.Play();
            _player = new player(_content.Load<Texture2D>("player/helicopter"), 2);
            GameObjects.Add(_player);

            _staticBackground = _content.Load<Texture2D>("Background/blueskyl");
            _scoreFont = _content.Load<SpriteFont>("Fonts/game");
            _lives3 = _content.Load<Texture2D>("Background/cloud");
            _lives2 = _content.Load<Texture2D>("player/helicopter");
            _lives1 = _content.Load<Texture2D>("Background/cloud");
        }


        public override void Update(GameTime time, MouseState mouseState)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) 
            {
                Game1.gamestate.ChangeScreen(GameState.MainMenu);
                breathingSound.Stop();
            }

            base.Update(time, mouseState);

            this.Camera.Position = new Vector2(_player.Position.X + Game1.ScreenWidth 
                / 2 - 0f * _player.Size.X, 0f);
            this._generator.Update(this._player.Position);
            this._clouds.Update(this._player.Position);
            this._player.Move(0, gravity);
            if (_player.Lives == 0)
                breathingSound.Stop();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var statPos = this.Camera.Position - new Vector2(Game1.ScreenWidth, 
                Game1.ScreenHeight) / 2f;
            spriteBatch.Draw(_staticBackground, new Rectangle(Convert.ToInt32(statPos.X), 
                Convert.ToInt32(statPos.Y), Game1.ScreenWidth, Game1.ScreenHeight), Color.White);
            base.Draw(spriteBatch);
            spriteBatch.DrawString(_scoreFont, "coins: " + Convert.ToString( _player.Coins), 
                new Vector2(this.Camera.Position.X + 400, this.Camera.Position.Y - 390), Color.White);

            if (_player.Lives == 3)
                spriteBatch.Draw(_lives3, new Rectangle(Convert.ToInt32(this.Camera.Position.X) + 450, Convert.ToInt32(this.Camera.Position.Y) - 300, 150, 50),Color.White);
            else if (_player.Lives == 2)
                spriteBatch.Draw(_lives2, new Rectangle(Convert.ToInt32(this.Camera.Position.X) + 450, Convert.ToInt32(this.Camera.Position.Y) - 300, 150, 50), Color.White);
            else if (_player.Lives == 1)
                spriteBatch.Draw(_lives1, new Rectangle(Convert.ToInt32(this.Camera.Position.X) + 450, Convert.ToInt32(this.Camera.Position.Y) - 300, 150, 50), Color.White);

        }
    }
}