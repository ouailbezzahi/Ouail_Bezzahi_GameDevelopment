using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Inputs
{
    public static class Input
    {
        private static KeyboardState _currentKeyBoardState;
        private static KeyboardState _previousKeyBoardState;

        public static void Update()
        {
            //Vorige status wordt de nieuwe/huidige status en dan krijgt deze de GetState() methode
            _previousKeyBoardState = _currentKeyBoardState;
            _currentKeyBoardState = Keyboard.GetState();
        }

        public static bool IsKeyPressed(Keys key)
        {
            //Controle of er 1 toets is ingedrukt
            bool isPressed = _currentKeyBoardState.IsKeyDown(key) && !_previousKeyBoardState.IsKeyDown(key);
            return isPressed;
        }
        public static bool IsKeyHeld(Keys key)
        {
            //Controle of een toets ingedrukt wordt gehouden
            return _currentKeyBoardState.IsKeyDown(key);
        }
        
        //Bewegingen instellen
        public static bool MoveUp() => IsKeyHeld(Keys.Up);
        public static bool MoveDown() => IsKeyHeld(Keys.Down);
        public static bool MoveLeft() => IsKeyHeld(Keys.Left);
        public static bool MoveRight() => IsKeyHeld(Keys.Right);

        //Schieten instellen
        public static bool Shoot() => IsKeyHeld(Keys.Space);

    }
}
