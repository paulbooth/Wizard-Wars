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
    class EarthWizardInfoScreen : MenuScreen
    {
        MenuEntry back;
        public EarthWizardInfoScreen()
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
            spriteBatch.DrawString(font, "Earth Wizard:"+
            "\n\nThe Earth Wizard can command the terrain itself, either raising or lowering it as he wills."+
            "\nHe can command mountains to form or pits to collapse beneath his enemies feet."+
            "\nThe ability to raise the terrain is particularly useful for rapidly moving upwards"
                , new Vector2(100, 350), Color.White);
            spriteBatch.End();
        }

    }
}
