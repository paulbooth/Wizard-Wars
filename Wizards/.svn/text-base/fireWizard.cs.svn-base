using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace WizardWars
{
    class FireWizard : Player
    {
        public float fireangle = -.1f, firespeed = 300;
        public FireWizard(Texture2D img, List<Platform> starts,float power,int plnum)
            : base(img, starts,power,plnum)
        {
        }

        public override Projectile ability1()
        {           
            if (firetime1.AddMilliseconds(250).CompareTo(DateTime.Now) < 0)
            {
                firetime1 = DateTime.Now;

                return new FireBall(pos, getProjectileSpeed(), power, playernumber);
            }
            else
                return null;
        }
        public override Projectile ability2()
        {
            if (firetime1.AddMilliseconds(100).CompareTo(DateTime.Now) < 0)
            {
                firetime1 = DateTime.Now;
                return new SmokeBall(pos, getProjectileSpeed()+new Vector2(RNG.Next(-50,50),RNG.Next(-50,50)), power,playernumber);
               
            }
            else
                return null;
            
            
        }
    }
}
