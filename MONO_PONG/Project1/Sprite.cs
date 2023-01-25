using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Sprite
    {
        Random random = new Random();
        private Texture2D _texture;
        private float _velocity = 5f;
        private int _player;
        private int ballspeed, xdir, ydir, index1, index2, balldx, balldy;
        private Vector2 _dimensions;
        public Vector2 Position;

        private KeyboardState key;

        List<int> dir = new List<int>() { -1, 1 };


        public Sprite(Texture2D texture, int player)
        {
            _texture = texture;
            _player = player;
            ballspeed = random.Next(5, 10);
            index1 = random.Next(dir.Count());
            index2 = random.Next(dir.Count());
            xdir = dir[index1];
            ydir = dir[index2];
            balldx = xdir * ballspeed;
            balldy = ydir * ballspeed;
        }

        public void Update()
        {
            switch (_player)
            {
                case 0:
                    Position.X += balldx;
                    Position.Y += balldy;
                    if(Position.X < 0)
                    {
                        Position.X = 0;
                        balldx *= -1;
                    }
                    if(Position.X > 800 - _texture.Width)
                    {
                        Position.X = 800 - _texture.Width;
                        balldx *= -1;
                    }
                    if(Position.Y < 0)
                    {
                        Position.Y = 0;
                        balldy *= -1;
                    }
                    if(Position.Y > 600 - _texture.Height)
                    {
                        Position.Y = 600 - _texture.Height;
                        balldy *= -1;
                    }
                    break;
                case 1:
                    if (Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        Position.Y -= _velocity;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        Position.Y += _velocity;
                    }
                    if (Position.Y < 0)
                    {
                        Position.Y = 0;
                    }
                    if (Position.Y > 600 - _texture.Height)
                    {
                        Position.Y = 600 - _texture.Height;
                    }
                    break;
                case 2:
                    if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    {
                        Position.Y -= _velocity;
                    }

                    if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    {
                        Position.Y += _velocity;
                    }

                    if(Position.Y < 0)
                    {
                        Position.Y = 0;
                    }
                    if(Position.Y > 600 - _texture.Height)
                    {
                        Position.Y = 600 - _texture.Height;
                    }
                    break;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

    }
}
