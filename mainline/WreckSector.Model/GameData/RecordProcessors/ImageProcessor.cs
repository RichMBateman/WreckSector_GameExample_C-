using SoulErosion.GameLibrary.Core;
using SoulErosion.GameLibrary.GameData;
using SoulErosion.GameLibrary.Sprites;
using System;
using System.Drawing;
using System.IO;

namespace WreckSector.Model.GameData.RecordProcessors
{
    public static class ImageProcessor
    {
        #region Record Type

        public const String RecordTypeImage = "IMG";
        public const Int32 RecordTypeSortOrderImage = 2;

        #endregion

        #region Constants

        private const String KeyCategory = "Category";
        private const String KeyKeyPrefix = "KeyPrefix";
        private const String KeyPath = "Path";
        private const String KeyNumFramesX = "NumFramesX";
        private const String KeyNumFramesY = "NumFramesY";
        private const String KeyBorderWidth = "BorderWidth";

        #endregion

        #region Public Api

        public static void Process(BaseGameModel baseGameModel, NvpRecord record)
        {
            GameModel model = baseGameModel as GameModel;
            if (model != null)
            {
                SpriteSheet sheet = new SpriteSheet();
                if (record.NameValuePairs.ContainsKey(KeyCategory))
                {
                    sheet.Category = record.NameValuePairs[KeyCategory];
                }
                if (record.NameValuePairs.ContainsKey(KeyPath))
                {
                    String path = record.NameValuePairs[KeyPath];
                    sheet.ImageData = new Bitmap(path);
                    foreach (Color transparentColor in model.Config.TransparentColors)
                    {
                        sheet.ImageData.MakeTransparent(transparentColor);
                    }
                    String baseKey = Path.GetFileNameWithoutExtension(path);
                    if (record.NameValuePairs.ContainsKey(KeyKeyPrefix))
                    {
                        sheet.Key = String.Concat(record.NameValuePairs[KeyKeyPrefix], baseKey);
                    }
                    else
                    {
                        sheet.Key = baseKey;
                    }
                }
                if (record.NameValuePairs.ContainsKey(KeyNumFramesX))
                {
                    sheet.NumFramesX = Int32.Parse(record.NameValuePairs[KeyNumFramesX]);
                }
                else
                {
                    sheet.NumFramesX = 1;
                }
                if (record.NameValuePairs.ContainsKey(KeyNumFramesY))
                {
                    sheet.NumFramesY = Int32.Parse(record.NameValuePairs[KeyNumFramesY]);
                }
                else
                {
                    sheet.NumFramesY = 1;
                }
                if (record.NameValuePairs.ContainsKey(KeyBorderWidth))
                {
                    sheet.BorderWidth = Int32.Parse(record.NameValuePairs[KeyBorderWidth]);
                }
                else
                {
                    sheet.BorderWidth = 1;
                }

                sheet.FrameWidth = (sheet.ImageData.Width - sheet.BorderWidth) / sheet.NumFramesX - sheet.BorderWidth;
                sheet.FrameHeight = (sheet.ImageData.Height - sheet.BorderWidth) / sheet.NumFramesY - sheet.BorderWidth;

                model.SpriteFactory.AddSpriteSheet(sheet);
            }
        }

        #endregion
    }
}
