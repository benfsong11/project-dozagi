using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDozagi.Engine.Cores.Inputs
{
    public class MouseInput
    {
        public bool IsDragging { get; set; }

        public bool IsRightDragging { get; set; }

        public Vector2 Position { get; set; }
        
        public Vector2 OldPosition { get; set; }

        public Vector2 FirstPosition { get; set; }

        public Vector2 AdjustedPosition { get; set; }

        public Vector2 SystemCursorPosition { get; set; }

        public Vector2 ScreenLocation { get; set; }

        public MouseState FirstState { get; set; }

        public MouseState OldState { get; set; }

        protected MouseState State { get; set; }

        public MouseInput()
        {
            IsDragging = false;

            State = Mouse.GetState();
            OldState = State;
            FirstState = State;

            Position = new Vector2(State.Position.X, State.Position.Y);
            OldPosition = new Vector2(State.Position.X, State.Position.Y);
            FirstPosition = new Vector2(State.Position.X, State.Position.Y);

            GetMouseAndAdjust();
        }

        public void Update()
        {
            GetMouseAndAdjust();

            if (State.LeftButton == ButtonState.Pressed && OldState.LeftButton == ButtonState.Released)
            {
                FirstState = State;
                FirstPosition = GetScreenPosition(State);
                Position = GetScreenPosition(State);
            }
        }

        public void OldUpdate()
        {
            OldState = State;
            OldPosition = GetScreenPosition(OldState);
        }

        public virtual float GetDistanceFromClick()
        {
            return Global.GetDistance(Position, FirstPosition);
        }

        public virtual void GetMouseAndAdjust()
        {
            State = Mouse.GetState();
            Position = GetScreenPosition(State);
        }

        public int GetMouseWheelChange()
        {
            return State.ScrollWheelValue - OldState.ScrollWheelValue;
        }

        public Vector2 GetScreenPosition(MouseState state)
        {
            Vector2 ret = new Vector2(state.Position.X, state.Position.Y);

            return ret;
        }

        public virtual bool LeftClick()
        {
            if (State.LeftButton == ButtonState.Pressed &&
                OldState.LeftButton != ButtonState.Pressed &&
                State.Position.X >= 0 &&
                State.Position.X <= Global.ScreenSize.Width &&
                State.Position.Y >= 0 &&
                State.Position.Y <= Global.ScreenSize.Height) 
            {
                return true;
            }

            return false;
        }

        public virtual bool LeftClickHold()
        {
            bool isHolding = false;

            if (State.LeftButton == ButtonState.Pressed &&
                OldState.LeftButton != ButtonState.Pressed &&
                State.Position.X >= 0 &&
                State.Position.X <= Global.ScreenSize.Width &&
                State.Position.Y >= 0 &&
                State.Position.Y <= Global.ScreenSize.Height)
            {
                isHolding = true;
                
                if (Math.Abs(State.Position.X - FirstState.Position.X) > 8 ||
                    Math.Abs(State.Position.Y - FirstState.Position.Y) > 8) 
                {
                    IsDragging = true;
                }
            }

            return isHolding;
        }

        public virtual bool LeftClickRelease()
        {
            if (State.LeftButton == ButtonState.Released &&
                OldState.LeftButton == ButtonState.Pressed)
            {
                IsDragging = false;

                return true;
            }

            return false;
        }

        public virtual bool RightClick()
        {
            if (State.RightButton == ButtonState.Pressed &&
                OldState.RightButton != ButtonState.Pressed &&
                State.Position.X >= 0 &&
                State.Position.X <= Global.ScreenSize.Width &&
                State.Position.Y >= 0 &&
                State.Position.Y <= Global.ScreenSize.Height)
            {
                return true;
            }

            return false;
        }

        public virtual bool RightClickHold()
        {
            bool isHolding = false;

            if (State.RightButton == ButtonState.Pressed &&
                OldState.RightButton != ButtonState.Pressed &&
                State.Position.X >= 0 &&
                State.Position.X <= Global.ScreenSize.Width &&
                State.Position.Y >= 0 &&
                State.Position.Y <= Global.ScreenSize.Height)
            {
                isHolding = true;

                if (Math.Abs(State.Position.X - FirstState.Position.X) > 8 ||
                    Math.Abs(State.Position.Y - FirstState.Position.Y) > 8)
                {
                    IsDragging = true;
                }
            }

            return isHolding;
        }

        public virtual bool RightClickRelease()
        {
            if (State.RightButton == ButtonState.Released &&
                OldState.RightButton == ButtonState.Pressed)
            {
                IsDragging = false;

                return true;
            }

            return false;
        }
    }
}
