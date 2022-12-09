using HeliDoger.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeliDoger.Classes.Objects
{
     class Coin : IStaticObject
    {

        //varables
        private Texture2D _texture;

        public Coin(Texture2D texture) { 
        _texture = texture;
        }

    }
}
