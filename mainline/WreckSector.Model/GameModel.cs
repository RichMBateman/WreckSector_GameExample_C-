using WreckSector.Model.GameData;
using WreckSector.Model.GameData.RecordProcessors;
using WreckSector.Model.UI;
using WreckSector.Model.UI.Title;
using SoulErosion.GameLibrary.Core;
using SoulErosion.GameLibrary.Numbers;
using System;
using WreckSector.Model.Screens;
using WreckSector.Model.Gameplay;

namespace WreckSector.Model
{
    /// <summary>
    /// Model of the entire game.  (The game world represents an active instance of a game the player is playing;
    /// the model is a frame around that instance).
    /// </summary>
    public class GameModel : BaseGameModel
    {
        #region Private Members

        private readonly GameWorld m_gameWorld;
        private readonly GameConfig m_gameConfig;
        private readonly GameTickUpdater m_tickUpdater;
        private readonly GameReferenceData m_referenceData;

        private readonly ScreenModelCharacterDetail m_smCharacterDetail;
        private readonly ScreenModelCredits m_smCredits;
        private readonly ScreenModelPressYourLuck m_smPressYourLuck;
        private readonly ScreenModelTitleMenu m_smTitleMenu;

        #endregion

        #region Constructors

        public GameModel()
        {
            PrepareDataLoader();
            m_gameWorld = new GameWorld(this);
            m_referenceData = new GameReferenceData();
            m_gameConfig = new GameConfig(this);
            m_tickUpdater = new GameTickUpdater(this);

            m_smCharacterDetail = new ScreenModelCharacterDetail(this);
            m_smCredits = new ScreenModelCredits(this);
            m_smPressYourLuck = new ScreenModelPressYourLuck(this);
            m_smTitleMenu = new ScreenModelTitleMenu(this);

            GameCamera.InitializeViewCamera(Camera);

            TimeWaveManager.InitializeGameModel(this);

            World.StatePrimary = GameStatePrimary.LoadingResources;
        }

        #endregion

        #region Public Properties

        #region Debug Flags

        /// <summary>
        /// Whether we are debugging the current game session.
        /// </summary>
        public Boolean DebugEnabledActiveGame { get; set; }

        /// <summary>
        /// Whether we are showing debugging information for the camera.
        /// </summary>
        public Boolean DebugEnabledCamera { get; set; }

        /// <summary>
        /// Whether we are showing debugging information for the track.
        /// </summary>
        public Boolean DebugEnabledTrack { get; set; }

        #endregion

        #region Game Data

        /// <summary>
        /// The instance of the game being played.
        /// </summary>
        public GameWorld World { get { return m_gameWorld; } }
        /// <summary>
        /// Configuration settings for the game.
        /// </summary>
        public GameConfig Config { get { return m_gameConfig; } }
        /// <summary>
        /// The module that updates the model for each tick.
        /// </summary>
        public GameTickUpdater TickUpdater { get { return m_tickUpdater; } }
        /// <summary>
        /// Game reference data.  Data that does not change during gameplay.
        /// </summary>
        public GameReferenceData ReferenceData { get { return m_referenceData; } }

        #endregion

        #region Screen Model

        public ScreenModelCharacterDetail SMCharacterDetail{ get { return m_smCharacterDetail;}}
        public ScreenModelCredits SMCredits{ get { return m_smCredits;}}
        public ScreenModelPressYourLuck SMPressYourLuck{ get { return m_smPressYourLuck;}}
        public ScreenModelTitleMenu SMTitleMenu{ get { return m_smTitleMenu;}}

        #endregion

        #endregion

        #region Public Methods

        #region Data Loading

        public override void MarkLoadingComplete()
        {
            GameReferenceData.InitializeWithModel(this);
            World.StatePrimary = GameStatePrimary.MainMenu;
        }

        #endregion

        #region Debug

        /// <summary>
        /// Reset the game.  This is a debug function, and will not be called during normal gameplay.
        /// </summary>
        public void DebugResetGame()
        {
            m_gameWorld.SetForNewGame();
        }

        #endregion

        #region Public Menu Options

        public void NewGame()
        {
            m_gameWorld.SetForNewGame();
        }

        public void LoadGame()
        {
            //GameLoader.LoadGame(this);
        }

        public void ExitGame()
        {
            //Application.Exit();
        }

        public void SaveGameAndMenu()
        {
            //GameSaver.SaveGame(this);
            //World.StatePrimary = GameStatePrimary.MainMenu;
        }

        public void SaveGameAndExit()
        {
            //GameSaver.SaveGame(this);
            //ExitGame();
        }

        public void ReturnToGame()
        {
            World.StatePrimary = GameStatePrimary.CoreGamePlay;
        }

        #endregion

        #region State Transitions

        public void TransitionToPressYourLuckPendingSelection()
        {
            m_gameWorld.StateGameplay = GameStateGameplay.PressYourLuckPendingSelection;
        }

        public void TransitionToPressYourLuckTileSelected()
        {
            m_gameWorld.StateGameplay = GameStateGameplay.PressYourLuckTileSelected;
        }

        public void TransitionToPressYourLuckTileProcessing()
        {
            m_gameWorld.StateGameplay = GameStateGameplay.PressYourLuckTileProcessing;
        }

        public void TransitionToCharacterDetail(Int32 characterIndex)
        {
            m_gameWorld.StateGameplay = GameStateGameplay.CharacterDetail;
        }

        public void TransitionToSpecialPowerActivating(Int32 characterIndex)
        {
            m_gameWorld.StateGameplay = GameStateGameplay.SpecialPowerActivating;
        }

        #endregion

        #region Tick

        /// <summary>
        /// From the game designer's viewpoint, this is the origin of the Tick.  It is their responsibility to apply
        /// the tick to their model.  I suggest having a GameTickUpdater class that applies ticks.
        /// </summary>
        public override void Tick()
        {
            base.Tick();
            m_tickUpdater.Tick();
        }

        #endregion

        #endregion

        #region Private Methods

        #region Initialization

        private void PrepareDataLoader()
        {
            DataLoader.InstallRecordType(ConfigProcessor.RecordTypeGameConfig, ConfigProcessor.RecordTypeSortOrderGameConfig, ConfigProcessor.Process);
            DataLoader.InstallRecordType(ImageProcessor.RecordTypeImage, ImageProcessor.RecordTypeSortOrderImage, ImageProcessor.Process);
            DataLoader.InstallRecordType(AnimationProcessor.RecordTypeAnimation, AnimationProcessor.RecordTypeSortOrderAnimation, AnimationProcessor.Process);
        }

        #endregion

        #endregion
    }
}
