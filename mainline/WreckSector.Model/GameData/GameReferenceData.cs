using WreckSector.Model.UI.Title;
using System;
using System.Collections.Generic;
using WreckSector.Model.Gameplay;
using System.Drawing;
using SoulErosion.GameLibrary.Spatial;
using SoulErosion.GameLibrary.Sprites;
using WreckSector.Model.Screens;

namespace WreckSector.Model.GameData
{
    /// <summary>
    /// Holds onto data that does not change during gameplay.  In other words, data stored in this class
    /// will never need to be saved with a saved game.
    /// </summary>
    public class GameReferenceData
    {
        #region Constants

        public const String DirectoryGameData = "assets\\data";

        #endregion

        #region Private Members

        private static Boolean m_modelInitialized = false;

        private static Dictionary<MenuOptionPrimary, String> m_menuMainToText = new Dictionary<MenuOptionPrimary, String>();
        private static Dictionary<MenuOptionInGame, String> m_menuInGameToText = new Dictionary<MenuOptionInGame, String>();
        private static Dictionary<Int32, Color> m_charIndexToColor = new Dictionary<Int32, Color>();
   
        #endregion

        #region Constructors

        static GameReferenceData()
        {
            PopulateMenuMainToText();
            PopulateMenuInGameToText();
            PopulateCharIndexToGameColor();
        }

        #endregion

        #region Public Properties

        #region Game Colors
        /// <summary>
        /// Char Index (0-3) to Color.
        /// </summary>
        public Dictionary<Int32, Color> CharIndexToColor { get { return m_charIndexToColor; } }
        #endregion

        #region Menu Labels
        /// <summary>
        /// Main Menu Option Enum to String Labels
        /// </summary>
        public Dictionary<MenuOptionPrimary, String> MenuMainToText { get { return m_menuMainToText; } }
        /// <summary>
        /// In Game Menu Option Enum to String Labels
        /// </summary>
        public Dictionary<MenuOptionInGame, String> MenuInGameToText { get { return m_menuInGameToText; } }
        #endregion

        #endregion

        #region Public Static Methods

        public static void InitializeWithModel(GameModel m)
        {
            m_modelInitialized = true;
        }

        public static void Tick()
        {
            if(m_modelInitialized)
            {

            }
        }

        #endregion

        #region Private Static Functions

        private static void PopulateMenuMainToText()
        {
            m_menuMainToText[MenuOptionPrimary.NewGame] = "New Game";
            m_menuMainToText[MenuOptionPrimary.LoadGame] = "Load Game";
            m_menuMainToText[MenuOptionPrimary.Credits] = "Credits";
            m_menuMainToText[MenuOptionPrimary.ExitGame] = "Exit Game";
        }

        private static void PopulateMenuInGameToText()
        {
            m_menuInGameToText[MenuOptionInGame.SaveAndExit] = "Save and Exit";
            m_menuInGameToText[MenuOptionInGame.SaveAndMenu] = "Save and Menu";
            m_menuInGameToText[MenuOptionInGame.Return] = "Return to Game";
        }

        private static void PopulateCharIndexToGameColor()
        {
            m_charIndexToColor.Add(0, Color.Red);
            m_charIndexToColor.Add(1, Color.Blue);
            m_charIndexToColor.Add(2, Color.Yellow);
            m_charIndexToColor.Add(3, Color.Green);
        }
        #endregion
    }
}
