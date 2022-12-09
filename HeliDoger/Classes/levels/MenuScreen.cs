using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.Interfaces;
using HeliDoger.Classes.levels;
using System;

namespace HeliDoger.Classes
{
    class MenuScreen : IScreen
    {
        
        private Texture2D _background;
        private SoundEffect _sound;
      

        private Button _play;
        //private Button _info;
        
        
        private SpriteFont _font;

    

        public MenuScreen(ContentManager content) : base(content)
        {
             
        }

        public override void initobj()
        {
            _font = _content.Load<SpriteFont>("fonts/game");
            this._sound = _content.Load<SoundEffect>("Music/MainMusic");
            SoundEffectInstance backgroundMusic = this._sound.CreateInstance();
            backgroundMusic.IsLooped = true;
            backgroundMusic.Play();

            /*
            _info = new Button(_content.Load<Texture2D>("Button/info"), 
                new Rectangle(0, 200, 300, 100));
            _info.ClickAction = () =>
            {
                Game1.gameState.ChangeScreen("info");
            };
            */

            //start
            _play = new Button(_content.Load<Texture2D>("Button/start"), 
                new Rectangle(0, 50, 300, 100));
            _play.ClickAction = () =>
            {
                Game1.gameState.ChangeScreen("start");
                
            };


            _background = _content.Load<Texture2D>("BackGround/BackgroundMenu");

            //gameobjects 
            //GameObjects.Add(_info);
            GameObjects.Add(_play);
         
         
        }

        public override void Update(GameTime time, MouseState mouse)
        {
            base.Update(time, mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(_background, new Rectangle(0, 0, Game1.ScreenWidth, 
                Game1.ScreenHeight), Color.White);
            spriteBatch.DrawString(_font, "welcome to HeliDoger", new Vector2(0, 0), Color.White);
            base.Draw(spriteBatch);
        }

        public void loadcontent() { }

    }
}