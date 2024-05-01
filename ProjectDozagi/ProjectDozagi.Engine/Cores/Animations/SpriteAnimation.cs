using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDozagi.Engine.Cores.Animations
{
    public class SpriteAnimation
    {
        private readonly Texture2D _texture;
        private readonly List<Rectangle> _sources;
        private readonly int _frames;
        private int _frame;
        private readonly float _frameTime;
        private float _frameTimeLeft;
        private bool _isActive;

        public SpriteAnimation(Texture2D texture, int framesX, float frameTime)
        {
            _isActive = true;
            _sources = new();

            _texture = texture;
            _frameTime = frameTime;
            _frameTimeLeft = _frameTime;
            _frames = framesX;

            int frameWidth = _texture.Width / framesX;
            int frameHeight = _texture.Height;

            for (int i = 0; i < _frames; ++i)
            {
                _sources.Add(new Rectangle(i * frameWidth, 0, frameWidth, frameHeight));
            }
        }

        public void Start()
        {
            _isActive = true;
        }

        public void Stop()
        {
            _isActive = false;
        }

        public void Reset()
        {
            _frame = 0;
            _frameTimeLeft = _frameTime;
        }

        public void Update()
        {
            if (!_isActive)
            {
                return;
            }

            _frameTimeLeft -= (float)Global.GameTime.ElapsedGameTime.TotalSeconds;

            if (_frameTimeLeft <= 0)
            {
                _frameTimeLeft += _frameTime;
                _frame = (_frame + 1) % _frames;
            }
        }

        public void Draw(Vector2 position)
        {
            Global.SpriteBatch.Draw(
                _texture,
                position,
                _sources[_frame],
                Color.White,
                0,
                Vector2.Zero,
                new Vector2(0.375f, 0.375f),
                SpriteEffects.None,
                1);
        }
    }
}
