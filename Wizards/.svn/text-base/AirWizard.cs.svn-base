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
    class AirWizard : Player
    {
        public AirWizard(Texture2D img, List<Platform> starts, float power, int plnum)
            : base(img, starts, power, plnum)
        {

        }

        public override Projectile ability1()
        {
            if (firetime1.AddMilliseconds(300).CompareTo(DateTime.Now) < 0)
            {
                firetime1 = DateTime.Now;                
                return new WindBall(pos, getProjectileSpeed(), power);
            }
            else
                return null;
        }
        public override Projectile ability2()
        {
            if (firetime1.AddMilliseconds(1000).CompareTo(DateTime.Now) < 0)
            {
                firetime1 = DateTime.Now;
                return new LightningBall(pos, getProjectileSpeed(), power);

            }
            else
                return null;
        }
    }
}
