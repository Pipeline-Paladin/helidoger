using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace HeliDoger.Classes.levels.background
{
     public class skybox
    {

       
        public Texture2D ground;
        public Texture2D sky;
        public Rectangle positionSky;
        public Rectangle positionGround;
        public Rectangle positionBackground;

        public skybox(ContentManager content)
        {
            positionSky = new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight);
            positionGround = new Rectangle(0, 700, Game1.ScreenWidth, 113);
            positionBackground = new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight);

            sky = content.Load<Texture2D>("BackGround/blueskyl");
            ground = content.Load<Texture2D>("BackGround/ground");


        }
    }
}
