using System.Linq;
using Microsoft.Xna.Framework;

using HeliDoger.abstractclasses;

namespace HeliDoger.Classes.background
{
    public class BackClouds
    {
        private Screen _screen;
        private ReturnFactory _factory;
        private float _xLocation = -Game1.ScreenWidth * 2;

        public BackClouds(Screen screen, ReturnFactory factory)
        {
            _screen = screen;
            _factory = factory;
            Init();
        }

        private void Init()
        {
            while (_xLocation <= Game1.ScreenWidth * 2)
            {
                var obj = _factory.CreateFrontCloud(_xLocation);
                _screen.GameObjects.Add(obj);
                _xLocation += obj.Size.X;
            }
        }

        public void Update(Vector2 position)
        {
            Update(position.X);
        }

        private void Update(float x)
        {
            var furthest = _screen.GameObjects.Where(x => x is Clouds)
                .OrderByDescending(x => x.Position.X).First();

            _xLocation = furthest.Position.X + furthest.Size.X;

            while (_xLocation - x <= Game1.ScreenWidth * 2)
            {
                var obj = _factory.CreateFrontCloud(_xLocation);
                _screen.GameObjects.Add(obj);
                _xLocation += obj.Size.X;
            }
        }
    }
}