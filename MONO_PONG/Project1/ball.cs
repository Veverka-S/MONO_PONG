using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class ball
    {
        private Texture2D _texture;
        private int balldx, balldy, ballw, ballh, index, index2, ballx, bally;
        private Vector2 position;

        List<int> dir = new List<int>() { -1, 1 };

        Random random = new Random();

        public ball(Texture2D texture) {
            _texture = texture;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, position, Color.White);
        }
    }
}
