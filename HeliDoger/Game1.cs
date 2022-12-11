using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using HeliDoger.Classes.Screens;
using HeliDoger.Classes;
using HeliDoger.abstractclasses;


namespace HeliDoger
{
    public class Game1 : Game   // Singleton pattern
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;     
        public static Game1 gamestate { get; private set; }

        public static int enemydiff = 4;
        public static int powerdiff = 10;
        public static int coindiff = 7;

        public Game1()
        {
            gamestate = this;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            _gameScreen = new Menu(Content);
        }


        public static int ScreenWidth = 1422;
        public static int ScreenHeight = 800;
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

           
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            _gameScreen.Update(gameTime, mouse);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(transformMatrix: _gameScreen.Camera.GetTransform());
            _gameScreen.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);

            if (_newGameScreen != null)
            {
                _gameScreen = _newGameScreen;
                _newGameScreen = null;
            }
        }
        private Screen _gameScreen;
        private Screen _newGameScreen;
        public void ChangeScreen(string newscreen)
        {
            switch (newscreen)
            {
                case "menu":
                    _newGameScreen = new Menu(Content);
                    break;
                
                case "info":
                    _newGameScreen = new InfoScreen(Content);
                    break;
                case "death":
                    _newGameScreen = new DeathScreen(Content);
                    break;
              
            }
        }
        public void ChangeScreen(string newscreen, int enemydif, int powerdiff, int coindiff)
        {
            switch (newscreen)
            {
                case "play":
                    _newGameScreen = new MainGame(Content , enemydif, powerdiff, coindiff);
                    break;

            }
        }
    }
}
