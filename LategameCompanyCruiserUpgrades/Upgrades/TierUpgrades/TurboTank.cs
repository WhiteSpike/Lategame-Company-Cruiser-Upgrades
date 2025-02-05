using MoreShipUpgrades.Managers;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using UnityEngine;
using LategameCompanyCruiserUpgrades.Misc;

namespace LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades
{
    internal class TurboTank : TierUpgrade
    {
        internal const string UPGRADE_NAME = "Turbo Tank";
        internal const string PRICES_DEFAULT = "200,100,200,300";
        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.TurboTankConfiguration.OverrideName;
            base.Start();
        }
        public static int ComputeAdditionalTurboCapacity()
        {
            return Plugin.Config.TurboTankConfiguration.InitialEffect + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.TurboTankConfiguration.IncrementalEffect);
        }
        public static int GetAdditionalTurboCapacity(int defaultValue)
        {
            if (!Plugin.Config.TurboTankConfiguration.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            int additionalValue = ComputeAdditionalTurboCapacity();
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, int.MaxValue);
        }
        public static float GetAdditionalTurboCapacity(float defaultValue)
        {
            if (!Plugin.Config.TurboTankConfiguration.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float additionalValue = ComputeAdditionalTurboCapacity();
            return Mathf.Clamp(defaultValue + additionalValue, defaultValue, float.MaxValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.TurboTankConfiguration.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            System.Func<int, float> infoFunction = level => Plugin.Config.TurboTankConfiguration.InitialEffect.Value + (level * Plugin.Config.TurboTankConfiguration.IncrementalEffect.Value);
            const string infoFormat = "LVL {0} - ${1} - Company Cruiser vehicle's maximum turbo capacity is increased by {2}.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.TurboTankConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            GameObject prefab = LethalLib.Modules.NetworkPrefabs.CreateNetworkPrefab(UPGRADE_NAME);
            prefab.AddComponent<TurboTank>();
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(prefab);
            Plugin.networkPrefabs[UPGRADE_NAME] = prefab;
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME, Plugin.Config.TurboTankConfiguration, Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
