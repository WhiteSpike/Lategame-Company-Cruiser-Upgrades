using LategameCompanyCruiserUpgrades.Misc;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using UnityEngine;

namespace LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades
{
    internal class BrakeFluid : TierUpgrade
    {
        internal const string UPGRADE_NAME = "Brake Fluid";
        internal const string PRICES_DEFAULT = "100,150,250";
        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.BRAKE_FLUID_OVERRIDE_NAME;
            base.Start();
        }
        public static float ComputeIncreasedBrakingPowerPercentage()
        {
            int percentage = Plugin.Config.BRAKE_FLUID_POWER_INITIAL_INCREASE + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.BRAKE_FLUID_POWER_INCREMENTAL_INCREASE);
            return percentage / 100f;
        }
        public static int GetIncreasedBrakingPower(int defaultValue)
        {
            if (!Plugin.Config.BRAKE_FLUID_ENABLED) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float multiplier = ComputeIncreasedBrakingPowerPercentage();
            return Mathf.Clamp((int)(defaultValue + (defaultValue * multiplier)), 0, defaultValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.BRAKE_FLUID_PRICES.Value.Split(',');
                return Plugin.Config.BRAKE_FLUID_PRICE.Value <= 0 && prices.Length == 1 && (prices[0] == "" || prices[0] == "0");
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            static float infoFunction(int level) => Plugin.Config.BRAKE_FLUID_POWER_INITIAL_INCREASE.Value + level * Plugin.Config.BRAKE_FLUID_POWER_INCREMENTAL_INCREASE.Value;
            const string infoFormat = "LVL {0} - ${1} - The Company Cruiser vehicle's breaks have an increased power of {2}%.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.BRAKE_FLUID_ITEM_PROGRESSION_ITEMS.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            GameObject prefab = LethalLib.Modules.NetworkPrefabs.CreateNetworkPrefab(UPGRADE_NAME);
            prefab.AddComponent<BrakeFluid>();
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(prefab);
            Plugin.networkPrefabs[UPGRADE_NAME] = prefab;
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            PluginConfig configuration = Plugin.Config;

            return UpgradeBus.Instance.SetupMultiplePurchasableTerminalNode(UPGRADE_NAME,
                                                shareStatus: true,
                                                configuration.BRAKE_FLUID_ENABLED.Value,
                                                configuration.BRAKE_FLUID_PRICE.Value,
                                                UpgradeBus.ParseUpgradePrices(configuration.BRAKE_FLUID_PRICES.Value),
                                                UpgradeBus.Instance.PluginConfiguration.OVERRIDE_UPGRADE_NAMES ? configuration.BRAKE_FLUID_OVERRIDE_NAME : "",
                                                Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
