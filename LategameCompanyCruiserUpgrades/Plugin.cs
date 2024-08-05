using BepInEx;
using BepInEx.Logging;
using LategameCompanyCruiserUpgrades.Misc;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.Misc.Upgrades;
using LategameCompanyCruiserUpgrades.Patches;
namespace LategameCompanyCruiserUpgrades
{
    [BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    [BepInDependency("com.sigurd.csync")]
    [BepInDependency("evaisa.lethallib")]
    [BepInDependency("com.malco.lethalcompany.moreshipupgrades")]
    public class Plugin : BaseUnityPlugin
    {
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);
        internal static readonly Dictionary<string, GameObject> networkPrefabs = [];
        public new static PluginConfig Config;

        void Awake()
        {
            Config = new PluginConfig(base.Config);

            // netcode patching stuff
            IEnumerable<Type> types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null);
            }
            foreach (var type in types)
            {
                var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(RuntimeInitializeOnLoadMethodAttribute), false);
                    if (attributes.Length > 0)
                    {
                        method.Invoke(null, null);
                    }
                }
            }
            SetupPerks(ref types);
            harmony.PatchAll(typeof(PlayerControllerBPatcher));
            mls.LogInfo("Player controllers have been patched");
            harmony.PatchAll(typeof(VehicleControllerPatcher));
            mls.LogInfo("Vehicles have been patched");

            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }
        private void SetupPerks(ref IEnumerable<Type> types)
        {
            foreach (Type type in types)
            {
                if (!type.IsSubclassOf(typeof(BaseUpgrade))) continue;
                UpgradeBus.Instance.upgradeTypes.Add(type);

                MethodInfo method = type.GetMethod(nameof(BaseUpgrade.RegisterUpgrade), BindingFlags.Static | BindingFlags.Public);
                method.Invoke(null, null);
            }
            mls.LogInfo("Upgrades have been setup");
        }
    }   
}
