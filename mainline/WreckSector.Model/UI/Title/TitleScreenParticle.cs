using SoulErosion.GameLibrary.Drawing;
using SoulErosion.GameLibrary.Numbers;
using SoulErosion.GameLibrary.Spatial;
using SoulErosion.GameLibrary.Time;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckSector.Model.UI.Title
{
    /// <summary>
    /// A particle that appears on the title screen
    /// </summary>
    public class TitleScreenParticle
    {
        #region Constants

        private const Int32 MinRectWidth = 50;
        private const Int32 MaxRectWidth = 200;
        private const Int32 MinRectHeight = 5;
        private const Int32 MaxRectHeight = 30;
        private const Int32 MaxAlpha = 120;
        private const Int32 MinAlpha = 0;

        #endregion

        #region Private Members

        private readonly GameModel m_model;
        private Int32 m_tickCooldown;
        private readonly Position m_positionLogical = new Position();
        private readonly TickWave m_tickWaveColor;
        private readonly TickWave m_tickWaveAlpha;
        private readonly ColorWave m_colorWave;

        #endregion

        #region Constructors

        public TitleScreenParticle(GameModel m)
        {
            m_model = m;
            m_tickWaveColor = new TickWave("TSP Color");
            m_tickWaveColor.TickCounter = RNG.Rnd(m_tickWaveColor.TickCounterMin, m_tickWaveColor.TickCounterMax);

            m_tickWaveAlpha = new TickWave("TSP Alpha");
            m_tickWaveAlpha.TickCounterMax = MaxAlpha;
            m_tickWaveAlpha.TickCounterMin = MinAlpha;
            m_tickWaveAlpha.TickCounter = RNG.Rnd(m_tickWaveAlpha.TickCounterMin, m_tickWaveAlpha.TickCounterMax);
            m_colorWave = new ColorWave("TSP", ColorsOfficial.ColorMinimumBrown, ColorsOfficial.ColorMaximumBrown, m_tickWaveColor);
            Reset();
        }

        #endregion

        #region Public Properties

        public Position PositionLogical { get { return m_positionLogical; } }

        #endregion

        #region Public Methods

        public void Tick()
        {
            m_tickWaveAlpha.Tick();
            m_tickWaveColor.Tick();
            m_colorWave.Tick();
            m_positionLogical.UpdatePositionAndSpeed();
        }

        public void Reset()
        {
            m_tickCooldown = (RNG.Rnd(100));
            m_positionLogical.Width = RNG.Rnd(MinRectWidth, MaxRectWidth);
            m_positionLogical.Height = RNG.Rnd(MinRectHeight, MaxRectHeight);
            m_positionLogical.BottomCenterX = m_model.Camera.LogicalRect.UpperLeftX - m_positionLogical.Width;
            m_positionLogical.BottomCenterY = RNG.Rnd(0, GameModelDefaults.CameraHeight + MaxRectHeight);

            Double velX = RNG.Rnd(5, 50);
            Double velY = 0;
            m_positionLogical.Velocity.SetComponents(velX, velY);
        }

        public Color GetColor()
        {
            Color c = Color.FromArgb(m_tickWaveAlpha.TickCounter, m_colorWave.CurrentColor);
            return c;
        }

        #endregion
    }
}
