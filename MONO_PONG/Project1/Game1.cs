using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Sprites;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public int _sW = 800;
        public int _sH = 600;

        private Sprite _sprite1;
        private Sprite _sprite2;

        private List<Sprite> _sprites;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var player = Content.Load<Texture2D>("bat");
            var ball = Content.Load<Texture2D>("ball");

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
            


        }

        protected override void Update(GameTime gameTime)
        {
            _sprite1.Update();
            _sprite2.Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _sprite1.Draw(_spriteBatch);
            _sprite2.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}