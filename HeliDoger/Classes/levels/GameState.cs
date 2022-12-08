using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using SharpDX.Direct2D1;
using HeliDoger.Interfaces;
using SpriteBatch = SharpDX.Direct2D1.SpriteBatch;

namespace HeliDoger.Classes.levels
{
    public class GameState 
    {
       
        private MainGame maingame;
        private ContentManager _content;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private IScreen _gameScreen;
        private MenuScreen _newGameScreen;

        //singelston



        #region Constructor
        public GameState(ContentManager content)
        {
            _content = new ContentManager(content.ServiceProvider, "Content");
        }
        #endregion
        #region Methodes
        public void Draw(SpriteBatch _spriteBatch)
        {
          
        }
        public void Update(GameTime gameTime)
        {
          
        }
        public void LoadContent(ContentManager content)
        {
          
        }

        public void init(ContentManager content) {
            


        }
        public void ChangeScreen(string newState)
        {
            
            switch (newState)
            {
                case "menu":
                    _newGameScreen = new MenuScreen(_content);
                    break;
               
                case "start":
                    maingame = new MainGame(_content);
                    break;
                case "info":
                    _newGameScreen = new MenuScreen(_content);
                    
               
                    break;
                case "deathscreen":
                    _newGameScreen = new MenuScreen(_content);
                    break;
                case "back":
                    
                    break;
            }
               

            
        }

        public void update() {

            if (_newGameScreen != null)
            {
                _gameScreen = _newGameScreen;
                _newGameScreen = null;
            }


        }
        #endregion
    }
}

