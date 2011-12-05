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
    class stalagball : Projectile
    {
        static Texture2D IMG;
        static Texture2D fxtexture;
        public static void setTexture(Texture2D inFX)
        {
            fxtexture = inFX;
        }

        public stalagball(Vector2 pos, Vector2 spd, float power)
            : base(IMG, pos,new Vector2(20,20), spd, power, fxtexture)
        {

        }
        public static void setIMG(Texture2D img)
        {
            IMG = img;
        }
        public override void explode(Platform p)
        {
            p.dmg((int)pos.X-5, (int)(pos.X + dim.X)+5, (int)-power);
            base.explode(p);
        }

    }
}
