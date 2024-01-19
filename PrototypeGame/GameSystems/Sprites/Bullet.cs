using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace PrototypeGame.GameSystems.Sprites
{
    internal class Bullet : CollidableSprite
    {
        float lifespan;
        private Vector2 target;
        internal Sprite targetSprite;

        internal Vector2 TargetPosition
        {
            get
            {
                return target;
            }
            set
            {
                this.target = value;
                velocity = Vector2.Normalize(target - position);

            }
        }

        
        public Bullet(string textureName, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, Vector2 targetPosition, float speed, float maxSpeed, float  acceleration, float lifespan) : base(textureName, initialPosition, hitboxDimensions, screenDimensions)
        {
            this.TargetPosition = targetPosition;
            this.speed = speed;
            this.acceleration = acceleration;
            this.maxSpeed = maxSpeed;
            this.lifespan = lifespan;
        }


        public Bullet(string textureName, Vector2 intialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, ref Sprite target, float speed, float maxSpeed, float acceleration, float lifespan) : this(textureName, intialPosition, hitboxDimensions, screenDimensions, target.position, speed, maxSpeed, acceleration, lifespan)
        {
            this.targetSprite = target;
        }

        

        public override void Update(GameTime gt)
        {
            base.Update(gt);
            CalculateMovement(gt);
        }

        public virtual void CalculateMovement(GameTime gt)
        {
            lifespan -= (float)gt.ElapsedGameTime.TotalSeconds;
            // check to remove, theoretically third conditional is not required.
            if (IsOutOfBounds() || lifespan <= 0 || isRemoved)
            {
                isRemoved = true;
                return;
            }
            else
            {
                //if we have a target, update the targetposition
                if (targetSprite != null)
                {
                    TargetPosition = targetSprite.position;
                }
                if(speed < maxSpeed)
                {
                    speed += acceleration * (float)gt.ElapsedGameTime.TotalSeconds;

                    
                }

               
                position = Vector2.Lerp(position, position + velocity, speed * (float)gt.ElapsedGameTime.TotalSeconds);
                return;
            }
        }
    }
}
