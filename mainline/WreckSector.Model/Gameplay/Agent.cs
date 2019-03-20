using WreckSector.Model.Gameplay;
using SoulErosion.GameLibrary.Drawing;
using SoulErosion.GameLibrary.Numbers;
using SoulErosion.GameLibrary.Spatial;
using SoulErosion.GameLibrary.Sprites;
using System;
using System.Collections.Generic;

namespace WreckSector.Model.Gameplay
{
    /// <summary>
    /// Represents a character in the world, friend or foe.
    /// </summary>
    public class Agent : DrawableObject
    {
        #region Constants

        public const Int32 AgentHeightLogical = 32;
        public const Int32 AgentWidthLogical = 16;

        #endregion

        #region Private Members

        private readonly GameModel m_model;
        private Boolean m_isTalking;
        private readonly String m_animationPrefixKey;

        #endregion

        #region Constructors

        public Agent(GameModel m)
            : base(m)
        {
            m_model = m;
            Name = String.Format("Agent #{0:000}", RNG.Rnd(1000));
            GenerateRandomSprite();
        }

        #endregion

        #region Public Properties

        #region Identity

        /// <summary>
        /// Unique name for this agent.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// The name of the personality for this agent.
        /// </summary>
        public String Personality { get; set; }

        #endregion

        #region Animation

        /// <summary>
        /// A sprite whose only purpose is to hold onto the agent's forward still image.
        /// (Used when we want to display just this type of animation for the character, without changing their actual on-screen sprite)
        /// </summary>
        public Sprite ForwardStillImage { get; set; }
        public Boolean IsWalking { get; set; }
        public Boolean IsTalking { get; set; }

        #endregion

        #region Gameplay

        public Int32 HealthCurrent { get; set;}
        public Int32 HealthMax { get; set; }
        public Int32 ArmorCurrent { get; set;}
        public Int32 ArmorMax { get; set; }

        #endregion

        #endregion

        #region Public Method

        #region Ticks

        public void Tick()
        {
            Sprite.Tick();
            SetAnimationBasedOnState();
        }

        #endregion

        #region Animation and Display

        public void GenerateRandomSprite()
        {
            Int32 selection = RNG.Rnd(65);
            foreach (SpriteSheet ss in m_model.SpriteFactory.SpriteSheets.Values)
            {
                if (ss.Key.StartsWith("e_"))
                {
                    if (selection == 0)
                    {
                        InitSprite(ss.Key);
                        break;
                    }
                    else
                    {
                        selection--;
                    }
                }
            }
            Sprite.SetAnimation("STILL_FORWARD", false);
            ForwardStillImage = new Sprite(Sprite.Sheet);
            ForwardStillImage.SetAnimation("STILL_FORWARD", false);
        }

        public void SetAnimationBasedOnState()
        {
            if (PositionLogical != null)
            {
                String key = (IsWalking ? "WALK_" : "STILL_") + MapDirectionToAnimationWord(PositionLogical.FacingDirection);
                if (m_isTalking)
                {
                    key += "_TALK";
                }
                Sprite.SetAnimation(key, false);
            }
        }

        #endregion

        #region Gameplay

        #endregion

        #endregion

        #region Private Methods

        #region Animation and Display

        private static String MapDirectionToAnimationWord(CardinalDirection direction)
        {
            String animationWord = "FORWARD";
            switch (direction)
            {
                case CardinalDirection.North: animationWord = "BACKWARD"; break;
                case CardinalDirection.East: animationWord = "RIGHT"; break;
                case CardinalDirection.South: animationWord = "FORWARD"; break;
                case CardinalDirection.West: animationWord = "LEFT"; break;
            }
            return animationWord;
        }

        #endregion

        #endregion
    }
}
