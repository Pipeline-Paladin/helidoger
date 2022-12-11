using HeliDoger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes
{
    class Menu : Screen
    {
        #region TexturesAndSounds
        private Texture2D _backgroundTexture;
        private SoundEffect _sound;
        #endregion

        private Button _play;
        private Button _controls;
        private Button _exit;
       

        public Menu(ContentManager content) : base(content)
        {
            Game1.gamestate.IsMouseVisible = true;
        }

        public override void InitializeObjects()
        {
            this._sound = _content.Load<SoundEffect>("Music/MainMusic");
            SoundEffectInstance backgroundMusic = this._sound.CreateInstance();
            backgroundMusic.IsLooped = true;
            backgroundMusic.Play();

            _controls = new Button(_content.Load<Texture2D>("Button/level1"), 
                new Rectangle(0, 50, 300, 100));
            _controls.ClickAction = () =>
            {
                backgroundMusic.Stop();
                Game1.gamestate.ChangeScreen("play", Game1.enemydiff, Game1.powerdiff, Game1.coindiff);
            };

            _play = new Button(_content.Load<Texture2D>("Button/level2"), 
                new Rectangle(0, 200, 300, 100));
            _play.ClickAction = () =>
            {
                backgroundMusic.Stop();
                Game1.gamestate.ChangeScreen("play", Game1.enemydiff - 3, Game1.powerdiff + 10 , Game1.coindiff - 4);
            };

            _exit = new Button(_content.Load<Texture2D>("Button/back"), 
                new Rectangle(1100, 200, 300, 100));
            _exit.ClickAction = () => Game1.gamestate.Exit();

          

            _backgroundTexture = _content.Load<Texture2D>("BackGround/BackgroundMenu");


            GameObjects.Add(_controls);
            GameObjects.Add(_play);
            GameObjects.Add(_exit);
 
        }

        public override void Update(GameTime time, MouseState mouse)
        {
            base.Update(time, mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_backgroundTexture, new Rectangle(0, 0, Game1.ScreenWidth, 
                Game1.ScreenHeight), Color.White);

            base.Draw(spriteBatch);
        }

    }
}