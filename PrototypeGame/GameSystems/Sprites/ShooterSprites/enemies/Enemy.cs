﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PrototypeGame.GameSystems.Sprites.ShooterSprites.Enemy.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites.ShooterSprites.enemies
{
    internal class Enemy : ShootingSprite
    {
        private Vector2 target;
        private Waypoint currentWaypoint;
        private float waypointTimer;
        public Queue<Waypoint> waypoints;

        private Vector2 TargetPosition
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
        public Enemy(string textureName, string projectileTexture, Vector2 initialPosition, Vector2 hitboxDimensions, Vector2 screenDimensions, float health, float attackTimer) : base(textureName, projectileTexture, initialPosition, hitboxDimensions, screenDimensions, health, attackTimer, null)
        {
            waypoints = new Queue<Waypoint>();
            //speed = 40f;
        }


       
        public override void Update(GameTime gt)
        {
            base.Update(gt);
            // attack

            if (attackCooldown <= 0f)
            {
                attackCooldown = attackTimer;
                

            }

            // if we dont currently have a waypoint, setup a new waypoint.
            if (currentWaypoint == null)
            {
                // if there is a waypoint in the queue, dequeue it
                if(waypoints.Count > 0)
                {
                    currentWaypoint = waypoints.Dequeue();
                    if(currentWaypoint.InitialSpeed != -1)
                    {
                        this.speed = currentWaypoint.InitialSpeed;
                    }
                    this.TargetPosition = currentWaypoint.Target;
                    this.acceleration = currentWaypoint.Acceleration;
                    this.waypointTimer = currentWaypoint.WaitTimer;
                    this.maxSpeed = currentWaypoint.MaxSpeed;

                }
                // otherwise, remove this enemy.
                else
                {
                    this.isRemoved = true;
                }
            }
            // if we do have a current waypoint,
            else
            {
                //decrement then check timer
                waypointTimer -= (float)gt.ElapsedGameTime.TotalSeconds;
                if(waypointTimer < 0)
                {
                    currentWaypoint = null;
                    return;
                }
                // if we're still good, then calculate acceleration and go.
                if(!(Vector2.Distance(position, target) < 5f))
                {
                    if (speed < maxSpeed)
                    {
                        speed += acceleration * (float)gt.ElapsedGameTime.TotalSeconds;
                    }
                    position = Vector2.Lerp(position, position + velocity, speed * (float)gt.ElapsedGameTime.TotalSeconds);
                }
            }
        }
    }
}
