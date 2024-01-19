using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites.ShooterSprites
{
    internal class ShootingSprite : CollidableSprite
    {
        List<Sprite> children;
        float health;


        public ShootingSprite(string textureName, string projectileTexture, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, float health) : base(textureName, initialPosition, hitboxDimensions, screenDimensions)
        {
            this.health = health;
            children = new List<Sprite>();
        }

        public void Shoot()
        {

        }
    }
}
