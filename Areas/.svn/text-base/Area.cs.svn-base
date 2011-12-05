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
    public class Area : StationarySprite
    {
        protected static Texture2D uparrows;
        protected static Texture2D downarrows;
        protected static Texture2D clock;
        protected static Texture2D[] leaves=new Texture2D[4];
        protected static Texture2D smoke;

        protected Random RNG = new Random();
        public int lifetime;
        public DateTime creation;
        public static void SetFX(Texture2D UP, Texture2D DOWN,Texture2D CLOCK,Texture2D Leaf1,
            Texture2D Leaf2,Texture2D Leaf3,Texture2D Leaf4, Texture2D smoky)
        {
            uparrows = UP;
            downarrows = DOWN;
            clock = CLOCK;
            leaves[0] = Leaf1;
            leaves[1] = Leaf2;
            leaves[2] = Leaf3;
            leaves[3] = Leaf4;
            smoke = smoky;
        }
        public List<Particles> effects = new List<Particles>();

        public Area(Texture2D img, Vector2 pos, Vector2 dim) : 
            base(img, pos, dim)
        {
            creation = DateTime.Now;
        }

        public virtual void MakeEffects()
        {

        }
        public virtual void UpdateFX(){
            while (effects.Contains(null))
                effects.Remove(null);
        }

        public override void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            foreach (Particles p in effects)
            {
                p.DrawSelf(drawer, graphics, 10, 20);
            }
        }

        }


    }

