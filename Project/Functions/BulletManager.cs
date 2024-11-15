using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Project.Functions
{
    public class BulletManager
    {
        //sprite kogels
        private Texture2D _bulletTexture2D; 
        //lijst kogels
        private List<Vector2> _bullets;
        //Snelheid kogels
        private float _bulletSpeed = 50f;

        public BulletManager()
        {
            //Nieuwe lijst aanmaken
            _bullets = new List<Vector2>();
        }
        public void LoadContent(ContentManager content)
        {
            //bullet spritesheet opladen
            _bulletTexture2D = content.Load<Texture2D>("Bullets");
        }
        public void Shoot(Vector2 startPosition)
        {

        }

    }
}
