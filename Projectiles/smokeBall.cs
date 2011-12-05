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
    class SmokeBall : Projectile
    {
        static Texture2D IMG;
        static Texture2D fxtexture;
        public int plnum;
        public static void setTexture(Texture2D inFX)
        {
            fxtexture = inFX;
        }
        public SmokeBall(Vector2 pos, Vector2 spd, float power, int player)
            : base(IMG, pos, new Vector2(25, 25), spd, power,fxtexture)
        {
            plnum = player;
        }
        public static void setImages(Texture2D img)
        {
            IMG = img;
        }
        public override void explode(List<Area> areas)
        {
            areas.Add(new SmokeArea(getCenter(), (int)power));
            base.explode(areas);
        }
    }
}
