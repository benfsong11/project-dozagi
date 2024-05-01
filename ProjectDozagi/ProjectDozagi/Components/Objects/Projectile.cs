using Microsoft.Xna.Framework;
using ProjectDozagi.Engine.Cores.Sprites;
using ProjectDozagi.Engine.Cores.Timers;
using System;
using System.IO;

namespace ProjectDozagi.Components.Objects
{
    public class Projectile : Sprite2D
    {
        public bool IsDone { get; set; }

        public float Speed { get; set; }

        public Vector2 Direction { get; set; }

        public Vector2 OwnerPosition { get; set; }

        public CoreTimer Timer { get; set; }

        public Projectile(string path, Vector2 position, Vector2 dimension, Vector2 direction, Vector2 ownerPosition, Rectangle bounds) 
            : base(path, position, dimension, bounds)
        {
            IsDone = false;
            Speed = 3.0f;
            Direction = direction;
            OwnerPosition = ownerPosition;

            // Vector2.Normalize() doesn't work.
            float num = 1f / MathF.Sqrt(Direction.X * Direction.X + Direction.Y * Direction.Y);
            Direction *= num;

            Timer = new CoreTimer(1200);
        }

        public virtual void Update(Vector2 offset = default)
        {
            Position += Direction * Speed;
            Timer.Update();

            if (Timer.IsDone())
            {
                IsDone = true;
            }

            //if (Position.Y >= OwnerPosition.Y)
            //{
            //    IsDone = true;
            //}
        }

        public override void Draw(Vector2 offset = default)
        {
            base.Draw(offset);
        }
    }
}
