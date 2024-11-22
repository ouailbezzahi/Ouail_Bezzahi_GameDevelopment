using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Weapons
{
    public class Weapon
    {
        //Tijd tussen geschoten kogels in seconden
        private float _fireRate;
        //Tijd sinds het laatst gevuurde schot
        private float _timeSinceLastShot;

        public Weapon(float fireRate)
        {
            _fireRate = fireRate;
            _timeSinceLastShot = 0f;
        }
        public bool CanShoot(GameTime gameTime)
        {
            //Hoeveelheid tijd sinds vorige frame-update
            _timeSinceLastShot = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timeSinceLastShot >= _fireRate)
            {
                //Wanneer de tijd sinds laatste shot groter of gelijk is aan de vuursnelheid, wordt dit gereset en geeft dit true terug
                _timeSinceLastShot = 0f;
                return true;
            }
            return false;
        }
        public void Upgrade()
        {
            //Upgrade wapen, verlaag snelheid
            if (_fireRate > 0.1f)
            {
                _fireRate -= 0.1f;
            }
        }
    }
}
