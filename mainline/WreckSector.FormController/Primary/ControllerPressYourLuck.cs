using SoulErosion.GameLibrary.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WreckSector.Model;

namespace WreckSector.FormController.Primary
{
    public static class ControllerPressYourLuck
    {
        public static void ApplyInput(GameModel model, UserInput userInput)
        {
            //MainGameplayScreenModel mainGamplayScreenModel = model.MainGameplayScreenModel;
            //ScenarioPresentationModel scenarioPresModel = mainGamplayScreenModel.ScenarioPresentationModel;
            //OutcomeSelectorModel outcomeSelModel = mainGamplayScreenModel.OutcomeSelectorModel;
            //OptionConsequenceModel optionCsqModel = mainGamplayScreenModel.OptionConsequenceModel;

            if (userInput.IsKeyDownWithDelay(Keys.Space))
            {
                //    ScenarioOptionConsequenceRating rating = outcomeSelModel.GetSelectedRating();
                //    optionCsqModel.AcceptOutcomeRating(outcomeSelModel.ActiveOption, rating);
                //    mainGamplayScreenModel.TransitionToConsequencePresentation();
                //model.TransitionToEventPlay();
            }
        }
    }
}
