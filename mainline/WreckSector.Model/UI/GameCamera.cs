using SoulErosion.GameLibrary.Drawing;
using SoulErosion.GameLibrary.Forms;
using SoulErosion.GameLibrary.Spatial;
using System;

namespace WreckSector.Model.UI
{
    /// <summary>
    /// Helper class for managing the camera.  
    /// </summary>
    public static class GameCamera
    {
        #region Static Members

        private static Boolean m_shiftedForOpenPanel = false;

        #endregion

        #region Public Functions

        #region Initialization

        /// <summary>
        /// Initializes the properties of the game camera.
        /// </summary>
        public static void InitializeViewCamera(Camera c)
        {
            c.LogicalRect.Width = GameModelDefaults.CameraWidth;
            c.LogicalRect.Height = GameModelDefaults.CameraHeight;
            c.SetUnzoomedLogicalSize();
            c.UpdateCurrentScale();
        }

        #endregion

        #region Visibility Queries

        /// <summary>
        /// Returns whether any portion of the drawable object is on camera.
        /// </summary>
        public static Boolean IsObjectOnCamera(Camera c, DrawableObject o)
        {
            return Math2d.RectanglesIntersect(c.LogicalRect, o.PositionLogical);
        }

        #endregion

        #endregion
    }
}
