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
    public  class FactoryPowerup 
    {
        private ContentManager _content;
        private Random _random = new Random();
        public FactoryPowerup(ContentManager content)
        {
            this._content = content; 
        }
        public GameObject CreateEnemy(float x)
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



    }
}