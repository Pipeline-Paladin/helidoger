using System;
using HeliDoger;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using HeliDoger.Classes.Enemies;
using HeliDoger.Classes.Objects;
using HeliDoger.abstractclasses;
using HeliDoger.Classes.background;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata;

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
            Wall wall;
            if (top)
            {
                 wall = new Wall(this._content.Load<Texture2D>("tiles/cloud"), pos);
            }
            else
            {
                 wall = new Wall(this._content.Load<Texture2D>("tiles/tiles2"), pos);
                 wall.Position -= new Vector2(0, wall.Size.Y);
            }
           
            return wall;
        }

        public GameObject CreateEnemy(float x)
        {
            int type = _random.Next(0, 4); 
            Enemy enemy =null;

            switch (type)
            {
                case 0:
                    enemy = new AirBaloon(this._content.Load<Texture2D>("enemy/AirBaloon"), x); ;
                    break;

                case 1:
                    enemy = new bird(this._content.Load<Texture2D>("enemy/bird"), x);
                    break;
                case 2:
                    enemy = new Tree(this._content.Load<Texture2D>("enemy/tree"), x);
                    break;
                case 3:
                    enemy = new TigerShark(this._content.Load<Texture2D>("enemy/bird"), x);
                    break;
            }
            return enemy;
        }

        public GameObject CreateCoin(float x)
        {
            int ypos = _random.Next(0, 2);
            return new coin(this._content.Load<Texture2D>("Objects/coin"), new Vector2(x, ypos));
        }
        public GameObject CreatePowerup(float x)
        {
            int ypos = _random.Next(0, 2);
            return new PowerUp(this._content.Load<Texture2D>("Objects/hearth"), new Vector2(x, ypos));

        }
            public GameObject CreateFrontCloud(float x)
        {
            return new Clouds(this._content.Load<Texture2D>("Background/cloud"), x);
        }
        
        
       
       
    }
}