using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace HeliDoger.Animations
{
    class Animation     //source: video of the teacher on digitap
    {

        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> _frames;
        private double _frameMovement = 0;
        private int _counter;
        private int _fps;

        public Animation(int fps)
        {
            _frames = new List<AnimationFrame>();
            _fps = fps;
        }

        public void AddFrame(AnimationFrame frame)
        {
            _frames.Add(frame);
            CurrentFrame = _frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = _frames[_counter];
            _frameMovement += CurrentFrame.OriginRectangle.Width * 
                gameTime.ElapsedGameTime.TotalSeconds;
            if (_frameMovement >= CurrentFrame.OriginRectangle.Width / _fps)
            {
                _counter++;
                _frameMovement = 0;
            }

            if (_counter >= _frames.Count)
            {
                _counter = 0;
            }
        }
    }
}