using SoulErosion.GameLibrary.Core;
using SoulErosion.GameLibrary.GameData;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace WreckSector.Model.GameData.RecordProcessors
{
    class ConfigProcessor
    {
        #region Record Type

        public const String RecordTypeGameConfig = "CFG";
        public const Int32 RecordTypeSortOrderGameConfig = 1;

        #endregion

        #region Constants - Keys

        // Initialization and Game Data
        private const String KeySimulateLoadingDelay = "SimulateLoadingDelay";
        // Graphics and Art
        private const String KeyTransparentColor = "TransparentColor";
        // Arsenal Abilities
        private const String KeyInitialArsenalSlots = "InitialArsenalSlots";
        private const String KeyInitialArsenalAbility = "InitialArsenalAbility";

        #endregion

        #region Public Api

        public static void Process(BaseGameModel baseGameModel, NvpRecord record)
        {
            GameModel model = baseGameModel as GameModel;
            GameConfig cfg = model.Config;
            foreach (KeyValuePair<String, String> kvp in record.NameValuePairs)
            {
                switch (kvp.Key)
                {
                    case KeySimulateLoadingDelay: cfg.SimulateLoadingDelay = Int32.Parse(kvp.Value); break;
                    case KeyTransparentColor: AddTransparentColor(cfg, kvp.Value); break;
                    case KeyInitialArsenalAbility: AddInitialArsenalAbilities(cfg, kvp.Value); break;
                    case KeyInitialArsenalSlots: cfg.InitialArsenalSlots = Int32.Parse(kvp.Value); break;
                }
            }
        }

        #endregion

        #region Private Methods

        private static void AddTransparentColor(GameConfig cfg, String cfgEntry)
        {
            String[] rgbSplit = cfgEntry.Split(',');
            Int32 r = Int32.Parse(rgbSplit[0]);
            Int32 g = Int32.Parse(rgbSplit[1]);
            Int32 b = Int32.Parse(rgbSplit[2]);
            Color clr = Color.FromArgb(r, g, b);
            cfg.TransparentColors.Add(clr);
        }

        private static void AddInitialArsenalAbilities(GameConfig cfg, String initArsAbls)
        {
            cfg.InitialArsenalAbilities.Add(initArsAbls);
        }

        #endregion
    }
}
