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
    class PortalWizardInfoScreen : MenuScreen
    {
        MenuEntry back;
        public PortalWizardInfoScreen()
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
            spriteBatch.DrawString(font, "Portal Wizard:"+
            "\n\nThe mysterious portal mage claims to be a refugee from a ruined magical study known"+
            "\nas 'Aperture Science'. There, he learned the mysterious magics of controlling 'portals',"+
            "\nlocal rifts in the space-time continuum. His two portals transform the nature of spacetime,"+
            "\nallowing objects and people to go from one to the other without traversing the intervening"+
            "\nspace. The near-teleportation makes the portal wizard among the most mobile of the wizards;"+
            "\nit also allows him to confuse his opponents by teleporting them across the map"+
            "\ninstantaneously.", new Vector2(100, 350), Color.White);
            spriteBatch.End();
        }

    }
}
