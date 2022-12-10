using System;
using HeliDoger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using HeliDoger.Classes.Enemies;
using HeliDoger.Classes.Objects;
using HeliDoger.abstractclasses;

namespace HeliDoger.Classes
{
    public class LevelFactory 
    {
        private ContentManager _content;
        private Random _random = new Random();
   

        public LevelFactory(ContentManager content)
        {
            this._content = content;
        }

        public GameObject CreateTile(float x, bool top)
        {
            var yPos = Game1.ScreenHeight / 2;

            var pos = new Vector2(x, top ? -yPos : yPos);
            var wall = new Wall(this._content.Load<Texture2D>("tiles/tiles2"), pos);
            if (top)
            {
                 wall = new Wall(this._content.Load<Texture2D>("tiles/cloud"), pos);
            }
            else
            { 
             wall = new Wall(this._content.Load<Texture2D>("tiles/tiles2"), pos);
            
            }
            

            if(!top) wall.Position -= new Vector2(0, wall.Size.Y);

            return wall;
        }

        public GameObject CreateEnemy(float x)
        {
            int type = _random.Next(0, 4); 
            Enemy enemy =null;
            
            if (type == 0) 
            {
                enemy = new Jellyfish(this._content.Load<Texture2D>("enemy/AirBaloon"), x);
            }
            else if (type == 1)
            {
                enemy = new LionFish(this._content.Load<Texture2D>("enemy/bird"), x);
            }
            else if (type == 2)
            {
                enemy = new Tree(this._content.Load<Texture2D>("enemy/tree"),x);
            }
            else if (type == 3) 
            {
                enemy = new TigerShark(this._content.Load<Texture2D>("enemy/bird"), x);
            }

            return enemy;
        }

        public GameObject CreateMountain(float x)
        {
            return new Mountain(this._content.Load<Texture2D>("Background/cloud"), x);
        }
        
        /*
        public IGameObject CreateBottle(float x)
        {
            int ypos = _random.Next(0,2);
            return new Bottle(this._content.Load<Texture2D>("Objects/tank"),new Vector2(x, ypos));
        }
        */
    }
}