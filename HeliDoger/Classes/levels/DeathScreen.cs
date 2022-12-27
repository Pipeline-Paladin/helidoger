using System.Linq;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using HeliDoger.abstractclasses;
using HeliDoger.Classes.player;

namespace HeliDoger.Classes.Screens
{
    class DeathScreen : Screen
    {
        #region TexturesAndSounds
        private Texture2D _background;
        private SpriteFont _scoreFont;
        private SoundEffect _sound;
        #endregion

        private Button _yes;
        private Button _no;

        public DeathScreen(ContentManager content) : base(content)
        {
            Game1.gamestate.IsMouseVisible = true;
        }

        public override void InitializeObjects()
        {
            _sound = _content.Load<SoundEffect>("Music/DeathEffect");
            _sound.Play();

            _background = _content.Load<Texture2D>("BackGround/blueskyl");
            
            _yes = new Button(_content.Load<Texture2D>("Button/start"), 
                new Rectangle(400, 600, 200, 100));
            _yes.ClickAction = () => Game1.gamestate.ChangeScreen("play", Game1.enemydiff,Game1.powerdiff,Game1.coindiff, true);


            GameObjects.Add(_yes);

            _no = new Button(_content.Load<Texture2D>("Button/back"), 
                new Rectangle(850, 600, 300, 100));
            _no.ClickAction = () => Game1.gamestate.ChangeScreen("menu");

            GameObjects.Add(_no);

            _scoreFont = _content.Load<SpriteFont>("Fonts/game");
        }

        public override void Update(GameTime time, MouseState mouse) 
        {
            base.Update(time, mouse);
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(_background, new Rectangle(0, 0, 
                Game1.ScreenWidth, Game1.ScreenHeight), Color.White);
            spriteBatch.DrawString(_scoreFont, "- GAME OVER -", new Vector2(Game1.ScreenWidth / 3,300), Color.White);
            spriteBatch.DrawString(_scoreFont, "Your score: " + MainPlayer.scoins, 
                new Vector2(Game1.ScreenWidth / 3, 350), Color.White);
            spriteBatch.DrawString(_scoreFont, "Try again?", new Vector2(Game1.ScreenWidth / 3, 500), Color.White);
            
            base.Draw(spriteBatch);
        }

    }
}
