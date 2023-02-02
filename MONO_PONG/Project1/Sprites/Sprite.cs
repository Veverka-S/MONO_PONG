using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Xml;
using Project1;
using Project1.Models;

namespace Project1.Sprites
{
    public class Sprite
    {
        public Texture2D _texture;
        public Vector2 Position;
        public Vector2 v;
        public float speed;

        public Input input;

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
          

        }

        protected bool IsTouchingLeft(Sprite sprite)
        {
            return this.rectangle.Right + this.v.X > sprite.rectangle.Left &&
              this.rectangle.Left < sprite.rectangle.Left &&
              this.rectangle.Bottom > sprite.rectangle.Top &&
              this.rectangle.Top < sprite.rectangle.Bottom;
        }

        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.rectangle.Left + this.v.X < sprite.rectangle.Right &&
              this.rectangle.Right > sprite.rectangle.Right &&
              this.rectangle.Bottom > sprite.rectangle.Top &&
              this.rectangle.Top < sprite.rectangle.Bottom;
        }

        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.rectangle.Bottom + this.v.Y > sprite.rectangle.Top &&
              this.rectangle.Top < sprite.rectangle.Top &&
              this.rectangle.Right > sprite.rectangle.Left &&
              this.rectangle.Left < sprite.rectangle.Right;
        }

        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.rectangle.Top + this.v.Y < sprite.rectangle.Bottom &&
              this.rectangle.Bottom > sprite.rectangle.Bottom &&
              this.rectangle.Right > sprite.rectangle.Left &&
              this.rectangle.Left < sprite.rectangle.Right;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
