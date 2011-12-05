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
    class PortalBall : Projectile
    {
        static Texture2D IMG;
        static Texture2D fxtexture;
        public static void setTexture(Texture2D inFX)
        {
            fxtexture = inFX;
        }

        public PortalBall(Vector2 pos, Vector2 spd, float power)
            : base(IMG, pos, new Vector2(25, 25), spd, power, fxtexture)
        {

        }
        public static void setImg(Texture2D img) { IMG = img; }

        public override void explode(WizardWars game)
        {
            game.portals[game.earlierPortal()] = 
                new PortalArea(DateTime.Now, getCenter(), new Vector2(power/5,power/5));
            base.explode(game);
        }
    }
}
