using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoPong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        public static int ScreenWith;
        public static int ScreenHeight;

        const int PADDLE_OFFSET = 70;   //margen de la representación del jugador con los bordes de la pantalla.
        const float BALL_START_SPEED = 8f;
        const float KEYBOARD_PADDLE_SPEED = 10f;

        Player player1;
        Player player2;
        Ball ball;


        KeyboardState actualKeyboardState;
        KeyboardState anteriorKeyboardState;
        GamePadState actualGamePadState;
        GamePadState anteriorGamePadState;

        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ScreenWith = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            player1 = new Player();
            player2 = new Player();
            ball = new Ball();
            //jugador = new Jugador();
            //jugadorVelocidadMovimiento = 8.0f;
            //TouchPanel.EnabledGestures = GestureType.FreeDrag;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            player1.Texture = Content.Load<Texture2D>("Graphics\\Jugador1");
            player2.Texture = Content.Load<Texture2D>("Graphics\\Enemigo");

            player1.Position = new Vector2(PADDLE_OFFSET, ScreenHeight / 2 - player1.Texture.Height / 2);
            player2.Position = new Vector2(ScreenWith - player2.Texture.Width - PADDLE_OFFSET, ScreenHeight / 2 - player2.Texture.Height / 2);

            ball.Texture = Content.Load<Texture2D>("Graphics\\Pelota");
            //ball.Position = new Vector2(ScreenWith / 2 - ball.Texture.Width /2, ScreenHeight / 2 - ball.Texture.Height / 2);
            ball.Launch(BALL_START_SPEED);

            //Vector2 posicionJugador = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X,
            //        GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);

            //jugador.inicializar(Content.Load<Texture2D>("Graphics\\Jugador1"), posicionJugador);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            ScreenWith = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            ball.Move(ball.Velocity);

            Vector2 player1Velocity = Input.GetKeyboardInputDirection(PlayerIndex.One) * KEYBOARD_PADDLE_SPEED;
            Vector2 player2Velocity = Input.GetKeyboardInputDirection(PlayerIndex.Two) * KEYBOARD_PADDLE_SPEED;

            player1.Move(player1Velocity);
            player2.Move(player2Velocity); 


            //Movimiento para pantallas tactiles.
            Vector2 player1TouchVelocity, player2TouchVelocity;
            Input.ProcessTouchInput(out player1TouchVelocity, out player2TouchVelocity);

            player1.Move(player1TouchVelocity);
            player2.Move(player2TouchVelocity);

            if (GameObject.CheckPaddleBallCollision(player1, ball))
            {
                ball.Velocity.X = Math.Abs(ball.Velocity.X);
            }

            if (GameObject.CheckPaddleBallCollision(player2, ball))
            {
                ball.Velocity.X = -Math.Abs(ball.Velocity.X);
            }

            if (ball.Position.X + ball.Texture.Width < 0)
            {
                ball.Launch(BALL_START_SPEED);                
            }

            if (ball.Position.X > Game1.ScreenWith)
            {
                ball.Launch(BALL_START_SPEED);                
            }

            //anteriorGamePadState = actualGamePadState;
            //anteriorKeyboardState = actualKeyboardState;

            //actualKeyboardState = Keyboard.GetState();
            //actualGamePadState = GamePad.GetState(PlayerIndex.One);

            UpdatePlayer(gameTime);
            base.Update(gameTime);
        }

        private void UpdatePlayer(GameTime gameTime)
        {
            // Get Thumbstick Controls
            //jugador.Posicion.X += actualGamePadState.ThumbSticks.Left.X * jugadorVelocidadMovimiento;
            //jugador.Posicion.Y -= actualGamePadState.ThumbSticks.Left.Y * jugadorVelocidadMovimiento;

            ////Get Keyboard / Dpad
            //if (actualKeyboardState.IsKeyDown(Keys.Up) || actualGamePadState.DPad.Up == ButtonState.Pressed)
            //{
            //    jugador.Posicion.Y -= jugadorVelocidadMovimiento;
            //}

            //if (actualKeyboardState.IsKeyDown(Keys.Down) || actualGamePadState.DPad.Down == ButtonState.Pressed)
            //{
            //    jugador.Posicion.Y += jugadorVelocidadMovimiento;
            //}

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            player1.Draw(_spriteBatch);
            player2.Draw(_spriteBatch);
            ball.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
