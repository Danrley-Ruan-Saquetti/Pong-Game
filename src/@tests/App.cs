using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace YourNamespace
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private BasicEffect basicEffect;

        // Vértices do triângulo
        private VertexPositionTexture[] _vertices;
        private short[] ind;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            this.basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.TextureEnabled = true;

            _vertices = new VertexPositionTexture[4];
            _vertices[0].Position = new Vector3(0, 0, 0);
            _vertices[1].Position = new Vector3(100, 0, 0);
            _vertices[2].Position = new Vector3(0, 100, 0);
            _vertices[3].Position = new Vector3(100, 100, 0);

            _vertices[0].TextureCoordinate = new Vector2(0, 0);
            _vertices[1].TextureCoordinate = new Vector2(1, 0);
            _vertices[2].TextureCoordinate = new Vector2(0, 1);
            _vertices[3].TextureCoordinate = new Vector2(1, 1);

            ind = new short[6];
            ind[0] = 0;
            ind[1] = 2;
            ind[2] = 1;
            ind[3] = 1;
            ind[4] = 2;
            ind[5] = 3;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Desenhar o polígono
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionTexture>(
        PrimitiveType.TriangleList, _vertices, 0, _vertices.Length, ind, 0, ind.Length / 3);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
