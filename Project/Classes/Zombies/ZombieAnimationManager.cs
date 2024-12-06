using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Zombies
{
    public class ZombieAnimationManager
    {
        private Texture2D _death;
        private Texture2D _attack;
        private Texture2D _walk;
        private Texture2D _rise;

        // Variabelen voor frame-instellingen
        private int _frameWidth;        // Breedte van elk frame
        private int _frameHeight;       // Hoogte van elk frame
        private int _frameCount;        // Aantal frames per animatie
        private float _frameTime;       // Hoeveel seconden elk frame zichtbaar blijft
        private float _elapsedTime;     // Tijd die is verstreken voor frame-overgangen
        private int _currentFrame;      // Het huidige frame in de animatie
    }
}
