#region File Description
//-----------------------------------------------------------------------------
// MainMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using WizardWars; 
#endregion

namespace WizardWars
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenuScreen : MenuScreen
    {
        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenuScreen()
            : base("Main Menu")
        {
            // Create our menu entries.
            MenuEntry playGameMenuEntry = new MenuEntry("Play Game");
            MenuEntry instructions = new MenuEntry("Instructions");
            MenuEntry exitMenuEntry = new MenuEntry("Exit");

            //play music
            //if (AudioManager.GetCue("The Mystery of the Wizards"))
            //{
                AudioManager.PlayMusic("The Mystery of the Wizards");
            //}

            // Hook up menu event handlers.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            instructions.Selected += InstructionSelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(instructions);
            MenuEntries.Add(exitMenuEntry);
            if (ScreenManager.graphicsManager.PreferredBackBufferHeight < 900)
            {
                ScreenManager.graphicsManager.PreferredBackBufferHeight = 900;
                ScreenManager.graphicsManager.ApplyChanges();
            }
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new OptionsMenuScreen());
        }


        /// <summary>
        /// Event handler for when the Options menu entry is selected.
        /// </summary>
        void InstructionSelected(object sender, EventArgs e)
        {
            ScreenManager.AddScreen(new InstructionsMenuScreen());
        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel()
        {
            const string message = "Are you sure you want to exit Wizard Wars?";

            MessageBoxScreen confirmExitMessageBox = new MessageBoxScreen(message);

            confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmExitMessageBox);
        }


        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to exit" message box.
        /// </summary>
        void ConfirmExitMessageBoxAccepted(object sender, EventArgs e)
        {
            ScreenManager.Game.Exit();
        }


        #endregion
    }
}
