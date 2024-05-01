using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectDozagi.Engine.Cores.Inputs;
using System;
using System.Drawing;

namespace ProjectDozagi.Engine.Cores
{
    public delegate void PassObject(object obj);
    public delegate object PassObjectAndReturn(object obj);

    public class Global
    {
        public static ContentManager Content;
        public static SpriteBatch SpriteBatch;
        public static KeyboardInput KeyboardInput;
        public static MouseInput MouseInput;
        public static Size ScreenSize;
        public static GameTime GameTime;

        public static float GetDistance(Vector2 position, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
        }
    }
}
