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
    class FireBall:Projectile
    {
        Vector2 center;
        float dist = 0;
        const float concentration = 1;
        const float minimum_distance = 3;
        static Texture2D IMG;
        public int plnum;
        static Texture2D fxtexture;
        public static void setTexture(Texture2D inFX)
        {
            fxtexture = inFX;
        }

        public FireBall( Vector2 pos, Vector2 spd, float power, int pln)
            : base(IMG, pos, new Vector2(33, 19), spd, power, fxtexture) { plnum = pln; }

    public override void explode(List<Platform> platforms,List<GravitySprite> gravs)
        {
            center = this.getCenter();
        
            
            
            foreach (Platform pl in platforms)
            {
                for (int a = 0; a < pl.dim.X; a++)
                {

                    //    pl.heights[a] = (int)Math.Max(pl.heights[a] +.5 -(power / 
                    //       (dist*100 + .01) * concentration),0);
                    dist = (float)Math.Min(Math.Sqrt((center.X - (pl.pos.X + a)) *
                                (center.X - (pl.pos.X + a))
                         + (center.Y - (pl.pos.Y - pl.heights[a])) *
                            (center.Y - (pl.pos.Y - pl.heights[a]))
                         ),
                        Math.Sqrt((center.X - (pl.pos.X + a)) *
                                (center.X - (pl.pos.X + a))
                         + (center.Y - pl.pos.Y) *
                            (center.Y - pl.pos.Y)));
                    dist = (float)Math.Max(dist, minimum_distance);
                    if (dist < power)
                    {
                        pl.heights[a] = Math.Max(pl.heights[a]-2*(int)(concentration * (power / dist)),1);
                    }


                }
                pl.redoCurve();
            }
            //p.dmg((int)(pos.X - 20), (int)(pos.X + dim.X + 20), (int)(power / 2));
            //p.redoCurve();
            foreach (GravitySprite g in gravs)
            {
                dist = distance(g);
                
                if (dist < power)
                {
                    float tempx=(g.getCenter().X - center.X);

                        tempx=tempx> 0 ?
                        Math.Max(g.getCenter().X - center.X, minimum_distance) :
                        Math.Min(g.getCenter().X - center.X, -minimum_distance);

                        float tempy = (g.getCenter().Y - center.Y);

                        tempy=tempy> 0 ?
                        Math.Max(g.getCenter().Y - center.Y, minimum_distance) :
                        Math.Min(g.getCenter().Y - center.Y, -minimum_distance);

                    double angle = Math.Atan2(tempy, tempx);
                    float velocity = power * concentration / Math.Max(distance(g),minimum_distance);
                    g.speed += new Vector2((float)(100*velocity * Math.Cos(angle)),
                                    (float)(100*velocity * Math.Sin(angle)));


                    if (g is Player && (g as Player).playernumber != plnum)
                    {
                        (g as Player).Stun(1000);
                       // if (plnum == 1)
                      //(g as Player).Vibrate(1000);
                    if(plnum==0)
                        GamePad.SetVibration(PlayerIndex.Two, 1f, 1f);
                        
                    }
                }

            }
                
            base.explode(platforms, gravs);
        }
        public static void setIMG(Texture2D img)
        {
            IMG = img;
        }

        
    }
}
