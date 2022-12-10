using System;
using HeliDoger;
using Microsoft.Xna.Framework;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes
{
    public class LevelGen 
    {
        private const double MIN_ENEMY_DIST = 0.5; // Times ScreenWidth
        private const double MAX_ENEMY_DIST = 1.5;

        private const double MAX_BOTTLE_DIST = 5;
        private const double MIN_BOTTLE_DIST = 1;
        private Random _rand;

        private IScreen _screen;
        private LevelFactory _factory;

        private float _xLocation = -Game1.ScreenWidth;
        private float _nextEnemy;
        private float _nextBottle;


        public LevelGen(IScreen screen, LevelFactory factory)
        {
            this._screen = screen;
            this._factory = factory;
            this._rand = new Random();
            this.Init();
        }

        private void Init()
        {
            while(this._xLocation <= Game1.ScreenWidth * 2)
            {
                this.CreateBounds();
            }
            this._nextEnemy = this._xLocation;
            this._nextBottle = this._xLocation;
        }

        private void CreateBounds()
        {
            var ceiling = this._factory.CreateTile(this._xLocation, true);
            var floor = this._factory.CreateTile(this._xLocation, false);
            this._screen.GameObjects.Add(ceiling);
            this._screen.GameObjects.Add(floor);
            this._xLocation = ceiling.Position.X + ceiling.Size.X;
        }

        private void NextBottle()
        {
            var factor = Convert.ToSingle((this._rand.NextDouble() + 
                (MAX_BOTTLE_DIST - MIN_BOTTLE_DIST)) + MAX_BOTTLE_DIST);
            this._nextBottle += factor * Game1.ScreenWidth;
        }


        private void NextEnemy()
        {
            var factor = Convert.ToSingle((this._rand.NextDouble() +
                (MAX_ENEMY_DIST - MIN_ENEMY_DIST) ) + MIN_ENEMY_DIST); //making sure there are no instant enemy spawns
            this._nextEnemy += factor * Game1.ScreenWidth;
        }

        public void Update(Vector2 playerPosition)
        {
            this.Update(playerPosition.X);
        }

        private void Update(float x) 
        {
            while(this._xLocation - x <= Game1.ScreenWidth * 2)
            {
                this.CreateBounds();
                while(this._xLocation >= this._nextEnemy)
                {
                    var enemy = this._factory.CreateEnemy(this._nextEnemy);
                    this._screen.GameObjects.Add(enemy);
                    //var bottle = this._factory.CreateBottle(this._nextBottle);
                    //this._screen.GameObjects.Add(bottle);

                    this.NextEnemy();
                    this.NextBottle();
                }
            }
            
            // Remove out of screen gameobjects
            this._screen.GameObjects.RemoveAll(obj => x - obj.Position.X >= Game1.ScreenWidth * 2);
        }
    }
}
