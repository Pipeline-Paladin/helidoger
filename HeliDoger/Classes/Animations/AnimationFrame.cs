using Microsoft.Xna.Framework;

namespace HeliDoger.Animations
{
    class AnimationFrame        //source: video of the teacher on digitap
    {
        public Rectangle OriginRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            OriginRectangle = rectangle;
        }

    }
}