using HeliDoger.Interfaces;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace HeliDoger.Classes.Interfaces
{
    public abstract class IEnemy : IGameObject
    {

        public override void Update(GameTime gameTime, MouseState mouse) { }
        public override void Draw(SpriteBatch spritebatch) { }
        public override void OnCollision(IGameObject gameObject){}
    }
}
