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
    class TimeWizard : Player
    {

        public TimeWizard(Texture2D img, List<Platform> starts, float power,int playerNum)
            : base(img, starts, power,playerNum)
        {
        }

        public override Projectile ability1()
        {
            if (firetime1.AddMilliseconds(4000).CompareTo(DateTime.Now) < 0)
            {
                firetime1 = DateTime.Now;
                return new TStopBall(pos, getProjectileSpeed(),  power);

            }
            else
                return null;
        }
        public override Projectile ability2()
        {
            if (firetime2.AddMilliseconds(300).CompareTo(DateTime.Now) < 0)
            {
                firetime2 = DateTime.Now;
                return new SpeedBall(pos, getProjectileSpeed(),  power);

            }
            else
                return null;
        }
    }
}
