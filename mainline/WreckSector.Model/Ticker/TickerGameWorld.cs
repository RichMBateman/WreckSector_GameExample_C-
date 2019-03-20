using WreckSector.Model.Gameplay;
using WreckSector.Model.Ticker.Primary;

namespace WreckSector.Model.Ticker
{
    /// <summary>
    /// Handles tick for the instance of a game world.
    /// </summary>
    internal static class TickerGameWorld
    {
        /// <summary>
        /// Applies a game tick to the game world.
        /// </summary>
        internal static void Tick(GameWorld w)
        {
            switch (w.StatePrimary)
            {
                //case GameStatePrimary.MainMenu: TickerMainMenu.Tick(w);  break;
                case GameStatePrimary.CoreGamePlay: TickerCoreGamePlay.Tick(w); break;
                case GameStatePrimary.Exiting: break;
            }
        }
    }
}
