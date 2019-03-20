using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckSector.Model.Gameplay
{
    /// <summary>
    /// The Player's party.  Keeps track of the members, character pool, resources. 
    /// </summary>
    public class Party
    {
        #region Private Members

        private readonly GameModel m_gameModel;
        private readonly List<Agent> m_activeMembers = new List<Agent>();
        private readonly List<Agent> m_characterPool = new List<Agent>();

        #endregion

        #region Constructors

        public Party(GameModel gameModel)
        {
            m_gameModel = gameModel;
        }

        #endregion

        #region Public Properties

        public Int32 LifeSupport { get; set; }
        public Int32 Power { get; set; }
        public Int32 Credit { get; set; }
        public Int32 Scrap { get; set; }
        public List<Agent> AgentsActive { get { return m_activeMembers; } }

        #endregion

        #region Public Methods

        public void ResetForNewGame()
        {
            CreateAgentsForNewGameParty();
            ResetResourcesForNewGame();
        }


        /// <summary>
        /// Adds a new agent (randomized) to the party.  If there are no available slots, the character goes into the pool
        /// </summary>
        public void AddAgent(Int32 initialHealth, Int32 initialArmor, Int32 initialAttributePoints)
        {
            Agent a = new Agent(m_gameModel);
            a.HealthCurrent = initialHealth;
            a.HealthMax = initialHealth;
            a.ArmorCurrent = initialArmor;
            a.ArmorMax = initialArmor;

            if (m_activeMembers.Count >= GameConstants.PartySizeMax)
            {
                m_characterPool.Add(a);
            }
            else
            {
                m_activeMembers.Add(a);
            }
        }

        #endregion

        #region Private Methods

        private void CreateAgentsForNewGameParty()
        {
            for (Int32 i = GameConstants.PartySizeInitial; i > 0; i--)
            {
                AddAgent(GameConstants.AgentHealthNewGame, GameConstants.AgentArmorNewGame, GameConstants.AgentAttributePointsNewGame);
            }
        }

        private void ResetResourcesForNewGame()
        {
            LifeSupport = GameConstants.PartyLifeSupportNewGame;
            Power = GameConstants.PartyPowerNewGame;
            Credit = GameConstants.PartyCreditsNewGame;
            Scrap = GameConstants.PartyScrapNewGame;
        }

        #endregion


    }
}
