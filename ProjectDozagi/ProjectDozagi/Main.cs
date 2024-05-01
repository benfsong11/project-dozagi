using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectDozagi.Components.World;
using ProjectDozagi.Engine.Cores;
using ProjectDozagi.Engine.Cores.Inputs;
using ProjectDozagi.Engine.Cores.Sprites;

namespace ProjectDozagi
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private World _world;
        private Sprite2D _cursor;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Global.ScreenSize = new System.Drawing.Size(1366, 768);
            
            _graphics.PreferredBackBufferWidth = Global.ScreenSize.Width;
            _graphics.PreferredBackBufferHeight = Global.ScreenSize.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Global.Content = Content;
            Global.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Global.KeyboardInput = new KeyboardInput();
            Global.MouseInput = new MouseInput();

            // TODO: use this.Content to load your game content here
            _world = new World();
            _cursor = new Sprite2D(
                "Sprites\\CursorArrow", 
                Vector2.Zero, 
                new Vector2(24, 24), 
                new Rectangle((int)Global.MouseInput.Position.X, (int)Global.MouseInput.Position.Y, 24, 24));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Global.KeyboardInput.Update();
            Global.MouseInput.Update();
            Global.GameTime = gameTime;

            // TODO: Add your update logic here
            _world.Update();


            Global.KeyboardInput.OldUpdate();
            Global.MouseInput.OldUpdate();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Global.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            _world.Draw(Vector2.Zero);
            _cursor.Draw(Global.MouseInput.Position, Vector2.Zero);

            Global.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}