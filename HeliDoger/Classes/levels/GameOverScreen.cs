using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using HeliDoger.abstractclasses;
using HeliDoger;

namespace HeliDoger.Classes.Screens
{
    class GameOverScreen : IScreen
    {
        #region TexturesAndSounds
        private Texture2D _background;
        private SpriteFont _scoreFont;
        private SoundEffect _sound;
        #endregion

        private Button _yes;
        private Button _no;

        public GameOverScreen(ContentManager content) : base(content)
        {
            Game1.gamestate.IsMouseVisible = true;
        }

        public override void InitializeObjects()
        {
            _sound = _content.Load<SoundEffect>("Sounds/Heart");
            _sound.Play();

            _background = _content.Load<Texture2D>("Backgrounds/diveBackground");
            
            _yes = new Button(_content.Load<Texture2D>("Buttons/YesB"), 
                new Rectangle(400, 600, 150, 100));
            _yes.ClickAction = () => Game1.gamestate.ChangeScreen(GameState.Playing);


            GameObjects.Add(_yes);

            _no = new Button(_content.Load<Texture2D>("Buttons/NoB"), 
                new Rectangle(850, 600, 150, 100));
            _no.ClickAction = () => Game1.gamestate.ChangeScreen(GameState.MainMenu);

            GameObjects.Add(_no);

            _scoreFont = _content.Load<SpriteFont>("Fonts/FontScore");
        }

        public override void Update(GameTime time, MouseState mouse) 
        {
            base.Update(time, mouse);
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(_background, new Rectangle(0, 0, 
                Game1.ScreenWidth, Game1.ScreenHeight), Color.White);
            spriteBatch.DrawString(_scoreFont, "- GAME OVER -", new Vector2(640,300), Color.White);
            spriteBatch.DrawString(_scoreFont, "Your score was: " + player.scoins, 
                new Vector2(620, 350), Color.White);
            spriteBatch.DrawString(_scoreFont, "Try again?", new Vector2(650,500), Color.White);
            
            base.Draw(spriteBatch);
        }

    }
}
