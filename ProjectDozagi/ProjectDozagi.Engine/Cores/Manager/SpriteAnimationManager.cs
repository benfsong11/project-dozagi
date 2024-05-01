using Microsoft.Xna.Framework;
using ProjectDozagi.Engine.Cores.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDozagi.Engine.Cores.Manager
{
    public class SpriteAnimationManager
    {
        private readonly Dictionary<object, SpriteAnimation> _animations;
        private object _lastKey;

        public SpriteAnimationManager()
        {
            _animations = new Dictionary<object, SpriteAnimation>();
        }

        public void Add(object key, SpriteAnimation animation)
        {
            _animations.Add(key, animation);
            _lastKey = key;
        }

        public void Update(object key)
        {
            if ( _animations.ContainsKey(key))
            {
                _animations[key].Start();
                _animations[key].Update();
                _lastKey = key;
            }
            else
            {
                _animations[_lastKey].Stop();
                _animations[_lastKey].Reset();
            }
        }

        public void Draw(Vector2 position)
        {
            _animations[_lastKey].Draw(position);
        }
    }
}
