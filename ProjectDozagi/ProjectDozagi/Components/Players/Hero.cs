using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectDozagi.Components.Objects;
using ProjectDozagi.Engine.Cores;
using ProjectDozagi.Engine.Cores.Animations;
using ProjectDozagi.Engine.Cores.Sprites;
using System;
using System.IO;

namespace ProjectDozagi.Components.Players
{
    public class Hero : Unit
    {
        private float _speed;

        public Hero(string path, Vector2 position, Vector2 dimension, Rectangle bounds) : base(path, position, dimension, bounds)
        {
            _speed = 2.0f;
        }

        public override void Update()
        {
            if (Global.KeyboardInput.GetPress("W"))
            {
                Position = new Vector2(Position.X, Position.Y - _speed);
                Texture = Global.Content.Load<Texture2D>("Sprites\\Character_Idle_01");
                Animation = null;
            }

            if (Global.KeyboardInput.GetPress("S"))
            {
                Position = new Vector2(Position.X, Position.Y + _speed);
                Texture = Global.Content.Load<Texture2D>("Sprites\\Character_Idle_01");
                Animation = null;
            }

            if (Global.KeyboardInput.GetPress("A"))
            {
                Position = new Vector2(Position.X - _speed, Position.Y);
                Texture = Global.Content.Load<Texture2D>("Sprites\\Character_Walk_01-sheet");
                Animation = new SpriteAnimation(Texture, 4, 0.1f);
            }

            if (Global.KeyboardInput.GetPress("D"))
            {
                Position = new Vector2(Position.X + _speed, Position.Y);
                Texture = Global.Content.Load<Texture2D>("Sprites\\Character_Walk_01-sheet");
                Animation = new SpriteAnimation(Texture, 4, 0.1f);
            }

            if (Global.MouseInput.LeftClick())
            {
                GameGlobal.PassProjectiles(new Apple(
                    Position, 
                    new Vector2(24, 24), 
                    Global.MouseInput.Position - Position, 
                    Position, 
                    new Rectangle((int)Position.X, (int)Position.Y, 24, 24)));
            }

            base.Update();
        }

        public override void Draw(Vector2 offset = default)
        {
            base.Draw(offset);
        }
    }
}
