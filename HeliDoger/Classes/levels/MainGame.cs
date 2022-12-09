using HeliDoger.Classes.levels.background;
using HeliDoger.Classes.player;
using HeliDoger.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HeliDoger.Animations;
using SharpDX.Direct3D9;
using HeliDoger.Classes.Interfaces;
using HeliDoger.Classes.enemy;

namespace HeliDoger.Classes.levels
{
    internal class MainGame : IScreen
    {

        //Varables
        private Player _player;
        private skybox _background;
        private int gravity = 50;
        private int playerspeed = 100;
        Bird bird;
        public MainGame(ContentManager content) : base(content)
        {
           
            _player = new Player(_content.Load<Texture2D>("player/helicopter"));
            GameObjects.Add(_player);
            _background = new skybox(content);
            bird = new Bird(this._content.Load<Texture2D>("enemy/bird"));
            bird.LoadContent(content);
        }
        public override void Update(GameTime time, MouseState mouse)
        {
            base.Update(time, mouse);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _player.Move(0, -playerspeed-gravity);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _player.Move(0, playerspeed);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _player.Move(playerspeed, 0);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _player.Move(-playerspeed, 0);

            }
            //gravity
            _player.Move(0, gravity);
        }
        public override void initobj()
        {

           


        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(_background.sky, _background.positionSky, Color.White);
            spriteBatch.Draw(_background.ground, _background.positionGround, Color.White);
            spriteBatch.Draw(_player._texture, _player.Position, _player.Animation.CurrentFrame.OriginRectangle,Color.White, 0f, Vector2.Zero, 0.6f, SpriteEffects.None, 0f);

        }
    }
}
