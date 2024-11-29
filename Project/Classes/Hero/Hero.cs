using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Classes.Weapons;
using Project.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Hero
{
    public class Hero
    {
        private Texture2D _idleTexture;
        private Texture2D _walkTexture;
        private Texture2D _shootTexture;
        private Texture2D _jumpTexture;

        private Vector2 _position;
        private float _speed;

        private bool _isJumping;
        private bool _isShooting;
        private float _jumpSpeed = -300f; // Sprongsnelheid
        private float _gravity = 800f;    // Zwaartekracht
        private float _velocity;         // Verticale snelheid

        private HeroAnimationManager _animManager; // Animatie Manager

        private const float GroundLevel = 400f; // Grondniveau

        // Constructor
        public Hero(Texture2D idleTexture, Texture2D walkTexture, Texture2D shootTexture, Texture2D jumpTexture, Vector2 startPosition, float speed)
        {
            _idleTexture = idleTexture;
            _walkTexture = walkTexture;
            _shootTexture = shootTexture;
            _jumpTexture = jumpTexture;

            _position = startPosition;
            _speed = speed;

            _isJumping = false;
            _isShooting = false;

            // Initialiseer de animatiemanager
            _animManager = new HeroAnimationManager(
                _idleTexture,
                _walkTexture,
                _shootTexture,
                _jumpTexture,
                80,  // Frame width
                90,  // Frame height
                6,   // Aantal frames per animatie
                0.1f // Frame time
            );

            // Zet de animatie naar Idle zodra de held wordt aangemaakt
            _animManager.SetAnimation("Idle");
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Beweging (horizontaal)
            if (Input.MoveLeft())
            {
                _position = new Vector2(_position.X - _speed * deltaTime, _position.Y);
                _animManager.SetAnimation("Walk"); // Zet de animatie op walk
            }
            else if (Input.MoveRight())
            {
                _position = new Vector2(_position.X + _speed * deltaTime, _position.Y);
                _animManager.SetAnimation("Walk"); // Zet de animatie op walk
            }
            else if (!_isJumping) // Alleen idle wanneer de speler niet springt
            {
                // Wanneer er geen beweging is en de speler niet springt, toon de idle animatie
                _animManager.SetAnimation("Idle");
            }

            // Springen
            if (Input.Jump() && !_isJumping)
            {
                _isJumping = true;
                _velocity = _jumpSpeed; // Begin met de sprongsnelheid
                _animManager.SetAnimation("Jump"); // Zet de jump animatie in gang
            }

            // Als de speler springt, pas de verticale snelheid en positie aan
            if (_isJumping)
            {
                _velocity += _gravity * deltaTime; // Pas de zwaartekracht toe

                // Verander de positie van de speler
                _position = new Vector2(_position.X, _position.Y + _velocity * deltaTime);

                // Controleer of de speler de grond heeft bereikt
                if (_position.Y >= GroundLevel)
                {
                    _isJumping = false;
                    _position = new Vector2(_position.X, GroundLevel); // Zet de speler op de grond
                    _velocity = 0f; // Zet de verticale snelheid weer op 0

                    // Pas de animatie aan zodra de speler weer op de grond staat
                    if (Input.MoveLeft() || Input.MoveRight())
                    {
                        _animManager.SetAnimation("Walk"); // Als er beweging is, toon de walk animatie
                    }
                    else
                    {
                        _animManager.SetAnimation("Idle"); // Als er geen beweging is, toon de idle animatie
                    }
                }
            }

            // Schieten (indien ingedrukt)
            if (Input.Shoot())
            {
                _isShooting = true;
                _animManager.SetAnimation("Shoot"); // Zet de shoot animatie in gang
            }

            // Update de animatie
            _animManager.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _animManager.Draw(spriteBatch, _position, Color.White);
        }
    }

}
