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
    public class WindArea : Area
    {
        public Boolean left;
        public WindArea(Vector2 pos, int power, Boolean Left)
            : base(null, new Vector2(pos.X - power / 2, pos.Y - power / 2), new Vector2(power, power))
        {
            left = Left;
            lifetime = 3000;

        }

        public override void UpdateFX()
        {
            for (int i = 0; i < effects.Count; i++)
            {
                effects[i].Blow(left);
                if (effects[i].lifetime == 0)
                    effects[i] = null;
            }
            base.UpdateFX();
        }
        public override void MakeEffects()
        {
            if (!left)
            {
                for (int i = 0; i <= RNG.Next(0,5); i++)
                {
                    effects.Add(new Particles(new Vector2(pos.X, RNG.Next((int)pos.Y, (int)(pos.Y + dim.Y))),
                              leaves[RNG.Next(0,4)], 50));

                }
            }
            else
                for (int i = 0; i <= RNG.Next(0,5); i++)
                {
                    effects.Add(new Particles(new Vector2(pos.X + dim.X, RNG.Next((int)pos.Y, (int)(pos.Y + dim.Y))),
                              leaves[RNG.Next(0,4)], 50));

                }


        }
        public override void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            foreach (Particles p in effects)
            {
                p.DrawSelf(drawer, graphics, 15, 15);
            }

        }




    }
}
