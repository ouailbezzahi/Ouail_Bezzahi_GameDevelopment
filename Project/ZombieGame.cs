using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.Hero;
using Project.Inputs;
using System;
using System.Reflection.Metadata;

namespace Project
{
    public class ZombieGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Textures voor verschillende animaties
        private Texture2D _idleTexture;
        private Texture2D _walkTexture;
        private Texture2D _shootTexture;
        private Texture2D _jumpTexture;

        //Hero & animanager
        Hero hero;

        public ZombieGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Verschillende animatie-textures
            _idleTexture = Content.Load<Texture2D>("Hero/Hero Idle");
            _walkTexture = Content.Load<Texture2D>("Hero/Hero Walking");
            _shootTexture = Content.Load<Texture2D>("Hero/Hero Walking With Gun");
            _jumpTexture = Content.Load<Texture2D>("Hero/Hero Jump");

            InitializeGameObject();
            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObject()
        {
            // Initialiseer de hero met de juiste animaties
            hero = new Hero(_idleTexture, _walkTexture, _shootTexture, _jumpTexture, new Vector2(100, 400), 200f);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Input.Update();
            hero.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Begin met tekenen
            _spriteBatch.Begin();

            // Teken de hero
            hero.Draw(_spriteBatch);

            // Stop met tekenen
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
