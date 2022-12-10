using HeliDoger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes.Screens
{
    class ControlScreen : IScreen
    {
        #region TexturesAndSounds
        private SoundEffect _sound;
        private Texture2D _background;
        private Texture2D _instructions;
        #endregion

        private Button _back;

        public ControlScreen(ContentManager content) : base(content)
        {
            Game1.gamestate.IsMouseVisible = true;
        }

        public override void InitializeObjects()
        {
            _sound = _content.Load<SoundEffect>("Sounds/LightMusic");
            SoundEffectInstance backgroundMusic = _sound.CreateInstance();
            backgroundMusic.IsLooped = true;
            backgroundMusic.Play();

            _background = _content.Load<Texture2D>("Backgrounds/playingBackground");
            _instructions = _content.Load<Texture2D>("Backgrounds/Instructions");

            _back = new Button(_content.Load<Texture2D>("Buttons/BackB"), new Rectangle(1100, 700, 300, 100));
            _back.ClickAction = () => 
            {
                backgroundMusic.Stop();
                Game1.gamestate.ChangeScreen("menu");
            };
            GameObjects.Add(_back);
        }

        public override void Update(GameTime time, MouseState mouse)
        {
            base.Update(time, mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight), Color.White);
            spriteBatch.Draw(_instructions, new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight), Color.White);

            base.Draw(spriteBatch);
        }

    }
}