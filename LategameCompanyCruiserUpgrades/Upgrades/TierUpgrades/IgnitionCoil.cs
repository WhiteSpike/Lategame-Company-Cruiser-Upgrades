using MoreShipUpgrades.Managers;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using UnityEngine;
using LategameCompanyCruiserUpgrades.Misc;

namespace LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades
{
    internal class IgnitionCoil : TierUpgrade
    {
        internal const string UPGRADE_NAME = "Ignition Coil";
        internal const string PRICES_DEFAULT = "50,50,100,100";

        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.IgnitionCoilConfiguration.OverrideName;
            base.Start();
        }
        public static float ComputeAdditionalIgnitionChance()
        {
            return Plugin.Config.IgnitionCoilConfiguration.InitialEffect + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.IgnitionCoilConfiguration.IncrementalEffect);
        }
        public static float GetAdditionalIgnitionChance(float defaultValue)
        {
            if (!Plugin.Config.IgnitionCoilConfiguration.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float additionalValue = ComputeAdditionalIgnitionChance();
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, float.MaxValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.IgnitionCoilConfiguration.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            System.Func<int, float> infoFunction = level => Plugin.Config.IgnitionCoilConfiguration.InitialEffect.Value + (level * Plugin.Config.IgnitionCoilConfiguration.IncrementalEffect.Value);
            const string infoFormat = "LVL {0} - ${1} - Chance to start ignition on Company Cruiser Vehicle is increased by {2}%.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.IgnitionCoilConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            GameObject prefab = LethalLib.Modules.NetworkPrefabs.CreateNetworkPrefab(UPGRADE_NAME);
            prefab.AddComponent<IgnitionCoil>();
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(prefab);
            Plugin.networkPrefabs[UPGRADE_NAME] = prefab;
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME,Plugin.Config.IgnitionCoilConfiguration, Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
