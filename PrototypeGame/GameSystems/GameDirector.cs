using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PrototypeGame.GameSystems.Sprites;
using PrototypeGame.GameSystems.Sprites.ShooterSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems
{
    internal class GameDirector
    {
        //List<GameComponent> components;

        List<Sprite> _sprites;

        public GameDirector(GraphicsDevice graphics, Vector2 screenSize)
        {
            _sprites = new List<Sprite>();
            Vector2 screenMiddle = new Vector2(screenSize.X / 2, screenSize.Y / 2);

            Player player = new("playertexture", "playerprojectile", new Vector2(screenMiddle.X, screenMiddle.Y + 200), new Vector2(40, 40), screenSize, 1, 400f);
            _sprites.Add(player);

        }

        public void LoadContent(ContentManager cm)
        {
            foreach(Sprite sprite in _sprites)
            {
                sprite.LoadContent(cm);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(Sprite sprite in _sprites)
            { sprite.Update(gameTime); }
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            foreach(Sprite sprite in _sprites)
            {
                sprite.Draw(gameTime, sb);
            }
        }
    }
}
