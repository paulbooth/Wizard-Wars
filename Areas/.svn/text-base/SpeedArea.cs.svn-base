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
    public class SpeedArea : Area
    {
        public SpeedArea(Vector2 pos, int power)
            : base(null, new Vector2(pos.X - power / 2, pos.Y - power / 2), new Vector2(power, power))
        {
            lifetime = 3000;

        }

        public override void UpdateFX()
        {
            for (int i = 0; i < effects.Count; i++)
            {
                effects[i].Blow(false);
                if (effects[i].lifetime == 0)
                    effects[i] = null;
            }
            base.UpdateFX();
        }
        public override void MakeEffects()
        {
                for (int i = 0; i <= RNG.Next(5, 10); i++)
                {
                    effects.Add(new Particles(new Vector2(pos.X,
                    RNG.Next((int)pos.Y, (int)(pos.Y + dim.Y))), clock, (int)dim.X));
                }
        }
        public override void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            foreach (Particles p in effects)
            {
                p.DrawSelf(drawer, graphics, 20, 20);
            }
        }


    }
}
