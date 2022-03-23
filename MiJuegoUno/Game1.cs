using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiJuegoUno
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        bool visibleF;

        Texture2D spaceShip;//Almacena en memoria la imagen
        Texture2D Fireball;

        Rectangle fireballRectangle;//Para controlar el tamaño
        Rectangle spaceshipRectangle;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //_graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            visibleF = false;
            fireballRectangle = new Rectangle(0, 0, 50, 50);
            spaceshipRectangle = new Rectangle(300, 350, 200, 250);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            spaceShip = this.Content.Load<Texture2D>("Spaceship");

            Fireball = this.Content.Load<Texture2D>("Fireball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState KeysState = Keyboard.GetState();

            // TODO: Add your update logic here
            //red++;
            //green++;
            //blue++;

            if (KeysState.IsKeyDown(Keys.Left))
            {
                spaceshipRectangle.X -= 3;
            }
            else if (KeysState.IsKeyDown(Keys.Right))
            {
                spaceshipRectangle.X += 3;
            }

            if (KeysState.IsKeyDown(Keys.Space))
            {
                visibleF = true;//visibleF = !visibleF (Para hacer aparecer y desaparecer cada vez que oprima la barra espaceadora)
                fireballRectangle.X = spaceshipRectangle.X + (spaceshipRectangle.Width/2) -24;
                fireballRectangle.Y = spaceshipRectangle.Y + 10;
            }

            if(visibleF)
            {
                fireballRectangle.Y-=5;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Assets formato xnb
            //GraphicsDevice.Clear(new Color(red,green,blue));
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();//SpriteBatch es la máquina de dibujo

            if(visibleF)
            {
                _spriteBatch.Draw(Fireball, fireballRectangle, Color.White);
            }
            _spriteBatch.Draw(spaceShip, spaceshipRectangle, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
