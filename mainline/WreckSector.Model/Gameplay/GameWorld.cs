using System.Collections.Generic;
using System;
using SoulErosion.GameLibrary.Numbers;
using WreckSector.Model.Gameplay;

namespace WreckSector.Model.Gameplay
{
    /// <summary>
    /// A live instance of the game world.  Represents the game actually being played at the moment by the player.
    /// If the game supports multiple saves, you could imagine each save would be tracked by its own GameWorld object.
    /// </summary>
    public class GameWorld
    {
        #region Private Members

        private readonly GameModel m_gameModel;
        private readonly Party m_playerParty;

        #endregion

        #region Constructors

        public GameWorld(GameModel gameModel)
        {
            m_gameModel = gameModel;
            StatePrimary = GameStatePrimary.MainMenu;
            StateGameplay = GameStateGameplay.NotApplicable;
            m_playerParty = new Party(gameModel);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The primary game state for the world.
        /// </summary>
        public GameStatePrimary StatePrimary { get; set; }

        /// <summary>
        /// In what state is the active game.
        /// </summary>
        public GameStateGameplay StateGameplay { get; set; }

        /// <summary>
        /// The player's party of misfits.
        /// </summary>
        public Party PlayerParty { get { return m_playerParty; } }

        public Int32 NumRoomsLeft { get; set; }
        public Int32 NumMissionsFinished { get; set; }


        #endregion

        #region Public Methods

        #region New Game

        /// <summary>
        /// Resets the game world so that a player can start a brand new game.
        /// </summary>
        public void SetForNewGame()
        {
            StatePrimary = GameStatePrimary.CoreGamePlay;
            StateGameplay = GameStateGameplay.PressYourLuckPendingSelection;
            m_playerParty.ResetForNewGame();
            ResetMissionCounters();
        }

        #endregion

        #region Party



        #endregion

        #endregion

        #region Private Methods

        private void ResetMissionCounters()
        {
            NumMissionsFinished = 0;
            NumRoomsLeft = GameConstants.PartyRoomsForMissionBase;
        }

        #endregion
    }
}
