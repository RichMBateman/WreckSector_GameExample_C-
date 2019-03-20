using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckSector.Model.Gameplay
{
    /// <summary>
    /// The deck describes the full set of Tiles that will appear for the Player.  The Deck starts the same, initially, and can be built up
    /// (both positively and negatively) over time.
    /// </summary>
    public class Deck
    {
        #region Private Members

        private readonly List<TileType> m_tiles = new List<TileType>();

        #endregion

        #region Constructors

        public Deck()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The tiles in the deck.
        /// </summary>
        public List<TileType> Tiles
        {
            get { return m_tiles; }
        }

        /// <summary>
        /// The number of bombs that will appear when a Mission starts.
        /// </summary>
        public Int32 NumBombs { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Populates the deck with the standard tiles for a new game.
        /// </summary>
        public void CreateDefaultDeckForNewGame()
        {
            m_tiles.Add(TileType.Credits1);
            m_tiles.Add(TileType.Credits1);
            m_tiles.Add(TileType.Credits1);
            m_tiles.Add(TileType.Credits1);
            m_tiles.Add(TileType.Credits1);
            m_tiles.Add(TileType.Credits1);
            m_tiles.Add(TileType.Credits1);

            m_tiles.Add(TileType.Credits3);
            m_tiles.Add(TileType.Credits3);
            m_tiles.Add(TileType.Credits3);

            m_tiles.Add(TileType.Credits5);

            m_tiles.Add(TileType.AllyF);
            m_tiles.Add(TileType.AllyF);

            m_tiles.Add(TileType.EnemyF);
            m_tiles.Add(TileType.EnemyF);
            m_tiles.Add(TileType.EnemyF);
            m_tiles.Add(TileType.EnemyF);
            m_tiles.Add(TileType.EnemyF);
            m_tiles.Add(TileType.EnemyF);
            m_tiles.Add(TileType.EnemyF);

            m_tiles.Add(TileType.Attack);
            m_tiles.Add(TileType.Attack);
            m_tiles.Add(TileType.Attack);

            m_tiles.Add(TileType.Choice);
        }

        #endregion
    }
}
