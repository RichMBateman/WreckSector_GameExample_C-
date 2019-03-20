using System;

namespace WreckSector.Model
{
    /// <summary>
    /// Collection of hard-coded default values, in absence of any configured value or reference data to use.
    /// Ideally, all data should be specified in the configuration; however, it shouldn't break down if it's absent.
    /// </summary>
    public static class GameModelDefaults
    {
        #region Agents

        /// <summary>
        /// The number of milliseconds to delay between loading each resource.  The purpose of this is to let the user actually
        /// see the progress bar (for testing purposes).
        /// </summary>
        public const Int32 DefaultSimulateLoadingDelayMs = 200;
        public const Int32 TickDurationMs = 50;

        #endregion

        #region Camera

        /// <summary>
        /// The logical width of the display area.  The number of pixels horizontally that are displayed.
        /// </summary>
        public const Int32 CameraWidth = 400;
        /// <summary>
        /// The logical height of the display area.  The number of pixels vertically that are displayed.
        /// </summary>
        public const Int32 CameraHeight = 300;

        #endregion

        #region Fonts

        /// <summary>
        /// The name of the font to use.
        /// </summary>
        public const String FontNamePrimary = "Game Over";

        /// <summary>
        /// Path to the primary font file.
        /// </summary>
        public const String FontPrimaryFilePath = "assets\\fonts\\game_over.ttf";

        /// <summary>
        /// The font size to use in most instances.  This size is based on the logical camera size.
        /// </summary>
        public const Int32 FontSizeLarge = 36;
        /// <summary>
        /// Font size to use for game text.
        /// </summary>
        public const Int32 FontSizeGameText = 18;

        #endregion
    }
}
