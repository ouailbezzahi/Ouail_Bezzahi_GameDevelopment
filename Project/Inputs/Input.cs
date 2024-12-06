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

        private static MouseState _currentMouseState;
        private static MouseState _previousMouseState;

        public static void Update()
        {
            //Vorige status wordt de nieuwe/huidige status en dan krijgt deze de GetState() methode
            _previousKeyBoardState = _currentKeyBoardState;
            _currentKeyBoardState = Keyboard.GetState();

            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
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

        // Controle of de linkermuisknop ingedrukt is
        public static bool isLeftMouseClicked() =>
            _currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released;

        //Bewegingen
        public static bool MoveLeft() => IsKeyHeld(Keys.Q); //Q naar links
        public static bool MoveRight() => IsKeyHeld(Keys.D); //D naar rechts

        //Springen
        public static bool Jump() => IsKeyHeld(Keys.Z); //Z springen

        //Schieten
        public static bool Shoot() => isLeftMouseClicked(); //Muisklik schieten

    }
}
