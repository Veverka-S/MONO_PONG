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
        private Texture2D _texture;
        public Vector2 Position;
        public int Player;
        public float v = 4f;

        public Input input;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update()
        {
            if (Player == 2)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    Position.Y -= v;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    Position.Y += v;
                }
            }
            else if (Player == 1)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    Position.Y -= v;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    Position.Y += v;
                }
            }

            if (Player != 0)
            {
                if(Position.Y < 0)
                {
                    Position.Y = 0;
                }

                if (Position.Y > 600 - _texture.Height)
                {
                    Position.Y = 600 - _texture.Height;
                }
            }

        }

        protected bool isTouchingLeft(Sprite sprite)
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
