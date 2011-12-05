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
    class SmokeArea :Area
    {
        //public Random RNG = new Random();
        const int smokeX=20, smokeY=20;
        int pwr;
        public SmokeArea(Vector2 pos1, int power)
            : base(null, new Vector2(pos1.X+power*.75f,pos1.Y+power*1.5f), new Vector2(power *1.5f, power *1.5f))
        {
            pwr = power;
            lifetime = 6000;
        }
        public override void UpdateFX()
        {
            pos.X += RNG.Next(-2, 2);
            pos.Y += RNG.Next(-3, 2);
            dim.X += 1;
            dim.Y += 1;
            base.UpdateFX();
        }
        public override void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            byte bit = 100;
            drawer.Draw(smoke, new Rectangle((int)(pos.X-pwr*1.5f), (int)(pos.Y-pwr*1.5f), (int)dim.X, (int)dim.Y),
            new Color(bit,bit,bit,180));
            
        }

    }
}
