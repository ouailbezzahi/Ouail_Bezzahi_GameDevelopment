using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project.Classes.Hero
{
    // De HeroAnimationManager klasse beheert alle animaties voor de held.
    public class HeroAnimationManager
    {
        // Texture2D objecten voor de verschillende animaties
        private Texture2D _idleTexture;
        private Texture2D _walkTexture;
        private Texture2D _shootTexture;
        private Texture2D _jumpTexture;

        // Variabelen voor frame-instellingen
        private int _frameWidth;        // Breedte van elk frame
        private int _frameHeight;       // Hoogte van elk frame
        private int _frameCount;        // Aantal frames per animatie
        private float _frameTime;       // Hoeveel seconden elk frame zichtbaar blijft
        private float _elapsedTime;     // Tijd die is verstreken voor frame-overgangen
        private int _currentFrame;      // Het huidige frame in de animatie

        // De naam van de huidige animatie die wordt afgespeeld
        private string _currentAnimation;

        // Huidige animatie data (zoals texture, aantal frames, etc.)
        private Animation _currentAnimationData;

        // Constructor voor de HeroAnimationManager
        public HeroAnimationManager(Texture2D idleTexture, Texture2D walkTexture, Texture2D shootTexture, Texture2D jumpTexture, int frameWidth, int frameHeight, int frameCount, float frameTime)
        {
            // Initialiseren van de texturen voor elke animatie
            _idleTexture = idleTexture;
            _walkTexture = walkTexture;
            _shootTexture = shootTexture;
            _jumpTexture = jumpTexture;

            // Initialiseren van de frame-afmetingen
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;

            // Initialiseren van het aantal frames en de tijd per frame
            _frameCount = frameCount;
            _frameTime = frameTime;

            // Beginwaarden voor het bijhouden van tijd en het huidige frame
            _elapsedTime = 0f;
            _currentFrame = 0;

            // Start met de "Idle" animatie als standaard
            _currentAnimation = "Idle";
            SetAnimation("Idle");
        }

        // Methode om de animatie in te stellen op basis van de naam van de animatie
        public void SetAnimation(string animation)
        {
            // Als de nieuwe animatie hetzelfde is als de huidige, doe dan niets
            if (_currentAnimation == animation) return;

            // Stel de huidige animatie in
            _currentAnimation = animation;

            // Kies de juiste animatie op basis van de naam
            switch (_currentAnimation)
            {
                case "Idle":
                    // Stel de animatie in voor de idle toestand met 7 frames
                    _currentAnimationData = new Animation(_idleTexture, _frameWidth, _frameHeight, 7, _frameTime);
                    break;
                case "Walk":
                    // Stel de animatie in voor het lopen met 6 frames
                    _currentAnimationData = new Animation(_walkTexture, _frameWidth, _frameHeight, 6, _frameTime);
                    break;
                case "Shoot":
                    // Stel de animatie in voor schieten met 6 frames
                    _currentAnimationData = new Animation(_shootTexture, _frameWidth, _frameHeight, 6, _frameTime);
                    break;
                case "Jump":
                    // Stel de animatie in voor springen met 3 frames
                    _currentAnimationData = new Animation(_jumpTexture, _frameWidth, _frameHeight, 3, _frameTime);
                    break;
                default:
                    // Fallback naar de idle animatie als er een onbekende naam is
                    _currentAnimationData = new Animation(_idleTexture, _frameWidth, _frameHeight, 7, _frameTime);
                    break;
            }

            // Reset het huidige frame en de verstreken tijd elke keer wanneer een nieuwe animatie begint
            _currentFrame = 0;
            _elapsedTime = 0f;
        }

        public void Update(GameTime gameTime)
        {
            // Als er geen animatie is ingesteld, doe dan niets
            if (_currentAnimationData == null) return;

            // Voeg de verstreken tijd toe aan de tijd voor de animatie
            _elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Controleer of het tijd is om naar het volgende frame te gaan
            if (_elapsedTime >= _currentAnimationData.FrameTime)
            {
                // Verwijder de tijd die is verstreken
                _elapsedTime -= _currentAnimationData.FrameTime;

                // Ga naar het volgende frame
                _currentFrame++;

                // Als we voorbij het laatste frame zijn, begin dan opnieuw (indien de animatie herhalend is)
                if (_currentFrame >= _currentAnimationData.FrameCount)
                {
                    // Als de animatie in een lus is, begin dan opnieuw vanaf frame 0
                    _currentFrame = _currentAnimationData.IsLooping ? 0 : _currentAnimationData.FrameCount - 1;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            // Als er geen animatie is ingesteld, doe dan niets
            if (_currentAnimationData == null) return;

            // Bepaal het gedeelte van de texture dat moet worden getekend (huidige frame)
            Rectangle sourceRectangle = new Rectangle(_currentFrame * _frameWidth, 0, _frameWidth, _frameHeight);

            // Teken de juiste frame van de animatie op de gegeven positie
            spriteBatch.Draw(_currentAnimationData.Texture, position, sourceRectangle, color);
        }

        // Een interne klasse die de eigenschappen van een animatie definieert
        private class Animation
        {
            // Eigenschappen van de animatie
            public Texture2D Texture { get; }   // De tekstuur voor deze animatie
            public int FrameWidth { get; }       // De breedte van elk frame
            public int FrameHeight { get; }      // De hoogte van elk frame
            public int FrameCount { get; }       // Het aantal frames in de animatie
            public float FrameTime { get; }      // Hoeveel tijd elke frame wordt weergegeven
            public bool IsLooping { get; }       // Bepaalt of de animatie moet herhalen (default true)

            // Constructor voor de animatie
            public Animation(Texture2D texture, int frameWidth, int frameHeight, int frameCount, float frameTime)
            {
                // Initialiseer de eigenschappen van de animatie
                Texture = texture;
                FrameWidth = frameWidth;
                FrameHeight = frameHeight;
                FrameCount = frameCount;
                FrameTime = frameTime;
                IsLooping = true; // Standaard wordt de animatie herhaald
            }
        }
    }
}
