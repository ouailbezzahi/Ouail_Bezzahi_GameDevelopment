using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Functions;
using Project.Inputs;
using Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Characters
{
    public class Hero : IGameObject
    {
        private Texture2D _heroTexture;
        private Vector2 _position;
        private float _speed = 2f;
        private Rectangle _deelRectangle;
        private Weapon _weapon;

        public Hero(Texture2D texture)
        {
            _position = new Vector2(10, 10);
            _heroTexture = texture;
            _deelRectangle = new Rectangle(0, 0, 80, 94);
            _weapon = new Weapon(3f);
        }
        public void Update(GameTime gameTime)
        {

            if (Input.MoveUp())
            {
                _position.Y -= _speed;
            }
            if (Input.MoveDown())
            {
                _position.Y += _speed;
            }
            if (Input.MoveLeft())
            {
                _position.X -= _speed;
            }
            if (Input.MoveRight())
            {
                _position.X += _speed;
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
            spriteBatch.Draw(_heroTexture, _position, _deelRectangle, Color.White);

            //Teken de bullets
            //Hier nieuwe commando ervoor dus klasse.Draw(spriteBatch)
        }
        public void UpgradeWeapon()
        {
            _weapon.Upgrade();
        }
    }
}
