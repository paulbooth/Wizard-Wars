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
    class AirWizardInfoScreen : MenuScreen
    {
        MenuEntry back;
        public AirWizardInfoScreen()
            : base("AirWizard")
        {
            back = new MenuEntry("Backwards");
            back.Selected += toMainInstructions; back.Reversed += toMainInstructions;
            MenuEntries.Add(back);
        }
        void toMainInstructions(object sender, EventArgs e)
        {
            LoadingScreen.Load(ScreenManager, false, new InstructionsMenuScreen());
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteFont font = ScreenManager.Font;
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Air Wizard:"+
            "\n\nThe Air Wizard can control the sky itself; this power grants him the awesome ability"+
            "\nto send down lightning bolts upon his foes at will. Other wizards that stand nearby when"+
            "\na lightning bolt strikes are stunned by it's power. When battling an air wizard, it is wise"+
            "\nto take cover below a platform to avoid these powerful bolts."+
            "\n\nThe air wizard's mastery over the sky also allows him to summon the power of wind to his"+
            "\naid. The air wizard can create a field of rapidly blowing wind to speed his travels"+
            "\n(or hinder his opponents)", new Vector2(100, 350), Color.White);
            spriteBatch.End();
        } 
        
    }
}
