using LategameCompanyCruiserUpgrades.Misc;
using MoreShipUpgrades.Managers;
using MoreShipUpgrades.UI.TerminalNodes;
using MoreShipUpgrades.Misc.Upgrades;
using MoreShipUpgrades.Misc.Util;
using UnityEngine;

namespace LategameCompanyCruiserUpgrades.Upgrades.TierUpgrades
{
    internal class FluffySeats : TierUpgrade
    {
        internal const string UPGRADE_NAME = "Fluffy Seats";
        internal const string PRICES_DEFAULT = "100,100,150,200";

        public override void Start()
        {
            upgradeName = UPGRADE_NAME;
            overridenUpgradeName = Plugin.Config.FluffySeatsConfiguration.OverrideName;
            base.Start();
        }
        public static float ComputePlayerDamageMitigation()
        {
            int percentage = Plugin.Config.FluffySeatsConfiguration.InitialEffect + (GetUpgradeLevel(UPGRADE_NAME) * Plugin.Config.FluffySeatsConfiguration.IncrementalEffect);
            return (100f - percentage) / 100f;
        }
        public static int GetPlayerDamageMitigation(int defaultValue)
        {
            if (!Plugin.Config.FluffySeatsConfiguration.Enabled) return defaultValue;
            if (!GetActiveUpgrade(UPGRADE_NAME)) return defaultValue;
            float multiplier = ComputePlayerDamageMitigation();
            return Mathf.Clamp((int)(defaultValue * multiplier), 0, defaultValue);
        }
        public override bool CanInitializeOnStart
        {
            get
            {
                string[] prices = Plugin.Config.FluffySeatsConfiguration.Prices.Value.Split(',');
                return prices.Length == 0 || (prices.Length == 1 && (prices[0].Length == 0 || prices[0] == "0"));
            }
        }
        public override string GetDisplayInfo(int initialPrice = -1, int maxLevels = -1, int[] incrementalPrices = null)
        {
            static float infoFunction(int level) => Plugin.Config.FluffySeatsConfiguration.InitialEffect.Value + level * Plugin.Config.FluffySeatsConfiguration.IncrementalEffect.Value;
            const string infoFormat = "LVL {0} - ${1} - Player damage is reduced by {2}% when bumping too hard with the Company Cruiser Vehicle.\n";
            return Tools.GenerateInfoForUpgrade(infoFormat, initialPrice, incrementalPrices, infoFunction);
        }
        public new static (string, string[]) RegisterScrapToUpgrade()
        {
            return (UPGRADE_NAME, Plugin.Config.FluffySeatsConfiguration.ItemProgressionItems.Value.Split(","));
        }
        public new static void RegisterUpgrade()
        {
            GameObject prefab = LethalLib.Modules.NetworkPrefabs.CreateNetworkPrefab(UPGRADE_NAME);
            prefab.AddComponent<FluffySeats>();
            LethalLib.Modules.NetworkPrefabs.RegisterNetworkPrefab(prefab);
            Plugin.networkPrefabs[UPGRADE_NAME] = prefab;
        }
        public new static CustomTerminalNode RegisterTerminalNode()
        {
            return UpgradeBus.Instance.SetupMultiplePurchaseableTerminalNode(UPGRADE_NAME, Plugin.Config.FluffySeatsConfiguration, Plugin.networkPrefabs[UPGRADE_NAME]);
        }
    }
}
