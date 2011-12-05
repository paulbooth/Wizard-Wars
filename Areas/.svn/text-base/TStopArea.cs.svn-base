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
    public class TStopArea : Area
    {
        public TStopArea(Vector2 pos, int power)
            : base(null, new Vector2(pos.X - power / 2, pos.Y - power / 2), new Vector2(power, power))
        {
            lifetime = 3000;

        }

        public override void UpdateFX()
        {
            for (int i = 0; i < effects.Count; i++)
            {
                effects[i].Nothing();
                if (effects[i].lifetime == 0)
                    effects[i] = null;
            }
            base.UpdateFX();
        }
        public override void MakeEffects()
        {
            if (effects.Count >= 1) return;
            for (int i = 0; i < 1; i++)
            {
                effects.Add(new Particles(new Vector2(pos.X,pos.Y),clock, 30000));
            }
        }
        public override void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            foreach (Particles p in effects)
            {
                p.DrawSelf(drawer, graphics, (int)dim.X, (int)dim.Y);
            }
        }


    }
}
