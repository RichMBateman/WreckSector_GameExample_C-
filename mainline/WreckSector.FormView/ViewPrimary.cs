using SoulErosion.GameLibrary.Core;
using SoulErosion.GameLibrary.Forms;
using System;
using System.Drawing;
using WreckSector.FormView.Debug;
using WreckSector.FormView.Gameplay;
using WreckSector.FormView.Title;
using WreckSector.Model;
using WreckSector.Model.Gameplay;

namespace WreckSector.FormView
{
    /// <summary>
    /// All drawing starts here.
    /// </summary>
    public class ViewPrimary : BaseView
    {
        #region Framework Api

        /// <summary>
        /// Draws the Game.
        /// </summary>
        public override void Draw(BaseGameModel model, Painter painter, Graphics g, int totalClientWidth, int totalClientHeight)
        {
            GameModel m = model as GameModel;
            if (m != null && m.World != null)
            {
                GameWorld w = m.World;
                if(m.ReadyToDraw)
                {
                    switch (w.StatePrimary)
                    {
                        case GameStatePrimary.LoadingResources:
                        case GameStatePrimary.MainMenu:
                        case GameStatePrimary.GameInProgressMenu:
                            ViewTitleMenu.Draw(m, painter, g);
                            break;
                        case GameStatePrimary.CoreGamePlay:
                            ViewCoreGameplay.Draw(m, painter, g, totalClientWidth, totalClientHeight);
                            break;
                        case GameStatePrimary.Exiting: break;
                    }

                    ViewDebugPrimary.Draw(m, painter, g, totalClientWidth, totalClientHeight);
                }
            }
        }

        #endregion
    }
}
