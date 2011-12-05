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
    class FireWizardInfoScreen : MenuScreen
    {
        MenuEntry back;
        public FireWizardInfoScreen()
            : base("PortalWizard")
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
            spriteBatch.DrawString(font, "Fire Wizard: "+
            "\n\nThe Fire Wizard's primary attack is the ability to conjure fire out of thin air and hurl it"+
            "\n at opponents. This 'fireball' creates a massive impact when it lands, destroying some of the"+
            "\n surrounding land and stunning or hurling back nearby opponents. The fireball's explosion,"+
            "\nif aimed at the wizard's feet, can also be used to propel him across the screen."+
            "\n\n The fire wizard can also summon forth clouds of smoke. This obscuring mist hides the lay"+
            "\n of the land from the wizard's opponents (and himself; be wary).", new Vector2(100, 350), Color.White);
            spriteBatch.End();
        }

    }
}
