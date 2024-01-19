using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites.ShooterSprites
{

    //setting this up so can just have an attack that maybe represents a multi projectile attack, etc
    internal class Attack
    {
        private Bullet attackBullet;
        private Sprite parent;

        public Attack(Bullet attackBullet, Sprite parent)
        {
            this.attackBullet = attackBullet;
            this.parent = parent;
        }

        protected void Execute(Vector2 targetPosition)
        {
            Bullet bullet = attackBullet.Clone() as Bullet;
            bullet.position = parent.position;
            bullet.TargetPosition = targetPosition;
            parent.children.Add(bullet);


        }

        /*
        protected List<Bullet> Execute()
        {

        }
        */
    }
}
