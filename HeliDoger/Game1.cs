using HeliDoger.Classes;
using HeliDoger.Classes.levels;
using HeliDoger.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HeliDoger
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IScreen _gameScreen;
       
        private IScreen _tempGameScreen;

      
      
        public static Game1 gameState { get; private set; }

        public static int
             ScreenWidth = 1422,
             ScreenHeight = 800;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            gameState = this;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            Window.AllowUserResizing = false;
            Window.AllowAltF4 = true;
            Window.Title = "HeliDoger";
            _gameScreen = new MenuScreen(Content);
           

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

            _spriteBatch.Begin();
            _gameScreen.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);

            if (_tempGameScreen != null)
            {
                _gameScreen = _tempGameScreen;
                _tempGameScreen = null;
            }
        }
        
        public void ChangeScreen(string newState)
        { 
              switch (newState)
            {
                case "menu":
                    _tempGameScreen = new MenuScreen(Content);
                    break;
               
                case "start":
                    _tempGameScreen = new MainGame(Content);
                    break;
                case "info":
                    _tempGameScreen = new MenuScreen(Content);
                    break;
                case "deathscreen":
                    _tempGameScreen = new MenuScreen(Content);
                    break;
                case "back":
                    
                    break;
            }
            
            if (newState == "MainMenu")
            {
                gameState.ChangeScreen("MainMenu");
               

            }
        }
        
    }
}