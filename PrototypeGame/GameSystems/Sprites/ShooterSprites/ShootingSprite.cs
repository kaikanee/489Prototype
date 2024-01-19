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
        protected string defaultProjectileTexture;
        protected Attack defaultAttack;

        // in update, if health <= 0, call a Kill method.
        public float health;


        public ShootingSprite(string textureName, string projectileTexture, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, float health, Attack defaultAttack) : base(textureName, initialPosition, hitboxDimensions, screenDimensions)
        {
            this.health = health;
            this.defaultAttack = defaultAttack;

            // test code, maybe make a struct that contains bullet data for simplicity. i'm just lazy and dont want to add a bunch of constructor variables
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);
            // update its children (bullets)
            foreach (GameComponent gameComponent in this.children)
            {
                gameComponent.Update(gt);
            }
        }
    }
}
