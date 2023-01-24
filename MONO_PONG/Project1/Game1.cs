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

        private int _sW = 800;
        private int _sH = 600;
        private Texture2D _p1, _p2, _ball;

        public MouseState mouse;

        private int x1, y1, x2, y2, bW, bH, v;

        private int ballW, ballH, xb, yb, xdir, ydir, index, index2, ballspeed, balldx, balldy;

        private int score1, score2;
        List<int> dir = new List<int>() { -1, 1 };

        Random random = new Random();
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "MONO-PONG";
            IsMouseVisible = true;
        }

        public void Ball()
        {
            ballW = 25;
            ballH = ballW;

            xb = (_sW / 2) - (ballW / 2);
            yb = (_sH / 2) - (ballW / 2);

            ballspeed = random.Next(5, 7);

            index = random.Next(dir.Count);
            index2 = random.Next(dir.Count);

            xdir = dir[index];
            ydir = dir[index2];

            balldx = ballspeed * xdir;
            balldy = ballspeed * ydir;

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

            
            _p1 = Content.Load<Texture2D>("bat");
            _p2 = Content.Load<Texture2D>("bat");
            _ball = Content.Load<Texture2D>("ball");

            v = 10;
            bW = 25;
            bH = 100;
            x1 = 25;
            y1 = (_sH / 2) - (bH/2);
            x2 = _sW - (bW*2);
            y2 = (_sH / 2) - (bH/2);
            Ball();



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState pressed = Keyboard.GetState();
            mouse = Mouse.GetState();
            #region _p2

            if (pressed.IsKeyDown(Keys.Up))
            {
                y2 -= v;
                if(y2 < 0)
                {
                    y2 = 0;
                }
            }
            if (pressed.IsKeyDown(Keys.Down))
            {
                y2 += v;
                if(y2 > _sH - bH)
                {
                    y2 = _sH - bH;
                }
            }

            #endregion
            #region _p1
            if (pressed.IsKeyDown(Keys.W))
            {
                y1 -= v;
                if (y1 < 0)
                {
                    y1 = 0;
                }
            }
            if (pressed.IsKeyDown(Keys.S))
            {
                y1 += v;
                if (y1 > _sH - bH)
                {
                    y1 = _sH - bH;
                }
            }
            #endregion

            #region míč 
            xb += balldx;
            yb += balldy;

            if(yb > _sH - ballW)
            {
                balldy *= -1;
            }
            if (yb < 0)
            {
                balldy *= -1;
            }

            #region kolize-ghetto
            if (xb < x1 + bW && xb > x1 && yb > y1 && yb < y1 + bH)
            {
                xb = x1 + bW;
                balldx *= -1;
            }
            if (xb > x2 - bW && xb < x2 + bW && yb > y2 && yb < y2 + bH)
            {
                xb = x2 - bW;
                balldx *= -1;
            }
            #endregion




            if (xb < 0)
            {
                score1 += 1;
                Ball();
            }
            if(xb > _sW - ballW)
            {
                score2 += 1;
                Ball();
            }
            #endregion
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_p1, new Vector2(x1, y1), Color.White);
            _spriteBatch.Draw(_p2, new Vector2(x2, y2), Color.White);
            _spriteBatch.Draw(_ball, new Vector2(xb, yb), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}