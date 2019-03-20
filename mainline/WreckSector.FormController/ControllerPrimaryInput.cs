using WreckSector.Model;
using SoulErosion.GameLibrary.Core;
using System;
using SoulErosion.GameLibrary.Forms;
using WreckSector.FormController.Primary;
using WreckSector.FormController.Debug;
using WreckSector.Model.Gameplay;

namespace WreckSector.FormController
{
    /// <summary>
    /// All input starts here.
    /// </summary>
    public class ControllerPrimaryInput : BaseController
    {
        #region Public Static Methods

        /// <summary>
        /// ALL Player Input checking starts here.
        /// </summary>
        public override void ApplyInput(BaseGameModel model, UserInput userInput)
        {
            base.ApplyInput(model, userInput);
            GameModel m = model as GameModel;
            GameWorld world = m.World;

            switch (world.StatePrimary)
            {
                case GameStatePrimary.MainMenu: ControllerMainMenu.ApplyInput(m, userInput); break;
                case GameStatePrimary.CoreGamePlay: ControllerCoreGameplay.ApplyInput(m, userInput); break;
            }

            // Also check for Debug key presses
            ControllerDebug.ApplyInput(m, userInput);
        }

        #endregion
    }
}
