using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites
{
    internal class Sprite : GameComponent, ICloneable
    {
        private string textureName;
        private Texture2D texture;
        protected Vector2 velocity, origin;
        protected float speed, rotation;
        
        public Vector2 position;
        public float scale;
        public List<Sprite> children;


        /// <summary>
        /// Generates a new instance of the sprite class with default values.
        /// </summary>
        /// <param name="textureName">Texture name</param>
        /// <param name="initialPosition">Initial position of the sprite</param>
        public Sprite(string textureName, Vector2 initialPosition)
        {
            this.children = new List<Sprite>();
            this.textureName = textureName;
            this.position = initialPosition;
            isRemoved = false;
            speed = 0f;
            rotation = 0f;
            scale = 1f;
        }

        /// <summary>
        /// Generates a new instance of the Sprite class.
        /// </summary>
        /// <param name="textureName">Texture name</param>
        /// <param name="initialPosition">Initial position of the sprite</param>
        /// <param name="speed">Linear speed</param>
        /// <param name="rotation">Rotation in (radians or degrees?)</param>
        /// <param name="scale">Scale of the sprite.</param>
        public Sprite(string textureName, Vector2 initialPosition, float speed, float rotation, float scale) : this(textureName, initialPosition)
        {
            this.speed = speed;
            this.rotation = rotation;
            this.scale = scale;
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
            foreach (Sprite child in this.children.ToArray())
            {
                if (child.isRemoved) { this.children.Remove(child); }
                child.Draw(gameTime, sb);
            }
        }

        // basic sprite shouldnt do anything
        public override void Update(GameTime gt)
        {
            foreach (Sprite child in this.children.ToArray())
            {
                if (child.isRemoved) { this.children.Remove(child); }
                child.Update(gt);
            }
            //throw new NotImplementedException();
        }

        public virtual void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>(textureName);
            this.origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
