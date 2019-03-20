using WreckSector.Model;
using WreckSector.Model.UI;
using SoulErosion.GameLibrary.Drawing;
using SoulErosion.GameLibrary.Forms;
using SoulErosion.GameLibrary.Spatial;
using System;
using System.Drawing;
using WreckSector.Model.Screens;
using WreckSector.Model.UI.Title;

namespace WreckSector.FormView.Title
{
    /// <summary>
    /// The Loading Screen, Title Screen, and Menu Screens, all in one!
    /// </summary>
    internal static class ViewTitleMenu
    {
        #region Private Members

        private static Position m_titlePosition = new Position(200, 50, 400, 50);

        private static Position m_progressBarPosition = new Position(200, 260, 100, 5);
        private static Position m_progressCountMsgPosition = new Position(200, 280, 400, 20);
        private static Position m_statusMsgPosition = new Position(200, 256, 400, 20);

        #endregion

        #region Public Functions

        public static void Draw(GameModel model, Painter painter, Graphics g)
        {
            Font font = painter.CreateFontForDisplay(GameModelDefaults.FontNamePrimary, GameModelDefaults.FontSizeLarge, model.Camera.UnzoomedScale);
            DrawTitleScreenParticleSystem(model, painter, g);
            switch (model.World.StatePrimary)
            {
                case GameStatePrimary.LoadingResources:
                    DrawResourceLoading(model, painter, g, font);
                    break;
                case GameStatePrimary.MainMenu:
                    DrawMainMenu(model, painter, g, font);
                    break;
                case GameStatePrimary.GameInProgressMenu:
                    DrawInGameMenu(model, painter, g, font);
                    break;
            }

            DrawTitle(model, painter, g, font);
            font.Dispose();

        }

        #endregion

        #region Private Static Functions

        private static void DrawTitle(GameModel model, Painter painter, Graphics g, Font font)
        {
            Color titleColor = model.GetColorWave(TimeWaveManager.ColorWaveKeyOrange).CurrentColor;
            SolidBrush titleColorBrush = new SolidBrush(titleColor);

            Position titlePos = model.Camera.HorizontallyCenterTextWithinRect(m_titlePosition, ScreenModelTitleMenu.GameTitleText, font, g, true);
            g.DrawString(ScreenModelTitleMenu.GameTitleText, font, titleColorBrush, (Single)titlePos.UpperLeftX, (Single)titlePos.UpperLeftY);
            titleColorBrush.Dispose();
        }

        private static void DrawTitleScreenParticleSystem(GameModel model, Painter painter, Graphics g)
        {
            foreach (TitleScreenParticle ap in model.SMTitleMenu.Particles)
            {
                Position displayPos = model.Camera.MapLogicalToDisplay(ap.PositionLogical, true);
                Double scale = model.Camera.CurrentScale;
                SolidBrush tickBrush = new SolidBrush(ap.GetColor());
                Drawing2D.DrawRect(g, tickBrush, displayPos);
                tickBrush.Dispose();
            }
        }

        private static void DrawMainMenu(GameModel model, Painter painter, Graphics g, Font font)
        {
            ScreenModelTitleMenu t = model.SMTitleMenu;
            String textNewGame = model.ReferenceData.MenuMainToText[MenuOptionPrimary.NewGame];
            DrawMenuOption(model, painter, g, font, textNewGame, t.MainNewGameUIE.LogicalPosition, t.MainNewGameUIE.IsMousedOver);
            String textLoadGame = model.ReferenceData.MenuMainToText[MenuOptionPrimary.LoadGame];
            DrawMenuOption(model, painter, g, font, textLoadGame, t.MainLoadGameUIE.LogicalPosition, t.MainLoadGameUIE.IsMousedOver);
            String textCredits = model.ReferenceData.MenuMainToText[MenuOptionPrimary.Credits];
            DrawMenuOption(model, painter, g, font, textCredits, t.MainCreditsUIE.LogicalPosition, t.MainCreditsUIE.IsMousedOver);
            String textExitGame = model.ReferenceData.MenuMainToText[MenuOptionPrimary.ExitGame];
            DrawMenuOption(model, painter, g, font, textExitGame, t.MainExitGameUIE.LogicalPosition, t.MainExitGameUIE.IsMousedOver);
        }

        private static void DrawInGameMenu(GameModel model, Painter painter, Graphics g, Font font)
        {
            ScreenModelTitleMenu t = model.SMTitleMenu;
            String textSaveMenu = model.ReferenceData.MenuInGameToText[MenuOptionInGame.SaveAndMenu];
            DrawMenuOption(model, painter, g, font, textSaveMenu, t.InGameMenuSaveAndMenuUIE.LogicalPosition, t.InGameMenuSaveAndMenuUIE.IsMousedOver);
            String textSaveExit = model.ReferenceData.MenuInGameToText[MenuOptionInGame.SaveAndExit];
            DrawMenuOption(model, painter, g, font, textSaveExit, t.InGameMenuSaveAndExitUIE.LogicalPosition, t.InGameMenuSaveAndExitUIE.IsMousedOver);
            String textReturn = model.ReferenceData.MenuInGameToText[MenuOptionInGame.Return];
            DrawMenuOption(model, painter, g, font, textReturn, t.InGameMenuReturnUIE.LogicalPosition, t.InGameMenuReturnUIE.IsMousedOver);
        }

        private static void DrawMenuOption(GameModel model, Painter painter, Graphics g, Font font, String text, Position logicalPos, Boolean isMousedOver)
        {
            Color menuColor = (isMousedOver ? Color.White : ColorsOfficial.ColorMinimumOrange);
            SolidBrush menuBrush = new SolidBrush(menuColor);
            Position posDisplay = model.Camera.HorizontallyCenterTextWithinRect(logicalPos, text, font, g, ignoreCameraPosition: true);
            g.DrawString(text, font, menuBrush, (Single)posDisplay.UpperLeftX, (Single)posDisplay.UpperLeftY);
        }

        private static void DrawResourceLoading(GameModel model, Painter painter, Graphics g, Font font)
        {
            if (model.DataLoader.ShowResourceCounts)
            {
                Position progressBar = model.Camera.MapLogicalToDisplay(m_progressBarPosition, ignoreCameraPosition: true);
                Double percentLoaded = (((Double)model.DataLoader.ResourcesLoaded) / model.DataLoader.ResourcesToLoad);
                Int32 amountFilled = (Int32)(progressBar.Width * percentLoaded);
                g.DrawRectangle(Pens.Orange, (Single)progressBar.UpperLeftX, (Single)progressBar.UpperLeftY, (Single)progressBar.Width, (Single)progressBar.Height);
                g.FillRectangle(Brushes.Azure, (Single)progressBar.UpperLeftX, (Single)progressBar.UpperLeftY, amountFilled, (Single)progressBar.Height);

                String progressText = String.Format("{0} / {1}", model.DataLoader.ResourcesLoaded, model.DataLoader.ResourcesToLoad);
                Position progressTextPos = model.Camera.HorizontallyCenterTextWithinRect(m_progressCountMsgPosition, progressText, font, g, ignoreCameraPosition: true);
                g.DrawString(progressText, font, Brushes.White, (Single)progressTextPos.UpperLeftX, (Single)progressTextPos.UpperLeftY);
            }
            Position statusMsgPos = model.Camera.HorizontallyCenterTextWithinRect(m_statusMsgPosition, model.DataLoader.CurrentStatusMessage, font, g, ignoreCameraPosition: true);
            g.DrawString(model.DataLoader.CurrentStatusMessage, font, Brushes.White, (Single)statusMsgPos.UpperLeftX, (Single)statusMsgPos.UpperLeftY);
        }

        #endregion
    }
}
