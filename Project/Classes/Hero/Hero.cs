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
    public class Hero : IGameObject
    {
        private Texture2D _heroTexture;
        private Vector2 _position;
        private float _speed;
        private Weapon _weapon;
        public HeroAnimationManager animManager;

        private bool _isJumping;
        private float _jumpSpeed = -300f; //sprongsnelheid
        private float _gravity = 800f; //zwaartekracht
        private float _velocity; //Verticale snelheid

        //Constructor

        public Hero(Texture2D texture, Vector2 startPosition, float speed)
        {
            _heroTexture = texture;
            _position = startPosition;
            _speed = speed;
            _isJumping = false;
        }
        public void Update(GameTime gameTime)
        {
            //Verstreken tijd
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Beweeg naar links
            if (Input.MoveLeft())
            {
                _position = new Vector2(_position.X - _speed * deltaTime, _position.Y);
            }
            //Beweeg naar rechts
            if (Input.MoveRight())
            {
                _position = new Vector2(_position.X + _speed * deltaTime, _position.Y);
            }
            //Springen
            if (Input.Jump() && !_isJumping)
            {
                _isJumping = true;
                _velocity = _jumpSpeed;
            }

            //Toepassen zwaartekracht
            if (_isJumping)
            {
                _velocity += _gravity * deltaTime;

                //Controle of held de grond raakt
                if (_position.Y >= 400) //400 is dus grondniveau maar kan later veranderd worden
                {
                    _isJumping = false;
                    _position = new Vector2(_position.X, 400); //Terug naar de grond zetten
                }
            }
            if (Input.Shoot())
            {
                //nog een commando erbij schrijven
            }

            //commando moet hier geupdate worden (nieuwe klasse die shoot definieert)!
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Tekent de hero
            spriteBatch.Draw(_heroTexture, _position, Color.White);

            //Teken de bullets
            //Hier nieuwe commando ervoor dus klasse.Draw(spriteBatch)
        }
        public void UpgradeWeapon()
        {
            _weapon.Upgrade();
        }
    }
}
