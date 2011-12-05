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
    class LightningBall : Projectile
    {
        static Texture2D LIGHTNING;
        static Texture2D BALL;
        static Texture2D fxtexture;
        public static void setTexture(Texture2D inFX)
        {
            fxtexture = inFX;
        }

        public LightningBall(Vector2 pos, Vector2 spd, float power)
            : base(BALL, pos, new Vector2(25, 25), spd, power, fxtexture)
        {
        }
        public static void setImages(Texture2D img,Texture2D light)
        {
            BALL = img; 
            LIGHTNING = light;
        }
        public override void explode(List<Platform> plats,WizardWars game)
        {
            Platform p=Ground.get();
            for (int i = 0; i < plats.Count; i++)
            {
                if (pos.X>plats[i].pos.X && pos.X+dim.X<plats[i].pos.X+plats[i].dim.X
                        && plats[i].pos.Y < p.pos.Y)
                    p = plats[i];
            }
            
            Vector2 impactPt = new Vector2(getCenter().X, p.pos.Y -
                p.maxHeight((int)pos.X, (int)(pos.X + dim.X)));
            game.lightningDim = new Vector2(100, impactPt.Y);
            game.lightningPos = new Vector2(impactPt.X - game.lightningDim.X * .1818f,
                                            impactPt.Y - game.lightningDim.Y * .992f);
            game.drawLightning = true;
            p.dmg((int)pos.X - 10, (int)(pos.X + dim.X + 10), (int)power);
            for (int i = 0; i < game.players.Length; i++)
                if (!(game.players[i] is AirWizard)) 
                    game.players[i].Stun((power / Math.Max(StationarySprite.distance
                        (impactPt,game.players[i].getCenter()),20)*800));
            base.explode(plats,game);
        }
    }
}