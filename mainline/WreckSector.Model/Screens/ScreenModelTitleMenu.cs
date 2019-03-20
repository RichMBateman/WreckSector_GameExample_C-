using SoulErosion.GameLibrary.Forms;
using System;
using System.Collections.Generic;
using WreckSector.Model.UI.Title;

namespace WreckSector.Model.Screens
{
    public class ScreenModelTitleMenu : BaseScreenModel
    {
        #region Constants

        public const String GameTitleText = "WreckSector";
        private const Int32 NumParticles = 50;

        #endregion

        #region Private Members

        private readonly UIElement m_mainNewGameUIE;
        private readonly UIElement m_mainLoadGameUIE;
        private readonly UIElement m_mainCreditsUIE;
        private readonly UIElement m_mainExitGameUIE;
        private readonly UIElement m_inGameMenuSaveAndMenuUIE;
        private readonly UIElement m_inGameMenuSaveAndExitUIE;
        private readonly UIElement m_inGameMenuReturnUIE;

        #endregion

        #region Constructors

        public ScreenModelTitleMenu(GameModel model) : base(model)
        {
            m_mainNewGameUIE = CreateUIElement(200, 100, 400, 20);
            m_mainLoadGameUIE = CreateUIElement(200, 150, 400, 20);
            m_mainCreditsUIE = CreateUIElement(200, 200, 400, 20);
            m_mainExitGameUIE = CreateUIElement(200, 250, 400, 20);
            m_inGameMenuSaveAndMenuUIE = CreateUIElement(200, 100, 400, 20);
            m_inGameMenuSaveAndExitUIE = CreateUIElement(200, 150, 400, 20);
            m_inGameMenuReturnUIE = CreateUIElement(200, 200, 400, 20);

            InitializeParticleSystem();
        }

        #endregion

        #region Public Properties

        public UIElement MainNewGameUIE { get { return m_mainNewGameUIE; } }
        public UIElement MainLoadGameUIE { get { return m_mainLoadGameUIE; } }
        public UIElement MainCreditsUIE { get { return m_mainCreditsUIE; } }
        public UIElement MainExitGameUIE { get { return m_mainExitGameUIE; } }
        public UIElement InGameMenuSaveAndMenuUIE { get { return m_inGameMenuSaveAndMenuUIE; } }
        public UIElement InGameMenuSaveAndExitUIE { get { return m_inGameMenuSaveAndExitUIE; } }
        public UIElement InGameMenuReturnUIE { get { return m_inGameMenuReturnUIE; } }


        #region Particle System

        /// <summary>
        /// The set of agent particles to draw on screen.
        /// </summary>
        public List<TitleScreenParticle> Particles { get; private set; }

        #endregion

        #endregion

        #region Public Methods

        public override void Tick()
        {
            base.Tick();
            AcceptFrameTickParticleSystem();
        }

        #endregion

        #region Private Methods

        #region Particle System

        private void AcceptFrameTickParticleSystem()
        {
            foreach (TitleScreenParticle ap in Particles)
            {
                ap.Tick();
                CheckForOffScreenParticle(ap);
            }
        }

        private void CheckForOffScreenParticle(TitleScreenParticle ap)
        {
            if (ap.PositionLogical.UpperLeftX > GameModelDefaults.CameraWidth)
            {
                ap.Reset();
            }
        }

        /// <summary>
        /// Initializes the particle system.  Game data should be fully loaded.
        /// </summary>
        private void InitializeParticleSystem()
        {
            Particles = new List<TitleScreenParticle>();
            for (Int32 p = 0; p < NumParticles; p++)
            {
                TitleScreenParticle ap = new TitleScreenParticle((GameModel) m_model);
                Particles.Add(ap);
            }
        }

        #endregion

        #endregion
    }
}
