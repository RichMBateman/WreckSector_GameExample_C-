using System;

namespace WreckSector.Model
{
    /// <summary>
    /// A collection of high-level constants for the game.  These are constants whose values should not be changed without a lot of thought.
    /// </summary>
    public static class GameConstants
    {
        #region Party 
        /// <summary>
        /// The number of player slots in the party.  This is not a number that changes.
        /// Party members may drop off, but there are always this many slots.  Much of the GUI and even gameplay
        /// revolves around there being no more than this number of characters.
        /// </summary>
        public const Int32 PartySizeMax = 4;

        /// <summary>
        /// The number of characters the party has initially.
        /// </summary>
        public const Int32 PartySizeInitial = 2;

        public const Int32 PartyLifeSupportNewGame = 400;
        public const Int32 PartyPowerNewGame = 100;
        public const Int32 PartyCreditsNewGame = 50;
        public const Int32 PartyScrapNewGame = 10;
        public const Int32 PartyRoomsForMissionBase = 3;
        public const Int32 PartyRoomsForMissionPerX = 2;
        #endregion

        #region Event

        /// <summary>
        /// The number of different ratings.
        /// </summary>
        public const Int32 NumConsequenceRatings = 4;

        #endregion

        #region Agent

        /// <summary>
        /// Attributes can go no higher than this.
        /// </summary>
        public const Int32 AgentAttributeMaxValue = 8;

        /// <summary>
        /// An agent's max health can never go beyond this.
        /// </summary>
        public const Int32 AgentHealthHardMax = 8;

        /// <summary>
        /// An agent's max armor can never go beyond this.
        /// </summary>
        public const Int32 AgentArmorHardMax = 255;

        /// <summary>
        /// The agent's health for new game agents.
        /// </summary>
        public const Int32 AgentHealthNewGame = 3;

        /// <summary>
        /// Agent's armor for new game agents.
        /// </summary>
        public const Int32 AgentArmorNewGame = 100;

        /// <summary>
        /// The number of attribute points to spread around for new game agents.
        /// </summary>
        public const Int32 AgentAttributePointsNewGame = 6;

        #endregion

    }
}
