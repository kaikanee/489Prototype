using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites.ShooterSprites
{
    internal class Player : ShootingSprite
    {

        float maxSpeed;
        public Player(string textureName, string projectileTexture, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, float health, float maxSpeed) : base(textureName, projectileTexture, initialPosition, hitboxDimensions, screenDimensions, health, null)
        {
            this.maxSpeed = maxSpeed;
            this.defaultProjectileTexture = projectileTexture;
            //this.scale = 500f;


            
        }


        public override void Update(GameTime gt)
        {
            velocity = Vector2.Zero;
            base.Update(gt);
            KeyboardState input = Keyboard.GetState();
            if (input.IsKeyDown(Keys.Space))
            {
                speed = maxSpeed / 2;
                ShowHitbox = true;

            }
            else
            {
                speed = maxSpeed;
                ShowHitbox = false;
            }
            if (input.IsKeyDown(Keys.Up))
            {
                velocity.Y -= 1;
            }
            if (input.IsKeyDown(Keys.Down))
            {
                velocity.Y += 1;
            }
            if (input.IsKeyDown(Keys.Left))
            {
                velocity.X -= 1;

            }
            if (input.IsKeyDown(Keys.Right))
            {
                velocity.X += 1;
            }
            if (velocity.Length() > 0)
            {
                velocity.Normalize();
                velocity *= speed;

            }
            //probably bad practices
            Vector2 prePosition = position;
            position += velocity * (float)gt.ElapsedGameTime.TotalSeconds;
            if (IsOutOfBounds())
            {
                position = prePosition;
            }

            
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            // test code for now, need to do this differently later (figure out when to instantiate attack...)

            Bullet playerBullet = new Bullet(defaultProjectileTexture, Vector2.Zero, new Vector2(40, 40), screenDimensions, Vector2.Zero, 0f, 50f, 12f, 10f);
            playerBullet.LoadContent(content);
            Attack attack = new Attack(playerBullet, this);
        }
    }
}
