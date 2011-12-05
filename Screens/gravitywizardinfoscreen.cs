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
    class GravityWizardInfoScreen : MenuScreen
    {
        MenuEntry back;
        public GravityWizardInfoScreen()
            : base("GravityWizard")
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
            spriteBatch.DrawString(font, "Gravity Wizard:"+
            "\n\nThe Gravity Wizard's mysterious powers allow him to alter local gravity fields"+
            "\nHis first ability to reverse gravity in an area, literally causing things to fall upwards."+
            "\nThis power allows the gravity wizard to jump with unparalleled height."+
            "\n\nThe gravity wizard's second power increases the power of gravity in an area, making it"+
            "\nvirtually impossible to move upwards.", new Vector2(100, 350), Color.White);
            spriteBatch.End();
        }

    }
}
