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
        protected float attackTimer, attackCooldown;
        

        // in update, if health <= 0, call a Kill method.
        public float health;


        public ShootingSprite(string textureName, string projectileTexture, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, float health, float attackTimer, Attack defaultAttack) : base(textureName, initialPosition, hitboxDimensions, screenDimensions)
        {
            this.health = health;
            this.defaultAttack = defaultAttack;
            this.attackTimer = attackTimer;
            

            
        }

       

        public override void Update(GameTime gt)
        {
            base.Update(gt);
            // update its children (bullets)
            
        }

        
    }
}
