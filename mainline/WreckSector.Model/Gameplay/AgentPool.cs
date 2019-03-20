using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckSector.Model.Gameplay
{
    /// <summary>
    /// The pool of characters from which the Player may form a party when starting a new game.  The Pool tracks who has been unlocked,
    /// and who has not.  Otherwise, the AgentPool is not used during the game.
    /// </summary>
    public class AgentPool
    {
        #region Private Members

        private readonly List<Agent> m_availableAgents = new List<Agent>();
        private readonly List<Agent> m_unavailableAgents = new List<Agent>();

        #endregion
    }
}
