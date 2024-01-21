using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites.ShooterSprites
{
    internal class Player : ShootingSprite
    {

        Texture2D hitboxTexture;
        private string hitboxText;
        public override Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X - ((int)hitboxTexture.Width / 2), (int)position.Y - ((int)hitboxTexture.Height / 2), (int)hitboxTexture.Width, (int)hitboxTexture.Height);
            }
        }

        public override Matrix Transform
        {
            get
            {
                var matrix = Matrix.CreateTranslation(new Vector3(-(new Vector2(hitboxTexture.Width / 2, hitboxTexture.Height / 2)), 0)) * Matrix.CreateRotationZ(rotation) * Matrix.CreateTranslation(new Vector3(position, 0f) * scale);
                return matrix;
            }

        }
        public Player(string textureName, string projectileTexture, string hitboxTexture, Vector2 initialPosition, Vector2 screenDimensions, float health, float maxSpeed) : base(textureName, projectileTexture, initialPosition, screenDimensions, health, .2f, null )
        {
            this.maxSpeed = maxSpeed;
            this.defaultProjectileTexture = projectileTexture;
            this.hitboxText = hitboxTexture;
            this.attackCooldown = 0;
            //this.scale = 500f;


            
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            base.Draw(gameTime, sb);
            if(ShowHitbox)
            {
                sb.Draw(hitboxTexture, position, null, Color.White, rotation, new Vector2(hitboxTexture.Width / 2, hitboxTexture.Height / 2), scale, spriteEffect, 0f);
            }
        }

        public override void Update(GameTime gt)
        {
            attackCooldown -= (float)gt.ElapsedGameTime.TotalSeconds;
            velocity = Vector2.Zero;
            base.Update(gt);
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Keys.F))
            {
                if (attackCooldown <= 0f)
                {
                    attackCooldown = attackTimer;
                    this.defaultAttack.Execute(new Vector2(position.X, position.Y - 100));

                }

            }

            if (input.IsKeyDown(Keys.Space))
            {
                speed = 15f;
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

            Bullet playerBullet = new Bullet(defaultProjectileTexture, Vector2.Zero, screenDimensions, Vector2.Zero, 500f, 500f, 0f, 10f);
            playerBullet.LoadContent(content);
            this.defaultAttack = new Attack(playerBullet, this, "playeratk");
            this.defaultAttack.LoadContent(content);
            this.hitboxTexture = content.Load<Texture2D>(hitboxText);
              this.textureData = new Color[hitboxTexture.Width * hitboxTexture.Height];
            this.hitboxTexture.GetData(textureData);
        }

        public override void onCollide(CollidableSprite collider)
        {
            this.isRemoved = true;
        }

        
    }
}
