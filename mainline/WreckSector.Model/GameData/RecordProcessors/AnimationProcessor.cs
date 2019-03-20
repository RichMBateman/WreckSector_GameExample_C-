using SoulErosion.GameLibrary.Core;
using SoulErosion.GameLibrary.GameData;
using SoulErosion.GameLibrary.Sprites;
using System;
using System.Collections.Generic;

namespace WreckSector.Model.GameData.RecordProcessors
{
    public static class AnimationProcessor
    {
        #region Record Type

        public const String RecordTypeAnimation = "ANI";
        public const Int32 RecordTypeSortOrderAnimation = 3;

        #endregion

        #region Constants

        private const String KeyForSprite = "ForSprite";
        private const String KeyForSpriteCategory = "ForSpriteCategory";
        private const String KeyName = "Name";
        private const String KeyOverallDelay = "OverallDelay";
        private const String KeyFrames = "Frames";

        #endregion

        #region Public Api

        public static void Process(BaseGameModel baseGameModel, NvpRecord record)
        {
            GameModel model = baseGameModel as GameModel;
            Animation animation = new Animation();
            String forSprite = null;
            foreach (KeyValuePair<String, String> kvp in record.NameValuePairs)
            {
                switch (kvp.Key)
                {
                    case KeyForSprite:
                        forSprite = kvp.Value;
                        break;
                    case KeyForSpriteCategory:
                        animation.Category = kvp.Value;
                        break;
                    case KeyName:
                        animation.Key = kvp.Value;
                        break;
                    case KeyOverallDelay:
                        animation.OverallDelay = Int32.Parse(kvp.Value);
                        break;
                    case KeyFrames:
                        ProcessAnimationFrames(animation, kvp.Value);
                        break;
                }
            }
            model.SpriteFactory.AddAnimation(animation);
        }

        #endregion

        #region Private Methods

        private static void ProcessAnimationFrames(Animation animation, String framesEntry)
        {
            String[] frameEntries = framesEntry.Split(',');
            for (Int32 frameEntryIndex = 0; frameEntryIndex < frameEntries.Length; frameEntryIndex++)
            {
                String entry = frameEntries[frameEntryIndex];
                String[] entryValues = entry.Split('|');
                Int32 x = Int32.Parse(entryValues[0]);
                Int32 y = Int32.Parse(entryValues[1]);
                Int32 delay = 0;
                if (entryValues.Length >= 3)
                {
                    delay = Int32.Parse(entryValues[2]);
                }
                else
                {
                    delay = animation.OverallDelay;
                }
                animation.AddFrame(x, y, delay);
            }
        }

        #endregion
    }
}
