using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

       
        Random random = new Random();

        private Sprite _p1;
        private Sprite _p2;
        private Sprite _ball;
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

            var bat = Content.Load<Texture2D>("bat");
            var ball = Content.Load<Texture2D>("ball");

            _p1 = new Sprite(bat, 1);
            _p1.Position = new Vector2(25, ((_sH/2) - 50));
            _p2 = new Sprite(bat, 2);
            _p2.Position = new Vector2((_sW - 50), ((_sH / 2) - 50));
            _ball = new Sprite(ball, 0);
            _ball.Position = new Vector2((_sW / 2) - (25 / 2), (_sH / 2) - (25 / 2));


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _p1.Update();
            _p2.Update();
            _ball.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _p1.Draw(_spriteBatch);
            _p2.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}