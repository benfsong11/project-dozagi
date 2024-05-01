using Microsoft.Xna.Framework;
using ProjectDozagi.Engine.Cores.Sprites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDozagi.Components.Worlds
{
    public class Ground : Sprite2D
    {
        public Ground(string path, Vector2 position, Vector2 dimension, Rectangle bounds) 
            : base(path, position, dimension, bounds)
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(Vector2 offset = default)
        {
            base.Draw(offset);
        }
    }
}
