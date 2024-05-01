using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ProjectDozagi.Engine.Cores.Inputs
{
    public class KeyboardInput
    {
        public KeyboardState State { get; set; }

        public KeyboardState OldState { get; set; }

        public List<Key> PressedKeys { get; set; }
        public List<Key> OldPressedKeys { get; set; }

        public KeyboardInput()
        {
            PressedKeys = new List<Key>();
            OldPressedKeys = new List<Key>();
        }

        public virtual void Update()
        {
            State = Keyboard.GetState();

            GetPressedKeys();
        }

        public void OldUpdate()
        {
            OldState = State;

            OldPressedKeys = new List<Key>();

            foreach (var pressedKey in PressedKeys)
            {
                OldPressedKeys.Add(pressedKey);
            }
        }

        public bool GetPress(string key)
        {
            foreach (var pressedKey in PressedKeys) 
            {
                if (pressedKey.Current == key)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void GetPressedKeys()
        {
            PressedKeys.Clear();

            for (int i = 0; i < State.GetPressedKeys().Length; ++i)
            {
                PressedKeys.Add(new Key(State.GetPressedKeys()[i].ToString(), 1));
            }
        }
    }
}
