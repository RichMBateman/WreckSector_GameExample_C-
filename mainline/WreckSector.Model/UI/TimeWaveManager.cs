using SoulErosion.GameLibrary.Time;
using System;

namespace WreckSector.Model.UI
{
    /// <summary>
    /// Class used to manage time waves and other resources that depend on them.
    /// </summary>
    public static class TimeWaveManager
    {
        #region Constants

        public const String TimeWaveKeyStandard = "Standard";
        public const String ColorWaveKeyOrange = "Orange";

        #endregion

        #region Public Static Api

        public static void InitializeGameModel(GameModel gameModel)
        {
            InitializeTimeWaves(gameModel);
            InitializeTimeWaveDependentItems(gameModel);
        }

        #endregion

        #region Private Methods

        private static void InitializeTimeWaves(GameModel gameModel)
        {
            TickWave tickWaveStandard = gameModel.InstallTickWave(TimeWaveKeyStandard);
            tickWaveStandard.TickCounterMax = 100;
            tickWaveStandard.TickVelocity = 15;
        }

        private static void InitializeTimeWaveDependentItems(GameModel gameModel)
        {
            gameModel.InstallColorWave(ColorWaveKeyOrange, ColorsOfficial.ColorMinimumOrange, ColorsOfficial.ColorMaximumOrange, TimeWaveKeyStandard);
        }

        #endregion
    }
}
