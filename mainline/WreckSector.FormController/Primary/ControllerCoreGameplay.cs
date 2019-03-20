using WreckSector.Model;
using SoulErosion.GameLibrary.Forms;
using System;
using System.Windows.Forms;
using WreckSector.Model.Gameplay;

namespace WreckSector.FormController.Primary
{
    internal static class ControllerCoreGameplay
    {
        #region Internal Functions

        internal static void ApplyInput(GameModel model, UserInput userInput)
        {
            GameWorld w = model.World;

            switch (w.StateGameplay)
            {
                case GameStateGameplay.PressYourLuckPendingSelection: break;
                case GameStateGameplay.PressYourLuckTileProcessing: break;
                case GameStateGameplay.PressYourLuckTileSelected: ControllerPressYourLuck.ApplyInput(model, userInput); break;
                case GameStateGameplay.CharacterDetail: ControllerCharacterDetail.ApplyInput(model, userInput); break;
                case GameStateGameplay.SpecialPowerActivating: break;
            }
        }

        #endregion
    }
}
