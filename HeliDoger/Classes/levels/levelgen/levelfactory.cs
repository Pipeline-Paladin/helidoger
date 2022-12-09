using HeliDoger.Classes.enemy;
using HeliDoger.Classes.Interfaces;
using HeliDoger.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliDoger.Classes.levels.levelgen
{
    class levelfactory // Design: factory pattern
    {
        private ContentManager _content;
        private Random _random = new Random();

        public levelfactory(ContentManager content)
        {
            this._content = content;
        }

        public IGameObject CreateTile(float x, bool top)
        {
            var yPos = Game1.ScreenHeight / 2;

            var pos = new Vector2(x, top ? -yPos : yPos);
            var wall = new Wall(this._content.Load<Texture2D>("Objects/TileGuud"), pos);

            if (!top) wall.Position -= new Vector2(0, wall.Size.Y);

            return wall;
        }
        public IGameObject CreateEnemy(float x)
        {
            int type = _random.Next(0, 4);
            IEnemy enemy = null;

            if (type == 0)
            {
                enemy = new Bird(this._content.Load<Texture2D>("Objects/jelly"));
            }
            return enemy;
        }
    }
}
