using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using HeliDoger.abstractclasses;

namespace HeliDoger
{
    public class Button : StaticObject
    {
        private Texture2D _buttonTexture;
        private Rectangle _buttonRectangle;
        private Color _buttonColor = new Color(255, 255, 255, 255);
        private bool _down;
        private SoundEffect _effect;

        public bool IsClicked { get; private set; }

        public Action ClickAction { get; set; } = () => { };

        public Button(Texture2D texture, Rectangle buttonRect)
        {
            _buttonTexture = texture;
            _buttonRectangle = buttonRect;
        }

        public override void Update(GameTime time, MouseState mouse)
        {
            Rectangle mouseRect = new Rectangle(mouse.X, mouse.Y, 1, 1); // rectangle of the mouse

            if (mouseRect.Intersects(_buttonRectangle))  //breathing button
            {
                if (_buttonColor.R == 255)
                    _down = false;

                if (_buttonColor.R == 0)
                    _down = true;

                if (_down)
                    _buttonColor.R += 3;
                else
                    _buttonColor.R -= 3;

                if (mouse.LeftButton == ButtonState.Pressed) //check if mouse clicks on button
                {
                    ClickAction.Invoke();
                    IsClicked = true;
                }
            }
            else if (_buttonColor.R < 255)
            {
                _buttonColor.R += 3;
                IsClicked = false;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_buttonTexture, _buttonRectangle, _buttonColor);
        }

    }

}