using Microsoft.Xna.Framework;
using System;

namespace ProjectDozagi.Components.Objects
{
    public class Apple : Projectile
    {
        public Apple(Vector2 position, Vector2 dimension, Vector2 direction, Vector2 ownerPosition, Rectangle bounds)
            : base("Sprites\\Apple_01", position, dimension, direction, ownerPosition, bounds)
        {
        }

        public override void Update(Vector2 offset = default)
        {
            base.Update(offset);
        }

        public override void Draw(Vector2 offset = default)
        {
            base.Draw(offset);
        }
    }
}
