﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;
using SharpDX.Direct2D1;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using HeliDoger.Classes.background;
using HeliDoger.Classes.Enemies;
using HeliDoger.Classes.player;
namespace HeliDoger.Classes
{
    class MainGame : Screen
    {
     
        private Texture2D _staticBackground;
        private Texture2D _lives;
        private SpriteFont _font;
        private SoundEffect _sound;
        SoundEffectInstance backgroundmusic;
    

        private MainPlayer _player;
        private LevelGen _generator;
        private BackClouds _clouds;
        private int gravity = 80;

    
        public MainGame(ContentManager content, int enemydif, int powerdiff ,int coindiff,bool day) : base(content)
        {
           
            Game1.gamestate.IsMouseVisible = false;

            var factory = new MainLevelFactory(content);
            this._generator = new LevelGen(this, factory, enemydif, powerdiff ,coindiff);
            this._clouds = new BackClouds(this, factory);
            //background change
            if (day)
            {
            _staticBackground = _content.Load<Texture2D>("Background/blueskyl");
            }
            else
            {
                _staticBackground = _content.Load<Texture2D>("Background/Nightsky");
            }
        }

        public override void InitializeObjects()
        {
            _sound = _content.Load<SoundEffect>("Music/MainMusic");
            backgroundmusic = _sound.CreateInstance();
            backgroundmusic.IsLooped = true;
            backgroundmusic.Play();

            _player = new MainPlayer(_content.Load<Texture2D>("player/helicopter"));
            GameObjects.Add(_player);

            
            _font = _content.Load<SpriteFont>("Fonts/game");
            _lives = _content.Load<Texture2D>("objects/hearth");
        }


        public override void Update(GameTime time, MouseState mouseState)
        {
            this._player.Move(0, gravity);

            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) 
            {
                Game1.gamestate.ChangeScreen("menu");
                backgroundmusic.Stop();
            }

            base.Update(time, mouseState);

            this.Camera.Position = new Vector2(_player.Position.X + Game1.ScreenWidth 
                / 2 - 0f * _player.Size.X, 0f);
            this._generator.Update(this._player.Position);
            this._clouds.Update(this._player.Position);
           
            if (_player.Lives == 0)
                backgroundmusic.Stop();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var statPos = this.Camera.Position - new Vector2(Game1.ScreenWidth, 
                Game1.ScreenHeight) / 2f;
            spriteBatch.Draw(_staticBackground, new Rectangle(Convert.ToInt32(statPos.X), 
                Convert.ToInt32(statPos.Y), Game1.ScreenWidth, Game1.ScreenHeight), Color.White);
            base.Draw(spriteBatch);
            spriteBatch.DrawString(_font, "coins: " + Convert.ToString( _player.Coins), 
                new Vector2(this.Camera.Position.X + 400, this.Camera.Position.Y - 390), Color.Black);

      
            int x = 450;
            for (int i = 0; i < _player.Lives; i++)
            {
                spriteBatch.Draw(_lives, new Rectangle(Convert.ToInt32(this.Camera.Position.X) + x, Convert.ToInt32(this.Camera.Position.Y) - 300, 50, 50), Color.White);
                x = x + 50;
            }
        }
    }
}