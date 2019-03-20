using WreckSector.Model.Gameplay;

namespace WreckSector.Model.Ticker.Primary
{
    internal static class TickerCoreGamePlay
    {
        internal static void Tick(GameWorld w)
        {
            foreach(Agent a in w.PlayerParty.AgentsActive)
            {
                a.Tick();
            }
        }
    }
}
