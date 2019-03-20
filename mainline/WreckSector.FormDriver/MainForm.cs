using WreckSector.FormController;
using WreckSector.Model;
using WreckSector.FormView;
using System;
using System.Windows.Forms;
using SoulErosion.GameLibrary.Core;
using SoulErosion.GameLibrary.Forms;

namespace WreckSector.FormDriver
{
    public partial class MainForm : BaseGameForm
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            Load += MainFormLoad;
        }

        #endregion

        #region Game Initialization

        private void MainFormLoad(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CenterToScreen();
            SetupGameCore();
        }

        private void SetupGameCore()
        {
            try
            {
                // Create a new GameCore, supplying this form.
                GameCore gc = new GameCore(this, GameModelDefaults.TickDurationMs);

                // Setup any custom fonts
                gc.AddCustomFont(GameModelDefaults.FontPrimaryFilePath, GameModelDefaults.FontNamePrimary);

                // Create your model, view, and controller, and register them with the game core.
                GameModel model = new GameModel();
                ControllerPrimaryInput controller = new ControllerPrimaryInput();
                ViewPrimary view = new ViewPrimary();
                gc.RegisterModelViewController(model, controller, view);

                // Kick off the loading of data.
                model.PreLoadInitialize();

                // Start the game!
                gc.Start();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An exception occurred while setting up the game: " + exc.Message);
            }
        }

        #endregion
    }
}
