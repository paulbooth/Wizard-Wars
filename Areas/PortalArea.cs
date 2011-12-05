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
    public class PortalArea : StationarySprite
    {
        public DateTime timeStamp;
        static Texture2D img1, img2;

        public PortalArea(DateTime ts, Vector2 pos, Vector2 dim) : base(null,pos,dim)
        {
            timeStamp = ts;
        }
        public static void setImages(Texture2D i1, Texture2D i2)
        {
            img1 = i1;
            img2 = i2;
        }
        public void draw(SpriteBatch drawer,int index)
        {
            drawer.Draw(index == 1 ? img1 : img2, getRect(), Color.White);
        }
    }
}
