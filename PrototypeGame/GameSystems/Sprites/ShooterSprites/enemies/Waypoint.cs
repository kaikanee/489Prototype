﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites.ShooterSprites.Enemy.Enemy
{
    internal class Waypoint
    {

        public Waypoint(Vector2 target, float initialSpeed, float maxSpeed, float acceleration, float waitTime)
        {
            this.Target = target;
            this.InitialSpeed = initialSpeed;
            this.MaxSpeed = maxSpeed;
            this.Acceleration = acceleration;
            this.WaitTimer = waitTime;
        }
        public Vector2 Target { get; }

        /// <summary>
        /// If initial speed -1, use previous speed.
        /// </summary>
        /// 
        public float MaxSpeed { get; }
        public float InitialSpeed { get; }
        public float Acceleration { get; }

        public float WaitTimer { get; }
    }
}
