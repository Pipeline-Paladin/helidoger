using HeliDoger;
using Microsoft.Xna.Framework;

using HeliDoger.abstractclasses;

namespace HeliDoger
{
    public class Camera
    {
        public Vector2 Position { get; set; } = Vector2.Zero;
        public Camera()
        {
            this.Position = new Vector2(Game1.ScreenWidth, Game1.ScreenHeight) / 2f;
        }

        public Matrix GetTransform()
        {
            Vector2 screenSize = new Vector2(Game1.ScreenWidth, Game1.ScreenHeight);
            Vector2 camPos = screenSize / 2f - this.Position;

            return Matrix.Identity * Matrix.CreateTranslation(camPos.X, camPos.Y, 0);
        }

        public Rectangle GetViewRectangle()
        {
            Vector2 screenSize = new Vector2(Game1.ScreenWidth, Game1.ScreenHeight);
            return new Rectangle(this.Position.ToPoint(), screenSize.ToPoint());
        }

        public bool InView(GameObject obj)
        {
            var rect = obj.GetBounds();
            return !Rectangle.Intersect(rect, this.GetViewRectangle()).IsEmpty;
        }
    }
}
