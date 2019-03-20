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
using WreckSector.Model.Screens;

namespace WreckSector.FormView.Gameplay
{
    internal static class ViewPressYourLuck
    {
        private static SolidBrush s_sbOne = new SolidBrush(Color.Red);
        private static SolidBrush s_sbTwo = new SolidBrush(Color.Yellow);
        private static SolidBrush s_sbThree = new SolidBrush(Color.Green);
        private static SolidBrush s_sbFour = new SolidBrush(Color.Blue);
        private static Pen s_penWhite = new Pen(Color.White);

        public static void Draw(GameModel model, Painter painter, Graphics g, Int32 totalClientWidth, Int32 totalClientHeight)
        {
            s_penWhite = new Pen(Color.White, (Single)(5 * model.Camera.CurrentScale));
            ScreenModelPressYourLuck screenModel = model.SMPressYourLuck;
            Position logPosBoundary = screenModel.LogPosSelectorBoundary;
            for (Int32 colIndex = 0; colIndex < 5; colIndex++)
            {
                for (Int32 rowIndex = 0; rowIndex < 5; rowIndex++)
                {
                    Position logPos = new Position(logPosBoundary.UpperLeftX + 25 + 50 * colIndex, logPosBoundary.UpperLeftY + 50 + 50 * rowIndex, 50, 50);
                    Position dispPos = model.Camera.MapLogicalToDisplay(logPos, true);
                    SolidBrush sb = GetSolidBrushForOutcome(screenModel.RatingGrid[colIndex, rowIndex]);
                    Drawing2D.DrawRect(g, sb, dispPos);
                }
            }

            Position logPosSelected = new Position(logPosBoundary.UpperLeftX + 25 + 50 * screenModel.SelectedX,
                logPosBoundary.UpperLeftY + 50 + 50 * screenModel.SelectedY, 50, 50);
            Drawing2D.DrawRectBorder(g, s_penWhite, model.Camera.MapLogicalToDisplay(logPosSelected, true));
            s_penWhite.Dispose();
        }

        private static SolidBrush GetSolidBrushForOutcome(TileType rating)
        {
            SolidBrush sb = s_sbOne;
            switch (rating)
            {
                //case EventConsequenceRating.Worst: sb = s_sbOne; break;
                //case EventConsequenceRating.Bad: sb = s_sbTwo; break;
                //case EventConsequenceRating.Good: sb = s_sbThree; break;
                //case EventConsequenceRating.Best: sb = s_sbFour; break;
            }
            return sb;
        }
    }
}
