using Microsoft.Xna.Framework;

namespace HeliDoger.Animations
{
    class AnimationFrame       
    {
        public Rectangle OriginRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            OriginRectangle = rectangle;
        }

    }
}