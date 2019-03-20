using WreckSector.Model.GameData;
using WreckSector.Model.Ticker;
using SoulErosion.GameLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckSector.Model
{
    /// <summary>
    /// Makes sure the appropriate parts of the model are updated with game ticks.
    /// </summary>
    public class GameTickUpdater : ITicker
    {
        #region Constants

        public const Int32 GameTicksPerMinute = 10;
        public const Int32 GameTicksPerHour = GameTicksPerMinute * 60;
        public const Int32 GameTicksPerDay = GameTicksPerHour * 24;

        #endregion

        #region Private Members

        private readonly GameModel m_model;
        /// <summary>
        /// How many total ticks have elapsed.  For core gameplay only.
        /// </summary>
        private Int64 m_totalTicksElapsed;

        #endregion

        #region Constructors

        public GameTickUpdater(GameModel m)
        {
            m_model = m;
        }

        #endregion

        #region Public Properties

        public Int64 TotalElapsedDays
        {
            get
            {
                return m_totalTicksElapsed / GameTicksPerDay;
            }
        }

        public Int64 TotalElapsedHours
        {
            get
            {
                return (m_totalTicksElapsed % GameTicksPerDay) / GameTicksPerHour;
            }
        }

        public Int64 TotalElapsedMinutes
        {
            get
            {
                return (m_totalTicksElapsed % GameTicksPerHour) / GameTicksPerMinute;
            }
        }

        #endregion

        #region Public Api

        public String GetCurrentTime()
        {
            String daysString = "D" + TotalElapsedDays.ToString().PadLeft(3, '0');
            String hoursString = "H" + TotalElapsedHours.ToString().PadLeft(2, '0');
            String minutesString = "M" + TotalElapsedMinutes.ToString().PadLeft(2, '0');
            String timeString = daysString + hoursString + minutesString;
            return timeString;
        }

        /// <summary>
        /// A method that should be called to indicate a frame tick has elapsed.
        /// </summary>
        public void Tick()
        {
            m_totalTicksElapsed++;

            TickScreenModels();
            TickGameWorld();
            GameReferenceData.Tick();
        }

        #endregion

        #region Game Ticks

        private void TickGameWorld()
        {
            TickerGameWorld.Tick(m_model.World);
        }

        private void TickScreenModels()
        {
            switch (m_model.World.StatePrimary)
            {
                case GameStatePrimary.CoreGamePlay:
                    TickCoreGameplayScreenModels();
                    break;
                case GameStatePrimary.GameInProgressMenu:
                case GameStatePrimary.LoadingResources:
                case GameStatePrimary.MainMenu:
                    TickTitleScreen();
                    break;
                case GameStatePrimary.Paused: break;
            }
        }

        private void TickTitleScreen()
        {
            m_model.SMTitleMenu.Tick();
        }

        private void TickCoreGameplayScreenModels()
        {
            switch (m_model.World.StateGameplay)
            {
                //case GameStateGameplay.CharacterDetail: m_model.SMActionChooser.Tick(); break;
                //case GameStateGameplay.PressYourLuckPendingSelection: m_model.SMCharacterCreator.Tick(); break;
                //case GameStateGameplay.PressYourLuckTileProcessing: m_model.SMCharacterDetail.Tick(); break;
                //case GameStateGameplay.PressYourLuckTileSelected: m_model.SMEventPlay.Tick(); break;
                //case GameStateGameplay.SpecialPowerActivating: m_model.SMPerkList.Tick(); break;
            }
        }

        #endregion
    }
}
