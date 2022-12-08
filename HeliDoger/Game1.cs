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
       
        private IScreen _newGameScreen;

      
      
        public static Game1 gameState { get; private set; }

        //screensize adjusting
         public static int ScreenWidth = 1422;
         public static int ScreenHeight = 800;

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
            _gameScreen = new MenuScreen(Content);
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //screensize adjusting
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
        
        public void ChangeScreen(string newState)
        { 
              switch (newState)
            {
                case "menu":
                    _newGameScreen = new MenuScreen(Content);
                    break;
               
                case "start":
                    _newGameScreen = new MainGame(Content);
                    break;
                case "info":
                    _newGameScreen = new MenuScreen(Content);
                    break;
                case "deathscreen":
                    _newGameScreen = new MenuScreen(Content);
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