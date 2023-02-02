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
    public class Ball : Sprite
    {
        private Vector2? _startPosition = null;
        private float? _startSpeed;

        public Ball(Texture2D texture)
            : base(texture)
        {
            speed = 4f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
           if(_startPosition == null)
            {
                _startPosition = Position;
                _startSpeed = speed;

                start();
            } 
           


            Position += v * speed;

            if(Position.Y < 0 || Position.Y > -_texture.Height + Game1._sH)
            {
                v.Y *= -1;
            }

            if (Position.X < 0 || Position.X > Game1._sW - _texture.Width)
            {
                restart();
            }

            foreach(var sprite in sprites)
            {
                if(sprite == this)
                {
                    continue;
                }

                if(this.IsTouchingLeft(sprite) || this.IsTouchingRight(sprite))
                {
                    this.v.X *= -1;
                }
                if (this.IsTouchingBottom(sprite) || this.IsTouchingTop(sprite))
                {
                    this.v.Y *= -1;
                }
            }

        }

        public void restart()
        {
            speed = Game1.random.Next(4, 6);
            Position = new Vector2((Game1._sW / 2) - (_texture.Width / 2), (Game1._sH / 2) - (_texture.Height / 2));
            start();
        }

        public void start()
        {
            var dir = Game1.random.Next(0, 4);

            switch (dir)
            {
                case 0:
                    v = new Vector2(1, 1);
                    break;
                case 1:
                    v = new Vector2(1, -1);
                    break;
                case 2:
                    v = new Vector2(-1, 1);
                    break;
                case 3:
                    v = new Vector2(-1, -1);
                    break;
            }
        }

    }

}
