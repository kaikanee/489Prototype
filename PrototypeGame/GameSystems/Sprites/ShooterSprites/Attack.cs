using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
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
        private SoundEffect attackSound;
        private string soundName;
        private Sprite parent;

        public Attack(Bullet attackBullet, Sprite parent, string attackSound)
        {
            this.attackBullet = attackBullet;
            this.parent = parent;
            this.soundName = attackSound;
        }

        public void Execute(Vector2 targetPosition)
        {
            attackSound.Play();
            Bullet bullet = attackBullet.Clone() as Bullet;
            bullet.position = parent.position;
            bullet.TargetPosition = targetPosition;
            parent.children.Add(bullet);


        }

        public void LoadContent(ContentManager content)
        {
            attackBullet.LoadContent(content);
            attackSound = content.Load<SoundEffect>(soundName);

        }

        /*
        protected List<Bullet> Execute()
        {

        }
        */
    }
}
