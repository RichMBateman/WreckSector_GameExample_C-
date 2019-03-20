using SoulErosion.GameLibrary.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckSector.Model.Screens
{
    public class ScreenModelCredits : BaseScreenModel
    {
        #region Private Members

        private readonly UIElement m_containerUIE;
        private readonly UIElement m_trackNameUIE;

        #endregion

        #region Constructors

        public ScreenModelCredits(GameModel model) : base(model)
        {
            m_containerUIE = CreateUIElement(200, 275, 150, 250);
            m_trackNameUIE = CreateUIElement(200, 30, 150, 10);
        }

        #endregion

        #region Public Properties

        public UIElement ContainerUIE { get { return m_containerUIE; } }
        public UIElement TrackNameUIE { get { return m_trackNameUIE; } }

        #endregion
    }
}
