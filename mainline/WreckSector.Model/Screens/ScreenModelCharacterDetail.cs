using SoulErosion.GameLibrary.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckSector.Model.Screens
{
    public class ScreenModelCharacterDetail : BaseScreenModel
    {
        #region Private Members

        private readonly UIElement m_arrowLeft;
        private readonly UIElement m_arrowRight;
        private readonly UIElement m_sprite;
        private readonly UIElement m_title;
        private readonly UIElement m_health;
        private readonly UIElement m_armor;
        private readonly UIElement m_awareness;
        private readonly UIElement m_charisma;
        private readonly UIElement m_luck;
        private readonly UIElement m_resolve;
        private readonly UIElement m_science;
        private readonly UIElement m_tactical;

        #endregion

        #region Constructors

        public ScreenModelCharacterDetail(GameModel model) : base(model)
        {
            m_arrowLeft = CreateUIElement(25,25,25,25);
            m_arrowRight = CreateUIElement(75,25,25,26);
            m_sprite = CreateUIElement(50,25,25,25);
            m_title = CreateUIElement(200,30,400,30);
            m_health = CreateUIElement(200,50,400,4);
            m_armor = CreateUIElement(200,80,400,4);
            m_awareness = CreateUIElement(200,110,400,4);
            m_charisma = CreateUIElement(200,140,400,4);
            m_luck = CreateUIElement(200,170,400,4);
            m_resolve = CreateUIElement(200,200,400,4);
            m_science = CreateUIElement(200,230,400,4);
            m_tactical = CreateUIElement(200,260,400,4);
        }

        #endregion

        #region Public Properties

        public UIElement ArrowLeft{get {return m_arrowLeft; }}
        public UIElement ArrowRight{get {return m_arrowRight; }}
        public UIElement Sprite{get {return m_sprite; }}
        public UIElement Title{get {return m_title; }}
        public UIElement Health{get {return m_health; }}
        public UIElement Armor{get {return m_armor; }}
        public UIElement Awareness{get {return m_awareness; }}
        public UIElement Charisma{get {return m_charisma; }}
        public UIElement Luck{get {return m_luck; }}
        public UIElement Resolve{get {return m_resolve; }}
        public UIElement Science{get {return m_science; }}
        public UIElement Tactical{get {return m_tactical; }}

        #endregion
    }
}
