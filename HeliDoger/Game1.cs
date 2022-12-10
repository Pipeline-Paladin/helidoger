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

        public static int ScreenWidth { get; private set; } = 1422;
        public static int ScreenHeight { get; private set; } = 800;

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
        private IScreen _gameScreen;
        private IScreen _newGameScreen;
        public void ChangeScreen(string newscreen)
        {
            switch (newscreen)
            {
                case "menu":
                    _newGameScreen = new Menu(Content);
                    break;
                case "play":
                    _newGameScreen = new MainGame(Content);
                    break;
                case "info":
                    _newGameScreen = new ControlScreen(Content);
                    break;
                case "death":
                    _newGameScreen = new GameOverScreen(Content);
                    break;
              
            }
        }
    }
}
