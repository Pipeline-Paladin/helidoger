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
using HeliDoger.Classes.Objects.Powerups;

namespace HeliDoger.Classes
{
    public class MainLevelFactory 
    {//factory patren
        private ContentManager _content;
        private Random _random = new Random();
        public MainLevelFactory(ContentManager content)
        {
            this._content = content; 
        }
        public GameObject CreateEnemy(float x)
        {
            int rando = _random.Next(0, 3); 
            Enemy enemy =null;

            switch (rando)
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
            int rando = _random.Next(0, 3);
            StaticObject powerup = null;

            int ypos = _random.Next(0, 2);

            switch (rando)
            {
                case 0:
                    powerup = new ExtralifePowerUp(this._content.Load<Texture2D>("Objects/hearth"), new Vector2(x, ypos)); ;
                    break;

                case 1:
                    powerup = new invincebillityPowerup(this._content.Load<Texture2D>("Objects/star"), new Vector2(x, ypos));
                    break;
                case 2:
                    powerup = new SlowDownPower(this._content.Load<Texture2D>("Objects/SlowDown"), new Vector2(x, ypos));
                    break;
            }
            return powerup;

        }
        public GameObject CreateFrontCloud(float x)
        {
            return new Clouds(this._content.Load<Texture2D>("Background/cloud"), x);
        }


        public GameObject CreateTile(float x, bool top)
        {
            var yPos = Game1.ScreenHeight / 2;
            Vector2 pos;
            if (top)
            {
                pos = new Vector2(x, -yPos);
            }
            else
            {
                pos = new Vector2(x, yPos);
            }
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

    }
}