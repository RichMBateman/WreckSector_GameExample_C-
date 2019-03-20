using WreckSector.Model;
using WreckSector.Model.UI.Title;
using SoulErosion.GameLibrary.Forms;
using System.Windows.Forms;
using WreckSector.Model.Screens;

namespace WreckSector.FormController.Primary
{
    internal static class ControllerMainMenu
    {
        #region Internal Functions

        internal static void ApplyInput(GameModel model, UserInput userInput)
        {
            ScreenModelTitleMenu t = model.SMTitleMenu;
            switch (model.World.StatePrimary)
            {
                case GameStatePrimary.GameInProgressMenu: AcceptInputInProgressMenu(model, t, userInput); break;
                case GameStatePrimary.LoadingResources: break; // Don't accept any input.
                case GameStatePrimary.MainMenu: AcceptInputMainMenu(model, t, userInput); break;
            }
        }

        #endregion

        #region Private Functions

        private static void AcceptInputInProgressMenu(GameModel model, ScreenModelTitleMenu t, UserInput userInput)
        {
            if ((t.InGameMenuReturnUIE.IsMousedOver && userInput.IsKeyDownWithDelay(Keys.LButton)) || userInput.IsKeyDownWithDelay(Keys.R)
                || userInput.IsKeyDownWithDelay(Keys.Escape))
            {
                model.ReturnToGame();
            }

            if ((t.InGameMenuSaveAndMenuUIE.IsMousedOver && userInput.IsKeyDownWithDelay(Keys.LButton)) || userInput.IsKeyDownWithDelay(Keys.M)
                || userInput.IsKeyDownWithDelay(Keys.S))
            {
                model.SaveGameAndMenu();
            }

            if ((t.InGameMenuSaveAndExitUIE.IsMousedOver && userInput.IsKeyDownWithDelay(Keys.LButton)) || userInput.IsKeyDownWithDelay(Keys.E)
                || userInput.IsKeyDownWithDelay(Keys.X))
            {
                model.SaveGameAndExit();
            }
        }
        private static void AcceptInputMainMenu(GameModel model, ScreenModelTitleMenu t, UserInput userInput)
        {
            if ((t.MainNewGameUIE.IsMousedOver && userInput.IsKeyDownWithDelay(Keys.LButton)) || userInput.IsKeyDownWithDelay(Keys.N))
            {
                model.NewGame();
            }

            if ((t.MainLoadGameUIE.IsMousedOver && userInput.IsKeyDownWithDelay(Keys.LButton)) || userInput.IsKeyDownWithDelay(Keys.L))
            {
                model.LoadGame();
            }

            if ((t.MainExitGameUIE.IsMousedOver && userInput.IsKeyDownWithDelay(Keys.LButton)) || userInput.IsKeyDownWithDelay(Keys.L))
            {
                model.ExitGame();
            }
        }

        #endregion
    }
}
