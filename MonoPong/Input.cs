﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoPong
{
    public class Input
    {
        public static List<GestureSample> Gestures;

        static Input()
        {
            Gestures = new List<GestureSample>();
        }

        public static Vector2 GetKeyboardInputDirection(PlayerIndex playerIndex)
        {
            Vector2 direction = Vector2.Zero;
            KeyboardState keyboardState = Keyboard.GetState(playerIndex);

            if (playerIndex == PlayerIndex.One)
            {
                if(keyboardState.IsKeyDown(Keys.W))
                    direction.Y -= 1;

                if (keyboardState.IsKeyDown(Keys.S))
                    direction.Y += 1;
            }

            if (playerIndex == PlayerIndex.Two)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                    direction.Y -= 1;

                if (keyboardState.IsKeyDown(Keys.Down))
                    direction.Y += 1;
            }

            return direction;
        }

        public static void ProcessTouchInput(out Vector2 playerVelocity1, out Vector2 playerVelocity2)
        {
            Gestures.Clear();
            while (TouchPanel.IsGestureAvailable)
            {
                Gestures.Add(TouchPanel.ReadGesture());
            }

            playerVelocity1 = Vector2.Zero;
            playerVelocity2 = Vector2.Zero;

            foreach (GestureSample gs in Gestures)
            {
                if (gs.GestureType == GestureType.FreeDrag)
                {
                    if (gs.Position.X >= 0 && gs.Position.X <= Game1.ScreenWith / 2)
                        playerVelocity1.Y += gs.Delta.Y;

                    if (gs.Position.X >= Game1.ScreenWith / 2 && gs.Position.X <= Game1.ScreenWith)
                        playerVelocity2.Y += gs.Delta.Y;
                }
            }
        }
    }
}
