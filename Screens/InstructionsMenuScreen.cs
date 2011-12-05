using System;
using System.Timers;
using System.Collections.Generic;
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
    class InstructionsMenuScreen : MenuScreen
    {
        MenuEntry air;
        MenuEntry back;
        MenuEntry fire;
        MenuEntry earth;
        MenuEntry gravity;
        MenuEntry portal;
        MenuEntry time;
        public InstructionsMenuScreen()
            : base("Instructions")
        {
            back = new MenuEntry("Backwards");
            air = new MenuEntry("Air Wizard Information");
            earth = new MenuEntry("Earth Wizard Information");
            fire = new MenuEntry("Fire Wizard Information");
            gravity = new MenuEntry("Gravity Wizard Information");
            portal = new MenuEntry("Portal Wizard Information");
            time = new MenuEntry("Time Wizard Information");

            back.Selected += toMainMenu;   back.Reversed += toMainMenu;
            air.Selected += toAir;         air.Reversed += toMainMenu;
            earth.Selected += toEarth;     earth.Reversed += toMainMenu;
            fire.Selected += toFire;       fire.Reversed += toMainMenu;
            gravity.Selected += toGravity; gravity.Reversed += toMainMenu;
            portal.Selected += toPortal;   portal.Reversed += toMainMenu;
            time.Selected += toTime;       time.Reversed += toMainMenu;

            MenuEntries.Add(air);
            MenuEntries.Add(earth);
            MenuEntries.Add(fire);
            MenuEntries.Add(gravity);
            MenuEntries.Add(portal);
            MenuEntries.Add(time);
            MenuEntries.Add(back);
        }
        void toAir(object sender, EventArgs e){
            LoadingScreen.Load(ScreenManager, false, new AirWizardInfoScreen());}
        void toEarth(object sender, EventArgs e) { 
            LoadingScreen.Load(ScreenManager, false, new EarthWizardInfoScreen()); }
        void toFire(object sender, EventArgs e) { 
            LoadingScreen.Load(ScreenManager, false, new FireWizardInfoScreen());}
        void toGravity(object sender, EventArgs e) { 
            LoadingScreen.Load(ScreenManager, false, new GravityWizardInfoScreen()); }
        void toPortal(object sender, EventArgs e) { 
            LoadingScreen.Load(ScreenManager, false, new PortalWizardInfoScreen()); }
        void toTime(object sender, EventArgs e) { 
            LoadingScreen.Load(ScreenManager, false, new TimeWizardInfoScreen()); }

        void toMainMenu(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new MainMenuScreen());
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, " General Instructions:\n\n Wizard Wars is a two player videogame in which "+
                "\n wizards battle to collect magical dweomers. The players \n choose among six powerful wizards"+" each equipped with two \n magical attacks Throughout the game\n the wizards cast their spells to"+
                " either speed themselves\n up or hinder their oppoenets as they race to collect the\n dweomers. In the"+
                " time mode players must set a time limit\n on the game. Whichever wizard collects the most magical\n"+
                " dweomers within that time period will be declared the\n winner. In the second mode two wizards will"+
                " battle to collect\n a pre-set number of magical dweomers. The first wizard\n to collect the specified"+
                " number of dweomers will win.\n\n Controls for PC: \n\nPlayer 1 uses the arrow keys to move and L and K for attacks. \nPlayer 2 uses WASD to move and F and G for attacks. \n\nControls for XBox:\n\nControl stick to move, A to jump, and L and R for attacks.   ", new Vector2(100,350), Color.White);
            spriteBatch.End();
        }

    }
}
