using System;
using HeliDoger;
using Microsoft.Xna.Framework;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes
{
    public class LevelGen 
    {
        private Random _rand;
        private Screen _screen;
        private ReturnFactory _factory;

        private float _xScreenWidth = -Game1.ScreenWidth;
        private float _Nenemy;
        private float _Ncoin;
        private float _Npower;
        private int _enemydiff;
        private int _powerdiff;
        private int _coindiff;
        public LevelGen(Screen screen, ReturnFactory factory, int enemydiff, int powerdiff, int coindiff)
        {
            this._screen = screen;
            this._factory = factory;

            _enemydiff = enemydiff;
            _powerdiff = powerdiff;
            _coindiff = coindiff;

            this._rand = new Random();
            this.Init();
        }

        private void Init()
        {
            while(this._xScreenWidth <= Game1.ScreenWidth * 2)
            {
                this.CreateBounds();
            }
            this._Nenemy = this._xScreenWidth;
            this._Ncoin = this._xScreenWidth;
        }

        private void CreateBounds()
        {
            var ceiling = this._factory.CreateTile(this._xScreenWidth, true);
            var floor = this._factory.CreateTile(this._xScreenWidth, false);
            this._screen.GameObjects.Add(ceiling);
            this._screen.GameObjects.Add(floor);
            this._xScreenWidth = ceiling.Position.X + ceiling.Size.X;
        }

        private void NextCoin()
        {
            var factor = Convert.ToSingle((this._rand.NextDouble() + _coindiff));
            this._Ncoin += factor * Game1.ScreenWidth;
        }
        private void NextPowerup()
        {
            var factor = Convert.ToSingle((this._rand.NextDouble() + _powerdiff));
            this._Npower += factor * Game1.ScreenWidth;
        }

        private void NextEnemy()
        {
            var space = Convert.ToSingle((this._rand.NextDouble() + _enemydiff)); 
            this._Nenemy += space * Game1.ScreenWidth;
        }

        public void Update(Vector2 playerPosition)
        {
            this.Update(playerPosition.X);
        }

        private void Update(float x) 
        {
           
                this.CreateBounds();
                while(this._xScreenWidth >= this._Nenemy)
                {
                    var enemy = this._factory.CreateEnemy(this._Nenemy);
                    var coin = this._factory.CreateCoin(this._Ncoin);
                    var powerup = this._factory.CreatePowerup(this._Npower);
                   
                    this._screen.GameObjects.Add(enemy);
                    this._screen.GameObjects.Add(coin);
                    this._screen.GameObjects.Add(powerup);
                    this.NextEnemy();
                    this.NextCoin();
                    this.NextPowerup();
                }
            
          
               this._screen.GameObjects.RemoveAll(obj => x - obj.Position.X >= Game1.ScreenWidth * 2);
         
           
        }
    }
}
