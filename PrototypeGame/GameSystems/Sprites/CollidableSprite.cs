using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        
        protected Vector2 screenDimensions;

        public bool ShowHitbox
        {
            get; set;
        }

        public CollidableSprite(string textureName, Vector2 initialPosition, Vector2 screenDimensions) : base(textureName, initialPosition)
        {
            this.screenDimensions = screenDimensions;
            
            this.ShowHitbox = false;
        }

        public CollidableSprite(string textureName, Vector2 initialPosition, Vector2 screenDimensions, float speed, float rotation, float scale) : base(textureName, initialPosition, speed, rotation, scale)
        {
            this.screenDimensions = screenDimensions;
            
            this.ShowHitbox = false;
        }

        public virtual Rectangle Hitbox
        {
            get
            {
                return new Rectangle((int)position.X - (int)origin.X,(int)position.Y - (int)origin.Y, (int)texture.Width, (int)texture.Height);
            }
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }


        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            base.Draw(gameTime, sb);
            if(ShowHitbox)
            {
                // draw the rectangle here,
            }
        }
        /*
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

        */
        protected bool IsOutOfBounds()
        {
            if (this.position.X < 0 || this.position.Y < 0)
            {
                return true;
            }
            if (this.position.X > screenDimensions.X || this.position.Y > screenDimensions.Y)
            {
                return true;
            }
           
            return false;
        }

        public bool Intersects(CollidableSprite sprite)
        {

            
            // Calculate a matrix which transforms from A's local space into
            // world space and then into B's local space
            var transformAToB = this.Transform * Matrix.Invert(sprite.Transform);

            // When a point moves in A's local space, it moves in B's local space with a
            // fixed direction and distance proportional to the movement in A.
            // This algorithm steps through A one pixel at a time along A's X and Y axes
            // Calculate the analogous steps in B:
            var stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            var stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            // Calculate the top left corner of A in B's local space
            // This variable will be reused to keep track of the start of each row
            var yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);

            for (int yA = 0; yA < this.Hitbox.Height; yA++)
            {
                // Start at the beginning of the row
                var posInB = yPosInB;

                for (int xA = 0; xA < this.Hitbox.Width; xA++)
                {
                    // Round to the nearest pixel
                    var xB = (int)Math.Round(posInB.X);
                    var yB = (int)Math.Round(posInB.Y);

                    if (0 <= xB && xB < sprite.Hitbox.Width &&
                        0 <= yB && yB < sprite.Hitbox.Height)
                    {
                        // Get the colors of the overlapping pixels
                        var colourA = this.textureData[xA + yA * this.Hitbox.Width];
                        var colourB = sprite.textureData[xB + yB * sprite.Hitbox.Width];

                        // If both pixel are not completely transparent
                        if (colourA.A != 0 && colourB.A != 0)
                        {
                            return true;
                        }
                    }

                    // Move to the next pixel in the row
                    posInB += stepX;
                }

                // Move to the next row
                yPosInB += stepY;
            }

            // No intersection found
            return false;
        }


        
        public virtual void onCollide(CollidableSprite collider)
        {
            return;
        }
        

    }
}
