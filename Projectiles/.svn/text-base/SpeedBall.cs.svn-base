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
    class SpeedBall : Projectile
    {
        static Texture2D BALL;
                static Texture2D fxtexture;
        public static void setTexture(Texture2D inFX)
        {
            fxtexture = inFX;
        }

        public SpeedBall(Vector2 pos, Vector2 spd, float power)
            : base(BALL, pos, new Vector2(25, 25), spd, power, fxtexture )
        {
        }
        public static void setImage(Texture2D img)
        {
            BALL = img;
        }
        public override void explode(List<Area> a)
        {
            a.Add(new SpeedArea(
                getCenter(), (int)power));
            base.explode(a);
        }
    }
}