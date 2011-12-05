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
    class WindBall : Projectile
    {
        static Texture2D IMG;
        static Texture2D fxtexture;
        public static void setTexture(Texture2D inFX)
        {
            fxtexture = inFX;
        }

        public WindBall(Vector2 pos, Vector2 spd,  float power)
            : base(IMG, pos, new Vector2(30, 12), spd, power, fxtexture)
        {
        }
        public static void setImage(Texture2D img)
        {
            IMG = img;
        }
        public override void explode(List<Area> areas)
        {
            if( speed.X <=0)
                areas.Add(new WindArea(new Vector2(pos.X, pos.Y), (int)power, true));
            else
            {
                areas.Add(new WindArea(new Vector2(pos.X, pos.Y), (int)power, false));
            }
            base.explode(areas);
        }
    }
}
