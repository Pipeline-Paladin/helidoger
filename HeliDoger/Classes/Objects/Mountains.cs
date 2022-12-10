using System.Linq;
using HeliDoger;
using Microsoft.Xna.Framework;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes
{
    public class Mountains //cats
    {
        private IScreen _screen;
        private LevelFactory _factory;
        private float _xLocation = -Game1.ScreenWidth * 2;

        public Mountains(IScreen screen, LevelFactory factory)
        {
            this._screen = screen;
            this._factory = factory;
            this.Init();
        }

        private void Init()
        {
            while(this._xLocation <= Game1.ScreenWidth * 2)
            {
                var obj = this._factory.CreateMountain(this._xLocation);
                this._screen.GameObjects.Add(obj);
                this._xLocation += obj.Size.X;
            }
        }

        public void Update(Vector2 position)
        {
            this.Update(position.X);
        }

        private void Update(float x)
        {
            var furthest = this._screen.GameObjects.Where(x => x is Mountain)
                .OrderByDescending(x => x.Position.X).First();

            this._xLocation = furthest.Position.X + furthest.Size.X;

            while(this._xLocation - x <= Game1.ScreenWidth * 2)
            {
                var obj = this._factory.CreateMountain(this._xLocation);
                this._screen.GameObjects.Add(obj);
                this._xLocation += obj.Size.X;
            }
        }
    }
}