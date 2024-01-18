﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGame.GameSystems.Sprites
{
    internal abstract class GameComponent
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch sb);

        public abstract void Update(GameTime gt);

    }
}
