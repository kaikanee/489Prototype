using Microsoft.Xna.Framework;
using PrototypeGame.GameSystems.Sprites.ShooterSprites.Enemy.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites.ShooterSprites.enemies
{
    internal class Enemy : CollidableSprite
    {
        private List<Waypoint> waypoints;

        public Enemy(string textureName, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, float health) : base(textureName, initialPosition, hitboxDimensions, screenDimensions)
        {
            
        }
    }
}
