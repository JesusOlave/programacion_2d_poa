using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using UTalDrawSystem.MyGame;
using UTalDrawSystem.SistemaDibujado;
using UTalDrawSystem.SistemaFisico;
using UTalDrawSystem.SistemaGameObject;
using Microsoft.Xna.Framework.Audio;

namespace UTalDrawSystem
{
    public enum GameState
    {
        Inicio,
        Gameplay,
        Creditos,
        Instruct,
        Final
    }


    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        SoundEffect pause;
        SoundEffect plink;
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        Escena3 escena3;
        Escena escena;
        private Fondo gameplay = new Fondo();
        private Pantallas logo = new Pantallas();
        private Pantallas final = new Pantallas();
        private Pantallas instruct = new Pantallas();
        private Pantallas creditos = new Pantallas();
        public static bool paused = false;
        public KeyboardState now;
        public KeyboardState last;


        public static Game1 INSTANCE;
        public static GameState pantalla = GameState.Inicio;

        bool EnterPressed = false;
        public Game1()
        {
            
            INSTANCE = this;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            this.plink = Game1.INSTANCE.Content.Load<SoundEffect>("Sound Effects Button");
            IsMouseVisible = true;


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
            
            new EscenaInicial();


            pause = Content.Load<SoundEffect>("Super Mario Bros.-Pause Sound Effect");
            logo.Content(Content, "menuInicio");
            instruct.Content(Content, "instrucciones");
            creditos.Content(Content, "creditos");
            gameplay.Content(Content, "universo");
            final.Content(Content, "fin");
            // TODO: use this.Content to load your game content here
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
            {
                Exit();
            }

            now = Keyboard.GetState();

            if (now.IsKeyUp(Keys.O) && last.IsKeyDown(Keys.O))
            {
                paused = !paused;
                pause.Play();
            }

            if (paused)
            {

                last = now;

                return;

            }

            //Console.WriteLine(gameTime.ElapsedGameTime.TotalSeconds);
            // TODO: Add your update logic here
            
            Escena.INSTANCIA?.Update(gameTime);
            MotorFisico.Update(gameTime);
            UTGameObjectsManager.Update(gameTime);


            if (!EnterPressed && Keyboard.GetState().IsKeyDown(Keys.Enter) && pantalla == GameState.Inicio)
            {
                plink.Play();
                EnterPressed = true;
                pantalla = GameState.Gameplay;
                new Escena2();
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Enter))
            {

                EnterPressed = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.I) && pantalla == GameState.Inicio)
            {
                plink.Play();
                pantalla = GameState.Instruct;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Back) &&  pantalla == GameState.Instruct)
            {
                plink.Play();
                pantalla = GameState.Inicio;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.C) && pantalla == GameState.Inicio)
            {
                plink.Play();
                pantalla = GameState.Creditos;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Back) && pantalla == GameState.Creditos)
            {
                plink.Play();
                pantalla = GameState.Inicio;
            }
            if (pantalla == GameState.Final && Keyboard.GetState().IsKeyDown(Keys.R))
            {
                plink.Play();
                pantalla = GameState.Inicio;
            }
            

            gameplay.Update(gameTime);
            
            base.Update(gameTime);

            last = now;
        }

        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (pantalla)
            {
                case GameState.Inicio:
                    logo.Draw();
                    break;
                case GameState.Gameplay:
                    gameplay.Draw();
                    break;
                case GameState.Creditos:
                    creditos.Draw();
                    break;
                case GameState.Instruct:
                    instruct.Draw();
                    break;
                case GameState.Final:
                    final.Draw();
                    break;
            }

           Camara.ActiveCamera.Dibujar(spriteBatch);
           spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
