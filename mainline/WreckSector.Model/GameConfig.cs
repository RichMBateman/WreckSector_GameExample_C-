using System;
using System.Collections.Generic;
using System.Drawing;

namespace WreckSector.Model
{
    /// <summary>
    /// The Game Configuration consists of two basic parts:
    /// -Absolute Defaults to use in absence of any other information.
    /// -The Actual Values to use (may be overridden in a configuration file)
    /// </summary>
    public class GameConfig
    {
        #region Constants


        #endregion

        #region Private Members

        private readonly GameModel m_model;
        private readonly List<Color> m_transparentColors = new List<Color>();
        private Int32 m_simulateLoadingDelay;
        private readonly List<String> m_initialArsenalAbilities = new List<String>();
        private Int32 m_initialArsenalSlots = 0;

        #endregion

        #region Constructors

        public GameConfig(GameModel model)
        {
            m_model = model;
            SimulateLoadingDelay = GameModelDefaults.DefaultSimulateLoadingDelayMs;
        }

        #endregion

        #region Public Properties

        #region Initialization and Game Data

        /// <summary>
        /// Number of milliseconds to wait after each loading operation.
        /// </summary>
        public Int32 SimulateLoadingDelay
        {
            get { return m_simulateLoadingDelay; }
            set
            {
                if (m_simulateLoadingDelay != value)
                {
                    m_simulateLoadingDelay = value;
                    m_model.DataLoader.SimulatedLoadingDelay = m_simulateLoadingDelay;
                }
            }
        }

        #endregion

        #region Graphics and Art

        /// <summary>
        /// Colors which are marked as transparent in sprites.
        /// </summary>
        public List<Color> TransparentColors { get { return m_transparentColors; } }

        #endregion

        #region Arsenal Abilities

        public Int32 InitialArsenalSlots { get { return m_initialArsenalSlots; } set { m_initialArsenalSlots = value; } }
        public List<String> InitialArsenalAbilities { get { return m_initialArsenalAbilities; } }

        #endregion

        #endregion
    }
}
