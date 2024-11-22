using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes.Hero
{
    public class HeroAnimationManager
    {
        //Idle
        public List<Texture2D> idleAnimation = new List<Texture2D>();
        //Walk
        public List<Texture2D> walkAnimation = new List<Texture2D>();
        //Jump
        public List<Texture2D> jumpAnimation = new List<Texture2D>();
        //Shoot
        public List<Texture2D> shootAnimation = new List<Texture2D>();
        //Death
        public List<Texture2D> deathAnimation = new List<Texture2D>();
        //Current
        public List<Texture2D> currentAnimation = new List<Texture2D>();
    }
}
