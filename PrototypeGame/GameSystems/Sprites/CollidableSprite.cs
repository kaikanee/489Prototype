using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites
{
    internal class CollidableSprite : Sprite
    {
        private Texture2D hitboxTexture;
        private Vector2 hitboxDimensions;
        private Vector2 screenDimensions;

        public bool ShowHitbox
        {
            get; set;
        }

        public CollidableSprite(string textureName, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions) : base(textureName, initialPosition)
        {
            this.screenDimensions = screenDimensions;
            this.hitboxDimensions = hitboxDimensions;
            this.ShowHitbox = false;
        }

        public CollidableSprite(string textureName, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, float speed, float rotation, float scale) : base(textureName, initialPosition, speed, rotation, scale)
        {
            this.screenDimensions = screenDimensions;
            this.hitboxDimensions = hitboxDimensions;
            this.ShowHitbox = false;
        }

        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)origin.X, (int)origin.Y, (int)hitboxDimensions.X, (int)hitboxDimensions.Y);
            }
        }

        private void SetHitbox(GraphicsDevice graphics)
        {
            var colors = new List<Color>();

            for (int y = 0; y < hitboxDimensions.Y; y++)
            {
                for (int x = 0; x < hitboxDimensions.X; x++)
                {
                    //if(x == 0 || y == 0 || x == hitboxDimensions.X -1 || y == hitboxDimensions.Y -1)
                    //{
                    colors.Add(new Color(255, 255, 255, 255));
                    //// }
                    // else
                    // {
                    //    colors.Add(new Color(0,0,0,0));
                    //}

                }
            }
            hitboxTexture = new Texture2D(graphics, (int)hitboxDimensions.X, (int)hitboxDimensions.Y);
            hitboxTexture.SetData<Color>(colors.ToArray());
        }


    }
}
