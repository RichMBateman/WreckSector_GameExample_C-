using WreckSector.Model;
using WreckSector.Model.UI;
using SoulErosion.GameLibrary.Drawing;
using SoulErosion.GameLibrary.Forms;
using SoulErosion.GameLibrary.Spatial;
using SoulErosion.GameLibrary.Time;
using System;
using System.Collections.Generic;
using System.Drawing;
using WreckSector.Model.Gameplay;

namespace WreckSector.FormView.Gameplay
{
    internal static class ViewCoreGameplay
    {
        #region Private Static Members

        private const String PRKeyFullDraw = "View Main Gameplay - Full Draw";
        internal static SolidBrush SBTransparentBlack = new SolidBrush(Color.FromArgb(180, Color.Black));
        internal static SolidBrush SBTransparentWhite = new SolidBrush(Color.FromArgb(50, Color.White));
        private static Position LogPosCompassMover = new Position(355, 300, 90, 90);

        #endregion

        #region Public Methods

        public static void Draw(GameModel model, Painter painter, Graphics g, Int32 totalClientWidth, Int32 totalClientHeight)
        {
            GameWorld w = model.World;
            switch (w.StateGameplay)
            {
                case GameStateGameplay.PressYourLuckPendingSelection: ViewPressYourLuck.Draw(model, painter, g, totalClientWidth, totalClientHeight); break;
                case GameStateGameplay.PressYourLuckTileProcessing: break;
                case GameStateGameplay.PressYourLuckTileSelected: break;
                case GameStateGameplay.SpecialPowerActivating: break;
                case GameStateGameplay.CharacterDetail: ViewCharacterDetail.Draw(model, painter, g); break;
            }
        }

        #endregion
    }
}
