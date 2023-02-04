using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Project1.Sprites
{
    public class Player : Sprite
    {
        public Player(Texture2D texture)
            : base(texture)
        {
            speed = 3f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            if (Keyboard.GetState().IsKeyDown(input.up))
            {
                Position.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(input.down))
            {
                Position.Y += speed;
            }

            Position.Y = MathHelper.Clamp(Position.Y, 0, Game1._sH - _texture.Height);
        }
    }
}
