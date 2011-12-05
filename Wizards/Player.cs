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
    public abstract class Player : GravitySprite

    {
        public DateTime stun=DateTime.Now;
        
        public Boolean right;
        public static Random RNG = new Random();
        static int MAX_JUMPS = 3;
        public DateTime firetime1;
        public DateTime firetime2;
        public int score = 0;
        public float power;
        public static Keys[] pressedKeys=new Keys[3];
        public int playernumber;

        public int punchpower = 48;


        public Player(Texture2D img, List<Platform> starts,float power, int playernum)
            : base(img, new Vector2(10, 10), new Vector2(16, 25), new Vector2(0, 0))
        {
            playernumber=playernum;
            Spawn(starts);
            this.power = power;
        }
        private void Spawn(List<Platform> starts){
            int choice = RNG.Next(0,starts.Count-1);
            pos.Y = starts[choice].getYAbove(this)-dim.Y;
            pos.X = starts[choice].pos.X + starts[choice].dim.X/2-dim.X/2;
        }

        public void moveDown()
        {
            if (landed != null && landed!=Ground.get())
            {
                pos.Y = landed.getYAbove(this) + 2;
                landed = null;
            }
        }
        public void moveUp(int multiplier)
        {
            if (jumps < MAX_JUMPS)
            {
                if (time.AddMilliseconds(300).CompareTo(DateTime.Now) < 0)
                {
                    time = DateTime.Now;
                    speed.Y -= 200*multiplier;
                    jumps++;
                    landed = null;

                }
            }
        }
        public void moveLeft(int multiplier)
        {
            if (landed != null && pos.X - 10 + dim.X < landed.pos.X)
                landed = null;
            if (speed.X > -100) speed.X -= 10*multiplier;
            right = false;

        }
        public void moveRight(int multiplier)
        {
            if (landed != null && pos.X + 10 + dim.X < landed.pos.X)
                landed = null;
            if (speed.X < 100) speed.X += 10*multiplier;
            right = true;
        }
        public override void draw(SpriteBatch drawer, GraphicsDevice graphics)
        {
            Color tint=Color.White;
            if (this is FireWizard) tint=Color.Red;
            if (this is EarthWizard) tint=Color.Green;
            if (this is AirWizard) tint=Color.Yellow;
            if (this is GravityWizard) tint=Color.Black;
            if (this is TimeWizard) tint = Color.Blue;
            if (this is PortalWizard) tint = Color.Chocolate;
             drawer.Draw(img, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y)
                , null, tint, 0, new Vector2(dim.X / 2, dim.Y / 2),
                 right ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0);
        }
        

        public void Stun(float milliseconds)
        {
            if (stun.Subtract(DateTime.Now).TotalMilliseconds<milliseconds)
                stun = DateTime.Now.AddMilliseconds(milliseconds);
        }

        public abstract Projectile ability1();
        public abstract Projectile ability2();
        public static void setKeys(Keys[] ks){
            Player.pressedKeys=ks;
        }
        public Vector2 getProjectileSpeed()
        {
            Boolean f = false, d = false, u = false;
            Vector2 fspeed;
            float firespeed = 0;
            float fireangle = 0;



            foreach (Keys k in pressedKeys)
            {
                if (playernumber == 0)
                {
                    if (k == Keys.Down)
                        d = true;
                    if (k == Keys.Left || k == Keys.Right)
                        f = true;
                    if (k == Keys.Up)
                        u = true;

                }
                else if (playernumber == 1)
                {
                    if (k == Keys.S)
                        d = true;
                    if (k == Keys.A || k == Keys.D)
                        f = true;
                    if (k == Keys.W)
                        u = true;
                }

            }
            Player.pressedKeys = new Keys[0];
            if (d && f)
            {
                firespeed = Math.Abs(speed.X * (float)Math.Sqrt(2));
                fireangle = (float)(-Math.PI / 4);
            }
            else if (d)
            {
                firespeed = 100;
                fireangle = (float)(-Math.PI / 2);
            }
            else if (f && u)
            {
                firespeed = 500;
                fireangle = (float)(-Math.PI / 4 - .1f);

            }
            else if (f)
            {
                firespeed = 600;
                fireangle = -.1f;
            }
            else if (u)
            {
                firespeed = 300;
                fireangle = (float)(-Math.PI / 2 - .05);
            }

            else
            {
                fireangle = -.1f;
                firespeed = 250;

            }


                fspeed = new Vector2(
                    (float)Math.Cos(fireangle) * firespeed,
                    (float)Math.Sin(fireangle) * firespeed);
                if (!right) fspeed.X *= -1;
               
            GamePadState gamepad= GamePad.GetState(PlayerIndex.One);
             if (playernumber == 1)
                    gamepad = GamePad.GetState(PlayerIndex.Two);
                if (gamepad.IsConnected)
                {

                    fspeed = gamepad.ThumbSticks.Right * 500;
                    fspeed.Y *= -1;
                }

                return fspeed;

        }
        public void punch(List<GravitySprite> gravs)
        {
            for (int i=0;i<gravs.Count;i++)
            {
                Rectangle rect = new Rectangle(
                    (int)(pos.X+(right?0:(-1*dim.X))),(int)pos.Y-5,
                    (int)dim.X*2, (int)dim.Y+10);
                if (gravs[i] != this && gravs[i].intersects(rect))
                {
                    gravs[i].speed.X=(right?punchpower:-punchpower)
                        *(float)Math.Max(
                        distance(gravs[i])
                        *Math.Cos(
                        Math.Atan2(gravs[i].getCenter().Y - getCenter().Y,
                        (gravs[i].getCenter().X - getCenter().X)))
                        ,5);
                    gravs[i].speed.Y=(gravs[i].getCenter().Y>getCenter().Y?1:-1)
                        *(float)Math.Max(
                        distance(gravs[i])
                      *Math.Sin(
                        Math.Atan2(gravs[i].getCenter().Y - getCenter().Y,
                        (gravs[i].getCenter().X - getCenter().X)))
                        ,5);

                }
            }


        }
    }
}
