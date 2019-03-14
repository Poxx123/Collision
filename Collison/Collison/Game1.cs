using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Collison
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
       
        Rectangle play1Bound, play2Bound;
        Texture2D player1, player2;
        Vector2 play1pos, play2pos;
        bool backgroundChange;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            play1pos = new Vector2(0, 0);
            play2pos = new Vector2(250, 250);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player1 = Content.Load<Texture2D>("green");
            player2 = Content.Load<Texture2D>("blue");
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

           var keyPushed = Keyboard.GetState();
            if (keyPushed.IsKeyDown(Keys.Up))
                play1pos.Y -= 10;

            if (keyPushed.IsKeyDown(Keys.Down))
                play1pos.Y += 10;

            if (keyPushed.IsKeyDown(Keys.Left))
                play1pos.X -= 10;

            if (keyPushed.IsKeyDown(Keys.Right))
                play1pos.X += 10;

            play1Bound = new Rectangle((int)play1pos.X, (int)play1pos.Y, player1.Width, player1.Height);
            play2Bound = new Rectangle((int)play2pos.X, (int)play2pos.Y, player2.Width, player2.Height);

            if (play1Bound.Intersects(play2Bound))
            {
                backgroundChange = true;
            }
            else
            {
                backgroundChange = false;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if(backgroundChange)
            {
                GraphicsDevice.Clear(Color.Red);
            }
            else
                {
                GraphicsDevice.Clear(Color.Brown);
            }
            spriteBatch.Draw(player1, play1pos, Color.White);
            spriteBatch.Draw(player2, play2pos, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
