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
        internal const string PRICES_DEFAULT = "100,100,150,250";
        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.BrakeFluidConfiguration.OverrideName;
            base.Start();
        }
        public static float ComputeIncreasedBrakingPowerPercentage()
        {
            int percentage = Plugin.Config.BrakeFluidConfiguration.InitialEffect + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.BrakeFluidConfiguration.IncrementalEffect);
            return percentage / 100f;
        }
        public static int GetIncreasedBrakingPower(int defaultValue)
        {
            if (!Plugin.Config.BrakeFluidConfiguration.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float multiplier = ComputeIncreasedBrakingPowerPercentage();
            return Mathf.Clamp((int)(defaultValue + (defaultValue * multiplier)), 0, defaultValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.BrakeFluidConfiguration.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            static float infoFunction(int level) => Plugin.Config.BrakeFluidConfiguration.InitialEffect.Value + level * Plugin.Config.BrakeFluidConfiguration.IncrementalEffect.Value;
            const string infoFormat = "LVL {0} - ${1} - The Company Cruiser vehicle's breaks have an increased power of {2}%.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.BrakeFluidConfiguration.ItemProgressionItems.Value.Split(","));
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
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME, Plugin.Config.BrakeFluidConfiguration, Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
