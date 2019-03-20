namespace WreckSector.Model
{
    /// <summary>
    /// The highest level game state we can be in.  Meant to keep track of whether we're ready to play, we're looking at a menu,
    /// or we're actually playing the game.
    /// </summary>
    public enum GameStatePrimary
    {
        LoadingResources,
        MainMenu,
        GameInProgressMenu,
        CoreGamePlay,
        Paused,
        Exiting,
    }
}
