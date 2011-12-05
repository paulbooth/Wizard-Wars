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
    public class ReverseArea:Area
    
    {

        public ReverseArea(Texture2D img, Vector2 pos, int power)
            : base(img, new Vector2(pos.X-power/2, pos.Y-power), new Vector2(power, power))
        {
            lifetime = 5000;
        }

        public override void UpdateFX()
        {
            for (int i = 0; i < effects.Count; i++)
            {
                effects[i].Rise();
                if (effects[i].lifetime == 0)
                    effects[i] = null;
            }
            base.UpdateFX();
        }
        public override void MakeEffects()
        {
            for (int i = 0; i <= RNG.Next(1, 1); i++)
            {
                effects.Add(new Particles(new Vector2(RNG.Next((int)pos.X, (int)(pos.X + dim.X)), pos.Y + dim.Y),
                       uparrows, 50));

            }
        }

    }
}
