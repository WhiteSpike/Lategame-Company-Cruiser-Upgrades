using MoreShipUpgrades.Managers;
using MoreShipUpgrades.Misc.TerminalNodes;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using UnityEngine;
using LategameCompanyCruiserUpgrades.Misc;

namespace LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades
{
    internal class IgnitionCoil : TierUpgrade
    {
        internal const string UPGRADE_NAME = "Ignition Coil";
        internal const string PRICES_DEFAULT = "50,100,100";

        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.IGNITION_COIL_OVERRIDE_NAME;
            base.Start();
        }
        public static float ComputeAdditionalIgnitionChance()
        {
            return Plugin.Config.IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE);
        }
        public static float GetAdditionalIgnitionChance(float defaultValue)
        {
            if (!Plugin.Config.IMPROVED_STEERING_ENABLED) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float additionalValue = ComputeAdditionalIgnitionChance();
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, float.MaxValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.IGNITION_COIL_PRICES.Value.Split(',');
                return Plugin.Config.IGNITION_COIL_PRICE.Value <= 0 && prices.Length == 1 && (prices[0] == "" || prices[0] == "0");
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            System.Func<int, float> infoFunction = level => Plugin.Config.IGNITION_COIL_IGNITION_INITIAL_CHANCE_INCREASE.Value + (level * Plugin.Config.IGNITION_COIL_IGNITION_INCREMENTAL_CHANCE_INCREASE.Value);
            const string infoFormat = "LVL {0} - ${1} - Chance to start ignition on Company Cruiser Vehicle is increased by {2}%.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.IGNITION_COIL_ITEM_PROGRESSION_ITEMS.Value.Split(","));
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
            PluginConfig configuration = Plugin.Config;

            return UpgradeBus.Instance.SetupMultiplePurchasableTerminalNode(UPGRADE_NAME,
                                                shareStatus: true,
                                                configuration.IGNITION_COIL_ENABLED.Value,
                                                configuration.IGNITION_COIL_PRICE.Value,
                                                UpgradeBus.ParseUpgradePrices(configuration.IGNITION_COIL_PRICES.Value),
                                                UpgradeBus.Instance.PluginConfiguration.OVERRIDE_UPGRADE_NAMES ? configuration.IGNITION_COIL_OVERRIDE_NAME : "",
                                                Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
