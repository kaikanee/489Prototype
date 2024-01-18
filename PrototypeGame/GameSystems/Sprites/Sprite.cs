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
        private Vector2 velocity, origin;
        private float speed, rotation;
        public Vector2 position;
        public bool isRemoved;
        public float scale;


        public Sprite(string textureName, Vector2 initialPosition)
        {
            this.textureName = textureName;
            this.position = initialPosition;
            isRemoved = false;
        }

        public Sprite(string textureName, Vector2 initialPosition, float speed, float rotation, float scale)
        {
            this.textureName = textureName;
            this.position = initialPosition;
            this.speed = speed;
            this.rotation = rotation;
            this.scale = 1f;
            isRemoved = false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(texture, position, null, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);
        }

        public override void Update(GameTime gt)
        {
            throw new NotImplementedException();
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
