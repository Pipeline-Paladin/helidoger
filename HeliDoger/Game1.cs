using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using HeliDoger.Classes.Screens;
using HeliDoger.Classes;
using HeliDoger.abstractclasses;


namespace HeliDoger
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Controls,
        GameOver,
        Scoreboard
    }

    public class Game1 : Game   // Design: Singleton pattern
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IScreen _gameScreen;
        private IScreen _newGameScreen;
        public static Game1 gamestate { get; private set; }

        //screensize adjusting
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
            GraphicsDevice.Clear(Color.Black);

            //transformmatrix from: https://stackoverflow.com/questions/6403543/spritebatch-begin-transform-matrix
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

        public void ChangeScreen(GameState newState)
        {
            switch (newState)
            {
                case GameState.MainMenu:
                    _newGameScreen = new Menu(Content);
                    break;
                case GameState.Playing:
                    _newGameScreen = new MainGame(Content);
                    break;
                case GameState.Controls:
                    _newGameScreen = new ControlScreen(Content);
                    break;
                case GameState.GameOver:
                    _newGameScreen = new GameOverScreen(Content);
                    break;
              
            }
        }
    }
}
