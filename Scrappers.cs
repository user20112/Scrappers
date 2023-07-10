using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Scrappers.Abstracts;
using Scrappers.Managers;
using Scrappers.Screens;
using System;
using System.Collections.Generic;

namespace Scrappers
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Scrappers : Game
    {
        public static ContentManager ContentManager;
        public static double Height;
        public static Scrappers Instance;
        public static Random Random = new();
        public static double Width;
        public SpriteBatch _nativeTargetSpriteBatch;
        public GraphicsDeviceManager Graphics;
        private RenderTarget2D _nativeRenderingTarget;
        private List<ScreenBase> _screenStack = new();

        public Scrappers()
        {
            Instance = this;
            ContentManager = Content;
            Graphics = new GraphicsDeviceManager(this);
            MyraEnvironment.Game = this;
            MyraAnimationManager.Init();
            Content.RootDirectory = "Content";
            Window.AllowUserResizing = true;
            SetFullScreen(true);
            PushScreen(new StartScreen());
            _nativeRenderingTarget = new RenderTarget2D(GraphicsDevice, 1920, 1080);
        }

        public void PopScreen()
        {
            if (_screenStack.Count > 0)
            {
                _screenStack[^1].Dispose();
                _screenStack.RemoveAt(_screenStack.Count - 1);
            }
        }

        public void PushScreen(ScreenBase screen)
        {
            if (!_screenStack.Contains(screen))
            {
                _screenStack.Add(screen);
            }
            else
            {
                throw new Exception("This screen instance is already here ?");
            }
        }

        public void SetFullScreen(bool value)
        {
            Graphics.HardwareModeSwitch = false;
            Graphics.IsFullScreen = value;
            Graphics.ApplyChanges();
        }

        internal static Tuple<double, double> GetMousePosition()
        {
            Vector2 Position = Mouse.GetState().Position.ToVector2();
            return new Tuple<double, double>(Position.X / Width, Position.Y / Height);
        }

        internal void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle rectangle, Color tintColor, float rotation, Vector2 origin, SpriteEffects none, float adjustedLayerDepth)
        {
            _nativeTargetSpriteBatch.Draw(texture, destinationRectangle, rectangle, tintColor, rotation, origin, none, adjustedLayerDepth);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // first draw to the render target.
            GraphicsDevice.SetRenderTarget(_nativeRenderingTarget);
            GraphicsDevice.Clear(Color.Black);
            Height = GraphicsDevice.Viewport.Height;
            Width = GraphicsDevice.Viewport.Width;
            // draw the top level screen
            _screenStack[^1].Draw(gameTime, _nativeTargetSpriteBatch);

            // reset the render target to the back buffer
            GraphicsDevice.SetRenderTarget(null);

            //render target to back buffer
            _nativeTargetSpriteBatch.Begin();
            _nativeTargetSpriteBatch.Draw(_nativeRenderingTarget, new Rectangle(0, 0, GraphicsDevice.DisplayMode.Width, GraphicsDevice.DisplayMode.Height), Color.White);
            _nativeTargetSpriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _nativeTargetSpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            foreach (ScreenBase screen in _screenStack)
                screen.Dispose();
            ContentManager.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();
            _screenStack[^1].Update(gameTime);
            base.Update(gameTime);
        }

        private static float NextFloat(float min, float max)
        {
            double val = (Random.NextDouble() * (max - min) + min);
            return (float)val;
        }
    }
}