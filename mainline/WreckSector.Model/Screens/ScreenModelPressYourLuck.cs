using SoulErosion.GameLibrary.Forms;
using SoulErosion.GameLibrary.Numbers;
using SoulErosion.GameLibrary.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WreckSector.Model.Gameplay;

namespace WreckSector.Model.Screens
{
    public class ScreenModelPressYourLuck : BaseScreenModel
    {
        #region Private Members

        private readonly WreckSector.Model.Gameplay.TileType[,] m_ratingGrid = new WreckSector.Model.Gameplay.TileType[5, 5];
        private Int32 m_ticksRemainingBoardChange = 10;
        private Int32 m_ticksRemainingSelectionChange = 4;
        private Int32 m_selectedX, m_selectedY;
        //private ScenarioOption m_activeOption;

        private readonly Position m_logPosSelectorBoundary = new Position(200, 275, 250, 250);


        private readonly UIElement m_containerUIE;
        private readonly UIElement m_trackNameUIE;

        #endregion

        #region Constructors

        public ScreenModelPressYourLuck(GameModel model) : base(model)
        {
            m_containerUIE = CreateUIElement(200, 275, 150, 250);
            m_trackNameUIE = CreateUIElement(200, 30, 150, 10);

            GenerateNewBoard();
            GenerateNewSelection();
        }

        #endregion

        #region Public Properties

        public Position LogPosSelectorBoundary { get { return m_logPosSelectorBoundary; } }
        public WreckSector.Model.Gameplay.TileType[,] RatingGrid { get { return m_ratingGrid; } }
        public Int32 SelectedX { get { return m_selectedX; } }
        public Int32 SelectedY { get { return m_selectedY; } }
        //public ScenarioOption ActiveOption { get { return m_activeOption; } }

        public UIElement ContainerUIE { get { return m_containerUIE; } }
        public UIElement TrackNameUIE { get { return m_trackNameUIE; } }

        #endregion
        #region Public Methods

        //public void InitializeWithOption(ScenarioOption option)
        //{
        //    m_activeOption = option;
        //}

        public TileType GetSelectedRating()
        {
            TileType rating = m_ratingGrid[m_selectedX, m_selectedY];
            return rating;
        }

        public override void Tick()
        {
            base.Tick();
            m_ticksRemainingBoardChange--;
            if (m_ticksRemainingBoardChange <= 0)
            {
                m_ticksRemainingBoardChange = 10;
                GenerateNewBoard();
            }
            m_ticksRemainingSelectionChange--;
            if (m_ticksRemainingSelectionChange <= 0)
            {
                m_ticksRemainingSelectionChange = 4;
                GenerateNewSelection();
            }
        }

        #endregion

        #region Private Methods

        private void GenerateNewBoard()
        {
            for (Int32 colIndex = 0; colIndex < 5; colIndex++)
            {
                for (Int32 rowIndex = 0; rowIndex < 5; rowIndex++)
                {
                    m_ratingGrid[colIndex, rowIndex] = (TileType)RNG.Rnd(GameConstants.NumConsequenceRatings);
                }
            }
        }

        private void GenerateNewSelection()
        {
            m_selectedX = RNG.Rnd(5);
            m_selectedY = RNG.Rnd(5);
        }

        #endregion

    }
}
