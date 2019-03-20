using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckSector.Model.Gameplay
{
    /// <summary>
    /// Describes a mission.
    /// </summary>
    public class Mission
    {
        #region Private Members

        private Deck m_deck;

        #endregion

        #region Public Properties

        public Int32 NumRoundsRemaining { get; set; }

        #endregion

    }
}
