using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PrototypeGame.GameSystems.Sprites;
using PrototypeGame.GameSystems.Sprites.ShooterSprites;
using PrototypeGame.GameSystems.Sprites.ShooterSprites.enemies;
using PrototypeGame.GameSystems.Sprites.ShooterSprites.Enemy.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems
{
    internal class GameDirector
    {
        //List<GameComponent> components;

        List<Sprite> _sprites;

        public GameDirector(GraphicsDevice graphics, Vector2 screenSize)
        {
            _sprites = new List<Sprite>();
            Vector2 screenMiddle = new Vector2(screenSize.X / 2, screenSize.Y / 2);

            Player player = new("playertexture", "playerprojectile", "playerhitbox", new Vector2(screenMiddle.X, screenMiddle.Y + 200), screenSize, 1f, 400f);
            _sprites.Add(player);
            Waypoint wp1 = new Waypoint(screenMiddle, 0f, 100f, 300f, 45f);
            Queue<Waypoint> waypoints = new Queue<Waypoint>();
            waypoints.Enqueue(wp1);
            Enemy enemy = new("enemytexture", "enemyprojectile", Vector2.Zero, screenSize, 1f, 1f, ref player);
            
            enemy.waypoints = waypoints;
            _sprites.Add(enemy);

        }

        public void LoadContent(ContentManager cm)
        {
            foreach(Sprite sprite in _sprites)
            {
                sprite.LoadContent(cm);
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(Sprite sprite in _sprites.ToArray())
            { sprite.Update(gameTime); }

            PostUpdate(gameTime);
        }


        public void PostUpdate(GameTime gt)
        {
            foreach (Sprite sprite in _sprites.ToArray())
            {
                if (sprite.isRemoved) { _sprites.Remove(sprite); continue; }
                if(sprite is CollidableSprite)
                {
                    foreach(Sprite sprite2 in _sprites.ToArray())
                    {
                        if(sprite2 is CollidableSprite && !sprite2.Equals(sprite))
                        {
                            CollidableSprite collidee = (CollidableSprite)sprite;
                            CollidableSprite collider = (CollidableSprite)sprite2;
                            if(collidee.Intersects(collider))
                            {
                                collidee.onCollide(collider);
                            }
                        }
                    }
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch sb)
        {
            foreach(Sprite sprite in _sprites)
            {
                sprite.Draw(gameTime, sb);
            }
        }
    }
}
