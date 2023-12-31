﻿//global using IngredientLib;
//global using IngredientLib.Ingredient.Items;
global using Kitchen;
global using KitchenData;
global using KitchenLib;
global using KitchenLib.Colorblind;
global using KitchenLib.Customs;
global using KitchenLib.Event;
global using KitchenLib.References;
global using KitchenLib.Utils;
global using KitchenMods;
global using System.Collections.Generic;
global using System.Linq;
global using System.Reflection;
global using Unity.Collections;
global using Unity.Entities;
global using UnityEngine;
global using static KitchenLib.Utils.GDOUtils;
global using static KitchenLib.Utils.KitchenPropertiesUtils;
global using static KitchenXLB.Helpers;

// Namespace should have "Kitchen" in the beginning
namespace KitchenXLB
{
    public class Mod : BaseMod, IModSystem
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "com.waterlemon.xlb";
        public const string MOD_NAME = "XLB";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "waterlemon";
        public const string MOD_GAMEVERSION = ">=1.1.4";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until

        // Boolean constant whose value depends on whether you built with DEBUG or RELEASE mode, useful for testing
#if DEBUG
        public const bool DEBUG_MODE = true;
#else
        public const bool DEBUG_MODE = false;
#endif

        public static AssetBundle Bundle;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");

        }

        private void AddMaterials()
        {
            AddMaterial(CreateFlat("Basket", 0xDEB670));
            AddMaterial(CreateFlat("BasketDark", 0xCB9542));
            AddMaterial(CreateFlat("Bao", 0xE7E7E7));
            AddMaterial(CreateFlat("BaoDark", 0xBEB190));
        }

        private void AddGameData()
        {
            LogInfo("Attempting to register game data...");

            // AddGameDataObject<MyCustomGDO>();
            MethodInfo AddGDOMethod = typeof(BaseMod).GetMethod(nameof(BaseMod.AddGameDataObject));
            int counter = 0;
            Log("Registering GameDataObjects.");
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsAbstract || typeof(IWontRegister).IsAssignableFrom(type))
                    continue;

                if (!typeof(CustomGameDataObject).IsAssignableFrom(type))
                    continue;

                MethodInfo generic = AddGDOMethod.MakeGenericMethod(type);
                generic.Invoke(this, null);
                LogInfo(generic.Name);
                counter++;
            }
            Log($"Registered {counter} GameDataObjects.");

            LogInfo("Done loading game data.");
        }

        protected override void OnUpdate()
        {
/*            var appliances = Appliances.ToEntityArray(Allocator.TempJob);
            foreach (var appliance in appliances)
            {
                EntityManager.AddComponent<CIsOnFire>(appliance);
                EntityManager.AddComponent<CHasBeenSetOnFire>(appliance);
            }
            appliances.Dispose();*/
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            // TODO: Uncomment the following if you have an asset bundle.
            // TODO: Also, make sure to set EnableAssetBundleDeploy to 'true' in your ModName.csproj

            LogInfo("Attempting to load asset bundle...");
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            LogInfo("Done loading asset bundle.");

            // Register custom GDOs
            AddGameData();

            AddMaterials();

            // Perform actions when game data is built
            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                args.gamedata.ProcessesView.Initialise(args.gamedata);
            };
        }
        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
