using HeliDoger.Classes.levels.background;
using HeliDoger.Classes.player;
using HeliDoger.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace HeliDoger.Classes.levels
{
    internal class MainGame : IScreen
    {

        //Varables
        private Player _diver;
        private skybox _background;

        public MainGame(ContentManager content) : base(content)
        {

           
            _background = new skybox(content);
        }
        public override void initobj()
        {
           

        }
            public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background.sky, _background.positionSky, Color.White);

        }
    }
}
