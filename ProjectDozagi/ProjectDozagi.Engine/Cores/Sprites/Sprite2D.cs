using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectDozagi.Engine.Cores.Animations;
using System.IO;

namespace ProjectDozagi.Engine.Cores.Sprites
{
    public class Sprite2D
    {
        public Vector2 Position { get; set; }

        public Vector2 Dimension { get; set; }

        public Texture2D Texture { get; set; }

        public float Rotation { get; set; }

        public Rectangle Bounds { get; set; }

        public SpriteAnimation? Animation { get; set; }

        public Sprite2D(string path, Vector2 position, Vector2 dimension, Rectangle bounds)
        {
            Position = position;
            Dimension = dimension;
            Texture = Global.Content.Load<Texture2D>(path);
            Bounds = bounds;
        }

        public virtual void Update() 
        { 
            Animation?.Update();
        }

        public virtual void Draw(Vector2 offset = default)
        {
            if (Texture != null)
            {
                if (Animation != null)
                {
                    Animation.Draw(Position);
                }
                else
                {
                    Global.SpriteBatch.Draw(
                        Texture,
                        new Rectangle((int)(Position.X + offset.X), (int)(Position.Y + offset.Y), (int)Dimension.X, (int)Dimension.Y),
                        null,
                        Color.White,
                        Rotation,
                        new Vector2(Texture.Bounds.Width / 2, Texture.Bounds.Height / 2),
                        SpriteEffects.None,
                        0);
                }
            }
        }

        public virtual void Draw(Vector2 offset = default, Vector2 origin = default)
        {
            if (Texture != null)
            {
                if (Animation != null)
                {
                    Animation.Draw(Position);
                }
                else
                {
                    Global.SpriteBatch.Draw(
                        Texture,
                        new Rectangle((int)(Position.X + offset.X), (int)(Position.Y + offset.Y), (int)Dimension.X, (int)Dimension.Y),
                        null,
                        Color.White,
                        Rotation,
                        origin,
                        SpriteEffects.None,
                        0);
                }
            }
        }

        public bool Intersects(Sprite2D other)
        {
            return Bounds.Intersects(other.Bounds);
        }
    }
}
