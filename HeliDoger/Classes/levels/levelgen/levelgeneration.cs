using HeliDoger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliDoger.Classes.levels.levelgen
{
    class levelgeneration
    {
        //varable
        private IScreen _screen;
        private levelfactory _factory;
        private Random _random;
        private float _xLocation = -Game1.ScreenWidth;
        private float _nextEnemy;
        public levelgeneration(IScreen screen, levelfactory factory)
        {
            this._screen = screen;
            this._factory = factory;
            this._random = new Random();
            this.Init();
        }
        private void Init()
        {
            while (this._xLocation <= Game1.ScreenWidth * 2)
            {
                this.CreateBounds();
            }
            //this._nextEnemy = this._xLocation;
            //this._nextBottle = this._xLocation;
        }
        private void CreateBounds()
        {
            var ceiling = this._factory.CreateTile(this._xLocation, true);
            var floor = this._factory.CreateTile(this._xLocation, false);
            this._screen.GameObjects.Add(ceiling);
            this._screen.GameObjects.Add(floor);
            this._xLocation = ceiling.Position.X + ceiling.Size.X;
        }

        private void GenEnemy()
        {
            _factory.CreateEnemy(1);
        }
        private void Update(float x)
        {
            while (this._xLocation - x <= Game1.ScreenWidth * 2)
            {
                this.CreateBounds();
                while (this._xLocation >= this._nextEnemy)
                {
                    var enemy = this._factory.CreateEnemy(this._nextEnemy);
                    this._screen.GameObjects.Add(enemy);

             

                }

                // Remove out of screen gameobjects
                this._screen.GameObjects.RemoveAll(obj => x - obj.Position.X >= Game1.ScreenWidth * 2);
            }
        }
    }
}
