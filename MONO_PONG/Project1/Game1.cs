using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Sprites;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace Project1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        public static int _sW = 800;
        public static int _sH = 600;

        private List<Sprite> _sprites;

        public static Random random;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MONO-PONG";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = _sW;
            _graphics.PreferredBackBufferHeight = _sH;
            _graphics.ApplyChanges();
            random = new Random();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            var ballJPG = Content.Load<Texture2D>("ball");
            var playerJPG = Content.Load<Texture2D>("bat");

            _sprites = new List<Sprite>()
            {
                new Ball(ballJPG)
                {
                    Position = new Vector2((_sW / 2) - (ballJPG.Width / 2), (_sH / 2) - (ballJPG.Height / 2)),
                },
            };
            

            /*

            _sprite1 = new Sprite(player)
            {
                Position = new Vector2(_sW - 25 - player.Width, _sH/2-(player.Height/2)),
                Player = 2,
            };
            _sprite2 = new Sprite(player)
            {
                Position = new Vector2(25 + player.Width, _sH / 2 - (player.Height / 2)),
                Player = 1,
            };
            */


        }

        protected override void Update(GameTime gameTime)
        {
            foreach(var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }
        
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            foreach(var sprite in _sprites)
            {
                sprite.Draw(_spriteBatch);
            }
            /*
            _sprite1.Draw(_spriteBatch);
            _sprite2.Draw(_spriteBatch);
            */
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}