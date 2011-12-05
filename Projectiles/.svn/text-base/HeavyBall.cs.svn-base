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
    public class HeavyBall: Projectile
    {
        static Texture2D IMG;
        static Texture2D fxtexture;
        public static void setTexture(Texture2D inFX)
        {
            fxtexture = inFX;
        }

        public HeavyBall(Vector2 pos,Vector2 spd,float power)
            : base(IMG, pos, new Vector2(25,25),spd,power, fxtexture)
        {
        }
        public static void setImg(Texture2D img) { IMG = img; }
        
        public override void explode(List<Area> a)
        {
            a.Add(new HeavyArea(IMG,
                pos, (int)power));
            base.explode(a);
        }
    }
}

    

